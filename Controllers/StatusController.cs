using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace PortForwardingAPI.Controllers;

[ApiController]
[Route("")]
public class PortInfoController : ControllerBase
{
    private readonly ILogger<PortInfoController> _logger;

    public PortInfoController(ILogger<PortInfoController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            var connectionDetails = Startup.ConnectedClientsPerPort.Select(portData => new PortDataItem
            {
                Port = portData.Key,
                ClientCount = portData.Value.ClientCount,
                ClientIPs = portData.Value.ClientIPs
            }).ToList();

            var result = new ResultData
            {
                CodedBy = "omidrr @sabzi_khoreshti",
                ConnectionDetails = connectionDetails
            };

            var jsonString = JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true });

            return Content(jsonString, "application/json");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while trying to serialize and pretty print the JSON data.");
            return StatusCode(500, "An error occurred while processing the JSON data.");
        }
    }
}

public class PortDataItem
{
    public int Port { get; set; }
    public int ClientCount { get; set; }
    public List<string> ClientIPs { get; set; }
}

public class ResultData
{
    public string CodedBy { get; set; }
    public List<PortDataItem> ConnectionDetails { get; set; }
}