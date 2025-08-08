Đánh giá dự án



Ưu điểm

-Tổ chức code rõ ràng, dễ mở rộng.

-Sử dụng event/delegate để giao tiếp giữa các module.



Nhược điểm

-Load liên tục từ Resources.

-Cải thiện hiệu suât bằng Object Pooling.

-Nên sử dụng Scriptable Object để quản lý data.

-Board đang phải xử lý nhiều logic như fill, shuff,..

-GameManager phụ thuộc trực tiếp vào nhiều class
-Quản lý GC chưa tốt



Suggest



-Dùng Addressable Assets để tải asset động.

-Có thể tạo thêm class BoardHandle chứa các logic xử lý của Board như fill, shuff, explo..

-Áp dụng MVC/MVVM để tách biệt UI logic.
-Áp dung Dependency Injection



