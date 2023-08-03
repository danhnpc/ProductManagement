using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Service
{
    public class HangHoaRepository : IHangHoaRepository
    {
        private readonly MyDBContext _context;

        public HangHoaRepository (MyDBContext context)
        {
            _context = context;
        }
        public List<HangHoaModel> GetAll(string search, double? from, double? to, string sortBy)
        {
            var allProduct = _context.HangHoas.AsQueryable();

            #region Filtering
            if (!string.IsNullOrEmpty(search))
            {
                allProduct = allProduct.Where(hh => hh.TenHh.Contains(search));
            }
            if (from.HasValue)
            {
                allProduct = allProduct.Where(hh => hh.DonGia >= from);
            }
            if (to.HasValue)
            {
                allProduct = allProduct.Where(hh => hh.DonGia <= to);
            }
            #endregion

            #region Sorting
            //Default sort by Name
            allProduct = allProduct.OrderBy(hh => hh.TenHh); 
            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "ten_desc": allProduct = allProduct.OrderByDescending(hh => hh.TenHh); break;
                    case "gia_asc": allProduct = allProduct.OrderBy(hh => hh.DonGia); break;
                    case "gia_desc": allProduct = allProduct.OrderByDescending(hh => hh.DonGia); break;
                    default: allProduct = allProduct.OrderBy(hh => hh.TenHh); break;
                }
            }

            #endregion
            #region Paging

            #endregion
            var result = allProduct.Select(hh => new HangHoaModel
            {
                MaHangHoa = hh.MaHh,
                TenHangHoa = hh.TenHh,
                DonGia = hh.DonGia,
                TenLoai = hh.Loai.TenLoai
            });
            return result.ToList();
        }
    }
}
