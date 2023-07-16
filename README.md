<div dir="rtl">
    
# امکان اتصال به کانتینرهای آروان کلود و سایر سرویس‌های مشابه را برای کاربران فراهم می‌کند.

## نحوه اتصال

1. کانتینر مورد نظر خود را انتخاب کنید. در قسمت **Image Name**، عبارت `omidrr/samuraiip` را وارد کنید و نسخه را بر روی 0.2 تنظیم کنید.

  <div dir="rtl">
  
![image_2023-07-16_03-46-39](https://github.com/omidRR/Arvancloud_Container_Port_Forward/assets/64539596/a068e821-2c72-4705-8da5-ffb84110dbc4)


2. پورت برنامه را بر روی 5000 تنظیم کنید.
   
  <div dir="rtl">


![image_2023-07-16_03-26-49](https://github.com/omidRR/Arvancloud_Container_Port_Forward/assets/64539596/0b0c851e-31e3-45cf-b116-b97d8474ef67)


3. داکر نیازی به سخت افزار بالایی ندارد. با تنظیم 0.3 CPU و 0.3 RAM و 0.1 هارد، حدود 100 کاربر می‌توانند به آن وصل شوند.
   
  <div dir="rtl">


   ![image_2023-07-16_03-26-57](https://github.com/omidRR/Arvancloud_Container_Port_Forward/assets/64539596/92bb83c3-a7cd-4372-bc0a-1e66c0ca72b5)



4. در قسمت **Environment Variables**، پورت خروجی، آی‌پی سرور، و پورت ورودی سرور را وارد کنید (بدون محدودیت در تعداد پورت). مثلا:


  ``T1=443:IP:2083``
   <br>
   ``T2=2095:ip:2083``
   <br>
   ``T3=OUT_PORT:IP:IN_PORT``
   <br>
   ``T4=....``
   
   <div dir="rtl">

   ![image_2023-07-16_03-27-03](https://github.com/omidRR/Arvancloud_Container_Port_Forward/assets/64539596/180d3e8c-211e-447d-993e-1e47bcea7e5d)


   
5.  دامین رایگان را انتخاب کنید.
      
  <div dir="rtl">

   ![image_2023-07-16_03-28-42](https://github.com/omidRR/Arvancloud_Container_Port_Forward/assets/64539596/07289883-85ca-4483-9b12-d37e9d17b831)


   

6. در این قسمت کلیه پورت‌های مورد نیاز سرور خود را وارد کنید (به یاد داشته باشید پورت 5000 هم باید وارد شود) و سپس روی **ساخت سرور** کلیک کنید.
   
  <div dir="rtl">

   ![image_2023-07-16_03-30-26](https://github.com/omidRR/Arvancloud_Container_Port_Forward/assets/64539596/2f7ed9d8-0baa-4fd0-94ce-05ad5fb15643)


   


7. به قسمت **PUBLICIP** بروید و یک آی‌پی با پورت 5000 ایجاد کنید. مطمئن شوید که تمام پورت‌هایی که در مراحل قبلی وارد کردید، در این قسمت نیز وارد شده‌اند.
   
  <div dir="rtl">

![image_2023-07-16_03-33-39](https://github.com/omidRR/Arvancloud_Container_Port_Forward/assets/64539596/4e314c34-c75b-4c0f-9f7e-e949fa00f4c7)



8. اکنون آدرس IP را دریافت کردیم، آن را در برنامه‌ی v2rayn وارد می‌کنیم. با این کار، بسیار ساده و بدون هیچ مشکلی به سرور متصل می‌شویم.

  <div dir="rtl">

  ![image](https://github.com/omidRR/Arvancloud_Container_Port_Forward/assets/64539596/62cb2bd6-d874-4021-b195-18d1c9e49a41)



    
9. قسمت **logs** امکان نمایش تعداد تقریبی کاربران متصل (کلاینت‌ها) و وضعیت اتصال را نیز در اختیار شما قرار می‌دهد.
    
  <div dir="rtl">

  ![image](https://github.com/omidRR/Arvancloud_Container_Port_Forward/assets/64539596/d550f88f-d220-4632-9b16-dc47cbc8de84)


10. با ارائه آدرس IP کانتینر و پورت 5000، امکان مشاهده تعداد تقریبی کاربران فراهم می‌گردد.

  <p align="center"><img  src="https://github.com/omidRR/Arvancloud_Container_Port_Forward/assets/64539596/fee886c3-e96a-46ac-b34e-5aaf6526d41b"></p>

  <div dir="rtl">
11. در صورت استفاده از دامین آروان، نیازی به وارد کردن پورت نخواهد بود.

  <br>
   <p align="center"><img  src="https://github.com/omidRR/Arvancloud_Container_Port_Forward/assets/64539596/5cc55290-392b-4d1c-9420-9647469465cc"></p>

</div>
