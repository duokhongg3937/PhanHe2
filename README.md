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
## Yêu cầu 2: Vận dụng mô hình điều khiển truy cập OLS

## Yêu cầu 3: Ghi nhật ký hệ thống 

## Yêu cầu 4: Sao lưu và phục hồi dữ liệu
