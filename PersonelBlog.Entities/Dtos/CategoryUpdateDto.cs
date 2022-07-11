using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelBlog.Entities.Dtos
{
    public class CategoryUpdateDto
    {
        [Required]
        public int Id { get; set; }
        [DisplayName("Kategori Adı")]
        [Required(ErrorMessage = "{0} boş geçilemez.")]
        [MaxLength(70, ErrorMessage = "{0} {1} 70 karakterden fazla olamaz.")]
        [MinLength(3, ErrorMessage = "{0} {1} 3 karakterden az olamaz.")]
        public string Name { get; set; }
        [DisplayName("Kategori Açıklaması")]
        [Required(ErrorMessage = "{0} boş geçilemez.")]
        [MaxLength(500, ErrorMessage = "{0} {1} 500 karakterden fazla olamaz.")]
        [MinLength(3, ErrorMessage = "{0} {1} 3 karakterden az olamaz.")]
        public string Description { get; set; }
        [DisplayName("Kategori Notu")]
        [Required(ErrorMessage = "{0} boş geçilemez.")]
        [MaxLength(500, ErrorMessage = "{0} {1} 500 karakterden fazla olamaz.")]
        [MinLength(3, ErrorMessage = "{0} {1} 3 karakterden az olamaz.")]
        public string Note { get; set; }
        [DisplayName("Aktif")]
        [Required(ErrorMessage = "{0} boş geçilemez.")]
        public bool IsActive { get; set; }
        [DisplayName("Sil")]
        [Required(ErrorMessage = "{0} boş geçilemez.")]
        public bool IsDeleted { get; set; }
    }
}
