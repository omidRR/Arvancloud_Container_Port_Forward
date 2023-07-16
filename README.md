<div dir="rtl">
    
# امکان اتصال به کانتینرهای آروان کلود و سایر سرویس‌های مشابه را برای کاربران فراهم می‌کند.

## نحوه اتصال

1. کانتینر مورد نظر خود را انتخاب کنید. در قسمت **Image Name**، عبارت `omidrr/samuraiip` را وارد کنید و نسخه را بر روی 0.2 تنظیم کنید.

  <div dir="rtl">
  
![image_2023-07-16_03-46-39](https://github.com/omidRR/Arvancloud_Container_Port_Forward/assets/64539596/3bd1bb9b-46c7-465d-b940-2e6a9a2c3646)

2. پورت برنامه را بر روی 5000 تنظیم کنید.
   
  <div dir="rtl">


![image_2023-07-16_03-26-49](https://github.com/omidRR/Arvancloud_Container_Port_Forward/assets/64539596/3b3630b8-703b-404b-a90f-e8a50e72092b)

3. داکر نیازی به سخت افزار بالایی ندارد. با تنظیم 0.3 CPU و 0.3 RAM و 0.1 هارد، حدود 100 کاربر می‌توانند به آن وصل شوند.
   
  <div dir="rtl">


   ![image_2023-07-16_03-26-57](https://github.com/omidRR/Arvancloud_Container_Port_Forward/assets/64539596/bc26400a-bb98-4b99-8870-28120675837f)


4. در قسمت **Environment Variables**، پورت خروجی، آی‌پی سرور، و پورت ورودی سرور را وارد کنید (بدون محدودیت در تعداد پورت). مثلا:


  ``T1=443:IP:2083``
   <br>
   ``T2=2095:ip:2083``
   <br>
   ``T3=OUT_PORT:IP:IN_PORT``
   <br>
   ``T4=....``
   
   <div dir="rtl">

   ![image_2023-07-16_03-27-03](https://github.com/omidRR/Arvancloud_Container_Port_Forward/assets/64539596/92d669f5-18c3-4e75-b0d9-19e66f0eab15)

   
5.  دامین رایگان را انتخاب کنید.
      
  <div dir="rtl">

   ![image_2023-07-16_03-28-42](https://github.com/omidRR/Arvancloud_Container_Port_Forward/assets/64539596/8ab55c2e-10e5-44e3-afd4-642da20b1a95)

   

6. در این قسمت کلیه پورت‌های مورد نیاز را وارد کنید (به یاد داشته باشید پورت 5000 هم باید وارد شود) و سپس روی **ساخت سرور** کلیک کنید.
   
  <div dir="rtl">

   ![image_2023-07-16_03-30-26](https://github.com/omidRR/Arvancloud_Container_Port_Forward/assets/64539596/d05547ef-cb2c-4d7c-843f-92e6844e3963)

   


7. به قسمت **PUBLICIP** بروید و یک آی‌پی با پورت 5000 ایجاد کنید. مطمئن شوید که تمام پورت‌هایی که در مراحل قبلی وارد کردید، در این قسمت نیز وارد شده‌اند.
   
  <div dir="rtl">

![image_2023-07-16_03-33-39](https://github.com/omidRR/Arvancloud_Container_Port_Forward/assets/64539596/f7574a62-2ef4-499b-a3c6-76a1b820b12d)


8. اکنون آدرس IP را دریافت کردیم، آن را در برنامه‌ی v2rayn وارد می‌کنیم. با این کار، بسیار ساده و بدون هیچ مشکلی به سرور متصل می‌شویم.

  <div dir="rtl">

  ![image](https://github.com/omidRR/Arvancloud_Container_Port_Forward/assets/64539596/05a1b2cb-bcf5-49c1-8662-245bb10f6f9a)


    
9. قسمت **logs** امکان نمایش تعداد تقریبی کاربران متصل (کلاینت‌ها) و وضعیت اتصال را نیز در اختیار شما قرار می‌دهد.
    
  <div dir="rtl">

  ![image](https://github.com/omidRR/Arvancloud_Container_Port_Forward/assets/64539596/7205a27e-c933-49fc-8f84-8de68d2070b0)

10. با ارائه آدرس IP کانتینر و پورت 5000، امکان مشاهده تعداد تقریبی کاربران فراهم می‌گردد.

  <p align="center"><img  src="https://github.com/omidRR/Arvancloud_Container_Port_Forward/assets/64539596/a30f8c33-5338-41f0-bb1f-e4448b313948"></p>

  <div dir="rtl">
11. در صورت استفاده از دامین آروان، نیازی به وارد کردن پورت نخواهد بود.

  <br>
   <p align="center"><img  src="https://github.com/omidRR/Arvancloud_Container_Port_Forward/assets/64539596/4e09ab7f-1e8d-428e-a067-82f3018858b7"></p>

</div>
