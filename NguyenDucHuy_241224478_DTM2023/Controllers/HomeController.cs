using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NguyenDucHuy_241224478_DTM2023.Models;
using NguyenDucHuy_241224478_DTM2023.Models;
using System.Diagnostics;

namespace NguyenDucHuy_241224478_DTM2023.Controllers
{
    public class HomeController : Controller
    {
        private readonly QlhangHoa2Context _context;
        public HomeController(QlhangHoa2Context context)
        {
            _context = context;
        }
        //Cau 3:
        public IActionResult Index()
        {
            var danhSachHang = _context.HangHoas.Where(h => h.Gia >= 100).ToList();
            return View(danhSachHang);
        }
        // Câu 4: Trả về PartialView chứa danh sách hàng hóa theo MaLoai
        public IActionResult HangHoaTheoLoai(int maLoai)
        {
            var danhSachTheoLoai = _context.HangHoas
                                           .Where(h => h.MaLoai == maLoai)
                                           .ToList();
            return PartialView("NguyenVanAn_MainContent", danhSachTheoLoai);
        }
        // Hiển thị form Thêm Hàng Hóa Mới
        [HttpGet]
        public IActionResult Create()
        {
            // Lấy danh sách LoaiHang đổ vào Dropdown (hiển thị TenLoai, lấy giá trị MaLoai)
            ViewBag.MaLoai = new SelectList(_context.LoaiHangs, "MaLoai", "TenLoai");
            return View();
        }

        // Nhận dữ liệu từ form và lưu vào SQL Server
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(HangHoa hangHoa)
        {
            if (ModelState.IsValid)
            {
                _context.HangHoas.Add(hangHoa);
                _context.SaveChanges();
                return RedirectToAction("Index"); // Lưu xong quay về trang chủ
            }

            // Nếu dữ liệu nhập sai (ví dụ Giá = 50 hoặc Ảnh = abc.txt), nạp lại Dropdown và trả về form kèm thông báo lỗi
            ViewBag.MaLoai = new SelectList(_context.LoaiHangs, "MaLoai", "TenLoai", hangHoa.MaLoai);
            return View(hangHoa);
        }
    }
}
