using Microsoft.AspNetCore.Mvc;
using NguyenDucHuy_241224478_DTM2023.Models;

namespace NguyenDucHuy_241224478_DTM2023.ViewComponents
{
    public class LoaiHangViewComponent : ViewComponent
    {
        private readonly QlhangHoa2Context _context;
        public LoaiHangViewComponent(QlhangHoa2Context context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var danhSachLoai = _context.LoaiHangs.ToList();
            return View(danhSachLoai);
        }
    }
}
