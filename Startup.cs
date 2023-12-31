﻿using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;

namespace PortForwardingAPI
{
    public class Startup
    {
        private static readonly object _lock = new();

        public static ConcurrentDictionary<int, PortData> ConnectedClientsPerPort { get; } = new();

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            InitializePortForwardingFromEnvironment().ConfigureAwait(false);
        }

        private static async Task InitializePortForwardingFromEnvironment()
        {
            var tasks = new List<Task>();
            int index = 1;

            while (true)
            {
                string environmentVariableName = $"T{index}";
                var portDataValue = Environment.GetEnvironmentVariable(environmentVariableName);

                if (string.IsNullOrEmpty(portDataValue))
                {
                    break;
                }

                var portData = portDataValue.Split(':');
                var sourcePort = int.Parse(portData[0]);
                var destinationAddress = portData[1];
                var destinationPort = int.Parse(portData[2]);

                tasks.Add(Task.Run(() => RunPortForwarding(sourcePort, destinationAddress, destinationPort)));

                index++;
            }

            await Task.WhenAll(tasks);
        }

        private static async Task RunPortForwarding(int sourcePort, string destinationAddress, int destinationPort)
        {
            try
            {
                var listener = new TcpListener(IPAddress.Any, sourcePort);
                listener.Start();

                Console.WriteLine(
                    $"Port forwarding started from port {sourcePort} to {destinationAddress}:{destinationPort}");

                while (true)
                {
                    var sourceClient = await listener.AcceptTcpClientAsync();
                    sourceClient.ReceiveTimeout = 500; // Receive timeout in milliseconds
                    sourceClient.SendTimeout = 500; // Send timeout in milliseconds
                    var destinationClient = new TcpClient(destinationAddress, destinationPort);
                    destinationClient.ReceiveTimeout = 10000; // Receive timeout in milliseconds
                    destinationClient.SendTimeout = 10000; // Send timeout in milliseconds                  
                    var clientIpAddress = sourceClient.Client.RemoteEndPoint.ToString();

                    IncrementConnectedClients(sourcePort, clientIpAddress);

                    _ = Task.Run(async () => await ForwardStreams(sourceClient.GetStream(), destinationClient.GetStream(),
                        sourcePort, clientIpAddress));
                    _ = Task.Run(async () => await ForwardStreams(destinationClient.GetStream(), sourceClient.GetStream(),
                        sourcePort, clientIpAddress));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error running port forwarding: {ex.Message}");
            }
        }

        private static async Task ForwardStreams(Stream inputStream, Stream outputStream, int sourcePort, string clientIpAddress)
        {
            try
            {
                using (inputStream)
                using (outputStream)
                {
                    await inputStream.CopyToAsync(outputStream);
                }
            }
            catch (IOException ex) when (ex.InnerException is SocketException socketEx &&
                                         (socketEx.SocketErrorCode == SocketError.ConnectionAborted ||
                                          socketEx.SocketErrorCode == SocketError.ConnectionReset))
            {
                // Connection was closed, we can just return
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error forwarding streams for IP {clientIpAddress}: {ex.Message}");
            }
            finally
            {
                Cleanup(sourcePort, clientIpAddress);
            }
        }
        private static void IncrementConnectedClients(int sourcePort, string clientIpAddress)
        {
            lock (_lock)
            {
                if (!ConnectedClientsPerPort.ContainsKey(sourcePort)) ConnectedClientsPerPort[sourcePort] = new PortData();

                ConnectedClientsPerPort[sourcePort].ClientCount++;
                ConnectedClientsPerPort[sourcePort].ClientIPs.Add(clientIpAddress);
                Console.WriteLine(
                    $"Client {clientIpAddress} connected to port {sourcePort}. ClientCount: {ConnectedClientsPerPort[sourcePort].ClientCount}");
            }
        }

        private static void Cleanup(int sourcePort, string clientIpAddress)
        {
            lock (_lock)
            {
                if (ConnectedClientsPerPort.ContainsKey(sourcePort) &&
                    ConnectedClientsPerPort[sourcePort].ClientIPs.Contains(clientIpAddress))
                {
                    ConnectedClientsPerPort[sourcePort].ClientCount--;
                    ConnectedClientsPerPort[sourcePort].ClientIPs.Remove(clientIpAddress);
                    Console.WriteLine(
                        $"Client {clientIpAddress} disconnected from port {sourcePort}. ClientCount: {ConnectedClientsPerPort[sourcePort].ClientCount}");
                }
            }
        }
    }

    public class PortData
    {
        public int ClientCount { get; set; } = 0;
        public List<string> ClientIPs { get; set; } = new();
    }
}