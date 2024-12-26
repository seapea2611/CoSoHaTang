Hướng dẫn cài đặt code:

Chuẩn bị môi trường:
dotnet version 5
nodejs version 14.18

Database(SQL Server) - có thể làm hoặc không
Bước 1: Restore lại file HrmDb.bak để lấy đầy đủ các data

Back-end (ASP .NET)
Bước 1: Truy cập 2 file sau:
  Source\aspnet-core\src\Asd.Hrm.Web.Mvc\appsettings.json
  Source\aspnet-core\src\Asd.Hrm.Web.Host\appsettings.json
Chỉnh sửa ConnectionStrings cho tên server giống với server database của mình
Bước 2: 
Khởi chạy Back-end
Cách 1: Nhấn nút 'IIS Express' để khởi chạy
Cách 2: Bật terminal theo đường dẫn Source\aspnet-core\src\Asd.Hrm.Web.Host\Asd.Hrm.Web.Host và chạy lệnh 'dotnet run' ( cách này giúp tiết kiệm RAM máy tính hơn)

Front-end
Bước 1: Truy cập đường dẫn: Source\angular và khởi chạy terminal
Bước 2: 
2.1 Chạy lệnh: npm i -g yarn ( cài đặt yarn: 1 trình quản lý cài đặt gói thư viện của Angular)
2.2 Chạy lệnh: yarn (lệnh này sẽ cài đặt các thư viện đã được config trong file package.json)
2.3 Chạy lệnh npm i -g gulp ( cài đặt gulp: Gulp là 1 trình biên dịch giúp biên dịch file SCSS thành file CSS và sẽ tự load lại web khi có sự thay đổi code ở Front-end)
2.4: Chạy lệnh gulp build ( khởi chạy file gulpfile.js để biên dịch file)
2.5 Chạy lệnh: npm run start

=> Truy cập http://localhost:4200/ để truy cập giao diện sử dụng ( tài khoản mật khẩu: admin/123qwe)
