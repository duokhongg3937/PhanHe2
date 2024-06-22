# Phân hệ 2 - Mức độ hoàn thành UI

## Yêu cầu 1: Cấp quyền truy cập 

### CS1: NVCB có quyền
 - [X] Xem dòng dữ liệu của mình trong **NHANSU**, update SDT 
 - [X] Xem thông tin tất cả **SINHVIEN**, **DONVI**, **HOCPHAN**, **KHMO**

### CS2: GVI có quyền
 - [X] Như một NVCB
 - [X] Xem dữ liệu của mình trong **PHANCONG**
 - [X] Xem dữ liệu liên quan lớp được phân công dạy trong **DANGKY**
 - [X] Cập nhật DIEMTH, DIEMQT, DIEMCK, DIEMTK
  
### CS3: GVU có quyền 
 - [X] Như một NVCB
 - [ ] SELECT, INSERT, UPDATE dữ liệu trong **SINHVIEN**, **DONVI**, **HOCPHAN**, **KHMO** -> Chưa INSERT, UPDATE được SINHVIEN; Chưa UPDATE được KHMO; 
 - [X] Xem toàn bộ **PHANCONG**
 - [ ] Chỉ được UPDATE dòng **PHANCONG** có học phần thuộc Văn phòng Khoa (DV001)
 - [ ] DELETE, INSERT dữ liệu trong **DANGKY** trong thgian hiệu chỉnh 

### CS4: TDV có quyền
 - [X] Như một GVI
 - [ ] INSERT, DELETE, UPDATE trong **PHANCONG** đối với học phần thuộc đơn vị của TDV
 - [ ] Xem dữ liệu trong **PHANCONG** của giảng viện thuộc đơn vị

### CS5: TK có quyền
 - [X] Như một GVI
 - [ ] INSERT, DELETE, UPDATE dữ liệu trong **PHANCONG** đối với học phần thuộc Văn phòng Khoa (DV001)
 - [ ] SELECT, INSERT, DELETE, UPDATE trong **NHANSU**
 - [ ] Xem toàn bộ CSDL

### CS6: Người dùng có VAITRO là “Sinh viên” có quyền hạn: 
- [X] Trên quan hệ SINHVIEN, sinh viên chỉ được xem thông tin của chính mình
- [X] Được chỉnh sửa thông tin địa chỉ (ĐCHI) và số điện thoại liên lạc (ĐT) của chính sinh viên. 
- [X] Xem danh sách tất cả học phần (HOCPHAN), kế hoạch mở môn (KHMO) của chương trình đào tạo mà sinh viên đang theo học.  // tab Kế hoạch mở
- [ ] Thêm, Xóa các dòng dữ liệu đăng ký học phần (ĐANGKY) liên quan đến chính sinh viên đó trong học kỳ của năm học hiện tại (nếu thời điểm hiệu chỉnh đăng ký còn hợp lệ). 
- [X] Sinh viên không được chỉnh sửa trên các trường liên quan đến điểm. 
- [X] Sinh viên được Xem tất cả thông tin trên quan hệ ĐANGKY tại các dòng dữ liệu liên quan đến chính sinh viên. // Tab Tra cứu kết quả học tập

## Yêu cầu 2: Vận dụng mô hình điều khiển truy cập OLS

## Yêu cầu 3: Ghi nhật ký hệ thống 

## Yêu cầu 4: Sao lưu và phục hồi dữ liệu
