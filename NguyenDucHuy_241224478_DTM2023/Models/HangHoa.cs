using NguyenDucHuy_241224478_DTM2023.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NguyenDucHuy_241224478_DTM2023.Models
{
    public partial class HangHoa
    {
        public int MaHang { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn loại hàng")]
        public int MaLoai { get; set; }

        [Required(ErrorMessage = "Tên hàng không được để trống")]
        public string TenHang { get; set; } = null!;

        [Required(ErrorMessage = "Vui lòng nhập giá sản phẩm")]
        [Range(100, 5000, ErrorMessage = "Giá phải là số và nằm trong giới hạn từ 100 đến 5000")]
        public decimal? Gia { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên file ảnh")]
        [RegularExpression(@"^.+\.(jpg|png|gif|tiff|JPG|PNG|GIF|TIFF)$",
            ErrorMessage = "Tên file ảnh phải có đuôi: .jpg | .png | .gif | .tiff")]
        public string? Anh { get; set; }

        // Bắt buộc thêm dấu ? ở đây (xem giải thích bên dưới)
        public virtual LoaiHang? MaLoaiNavigation { get; set; }
    }
}