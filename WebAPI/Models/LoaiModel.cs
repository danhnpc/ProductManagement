using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class LoaiModel
    {
        [Required]
        [MaxLength(50)]
        public string TenLoai { get; set; }
    }
}
