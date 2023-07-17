<div dir="rtl">
    
# امکان اتصال به کانتینرهای آروان کلود و سایر سرویس‌های مشابه را برای کاربران فراهم می‌کند.

## نحوه اتصال

1. کانتینر مورد نظر خود را انتخاب کنید. در قسمت **Image Name**، عبارت `omidrr/samuraiip` را وارد کنید و نسخه را بر روی ``0.3`` تنظیم کنید.

  <div dir="rtl">
  
![image](https://github.com/omidRR/Arvancloud_Container_Port_Forward/assets/64539596/3e93da80-bf22-4f2a-8ff2-c8a7d8d73434)


2. پورت برنامه را بر روی 80 تنظیم کنید.
   
  <div dir="rtl">


![image_2023-07-17_06-51-53](https://github.com/omidRR/Arvancloud_Container_Port_Forward/assets/64539596/815728cc-8b68-42a1-b4e4-5083d96b944c)


3. داکر نیازی به سخت افزار بالایی ندارد. با تنظیم 0.3 CPU و 0.3 RAM و 0.1 هارد، حدود 100 کاربر می‌توانند به آن وصل شوند.
   
  <div dir="rtl">


   ![image_2023-07-16_03-26-57](https://github.com/omidRR/Arvancloud_Container_Port_Forward/assets/64539596/92bb83c3-a7cd-4372-bc0a-1e66c0ca72b5)



4. در قسمت **Environment Variables**، پورت خروجی، آی‌پی سرور، و پورت ورودی سرور را وارد کنید (بدون محدودیت در تعداد پورت). مثلا:


  ``T1=443:IP:2083``
   <br>
   ``T2=2095:IP:2083``
   <br>
   ``T3=OUT_PORT:IP:IN_PORT``
   <br>
   ``T4=....``
   
   <div dir="rtl">

   ![image_2023-07-16_03-27-03](https://github.com/omidRR/Arvancloud_Container_Port_Forward/assets/64539596/180d3e8c-211e-447d-993e-1e47bcea7e5d)


   
5.  دامین رایگان را انتخاب کنید.
      
  <div dir="rtl">

   ![image_2023-07-16_03-28-42](https://github.com/omidRR/Arvancloud_Container_Port_Forward/assets/64539596/07289883-85ca-4483-9b12-d37e9d17b831)


   

6. در این قسمت کلیه پورت‌های مورد نیاز سرور خود را وارد کنید و سپس روی **ساخت سرور** کلیک کنید.
   
  <div dir="rtl">

![image](https://github.com/omidRR/Arvancloud_Container_Port_Forward/assets/64539596/3d069e46-c2e0-4e1d-b4b0-5d771744713a)


   


7. به قسمت **PUBLICIP** بروید و یک آی‌پی با پورت 80 ایجاد کنید. مطمئن شوید که تمام پورت‌هایی که در مراحل قبلی وارد کردید، در این قسمت نیز وارد شده‌اند.
   
  <div dir="rtl">

![image](https://github.com/omidRR/Arvancloud_Container_Port_Forward/assets/64539596/ea589ac3-805b-4d87-a9ba-8411532c8e83)



8. اکنون آدرس IP را دریافت کردیم، آن را در برنامه‌ی v2rayn وارد می‌کنیم. با این کار، بسیار ساده و بدون هیچ مشکلی به سرور متصل می‌شویم.

  <div dir="rtl">

  ![image](https://github.com/omidRR/Arvancloud_Container_Port_Forward/assets/64539596/62cb2bd6-d874-4021-b195-18d1c9e49a41)



    
9. قسمت **logs** امکان نمایش تعداد تقریبی کاربران متصل (کلاینت‌ها) و وضعیت اتصال را نیز در اختیار شما قرار می‌دهد.
    
  <div dir="rtl">

  ![image](https://github.com/omidRR/Arvancloud_Container_Port_Forward/assets/64539596/d550f88f-d220-4632-9b16-dc47cbc8de84)


10. با ارائه آدرس IP کانتینر و پورت 80 ، امکان مشاهده تعداد تقریبی کاربران فراهم می‌گردد.

  <p align="center"><img  src="https://github.com/omidRR/Arvancloud_Container_Port_Forward/assets/64539596/5ebe76eb-4b2d-4391-8f63-04f1d2afb432"></p>
  
</div>
