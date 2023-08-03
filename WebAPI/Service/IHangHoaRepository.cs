using WebAPI.Models;

namespace WebAPI.Service
{
    public interface IHangHoaRepository
    {
        List<HangHoaModel> GetAll(string search, double? from, double? to, string sortBy);
    }
}
