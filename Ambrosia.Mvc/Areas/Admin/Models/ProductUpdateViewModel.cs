using Ambrosia.Entities.Concrete;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ambrosia.Mvc.Areas.Admin.Models
{
    public class ProductUpdateViewModel
    {
        [Required]
        public int Id { get; set; }
        [DisplayName("Ürün")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [MaxLength(100, ErrorMessage = "{0} alanı {1} karakterden büyük olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} alanı {1} karakterden küçük olmamalıdır.")]
        public string Name { get; set; }
        [DisplayName("İçerik")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [MinLength(20, ErrorMessage = "{0} alanı {1} karakterden küçük olmamalıdır.")]
        public string Content { get; set; }
        [DisplayName("Fiyat")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [Range(0, double.MaxValue, ErrorMessage = "{0} alanı {1} ile {2} arasında bir değer olmalıdır.")]
        public decimal Price { get; set; }
        [DisplayName("Küçük Resim")]
        public string Thumbnail { get; set; }
        [DisplayName("Küçük Resim Ekle")]
        public IFormFile ThumbnailFile { get; set; }
        [DisplayName("Yorum Sayısı")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [Range(0, int.MaxValue, ErrorMessage = "{0} alanı {1} ile {2} arasında bir değer olmalıdır.")]
        public int CommentCount { get; set; }
        [DisplayName("Yazar Adı")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [MaxLength(50, ErrorMessage = "{0} alanı {1} karakterden büyük olmamalıdır.")]
        [MinLength(0, ErrorMessage = "{0} alanı {1} karakterden küçük olmamalıdır.")]
        public string SeoAuthor { get; set; }
        [DisplayName("Ürün Açıklaması")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [MaxLength(150, ErrorMessage = "{0} alanı {1} karakterden büyük olmamalıdır.")]
        [MinLength(0, ErrorMessage = "{0} alanı {1} karakterden küçük olmamalıdır.")]
        public string SeoDescription { get; set; }
        [DisplayName("Ürün Etiketleri")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [MaxLength(70, ErrorMessage = "{0} alanı {1} karakterden büyük olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı {1} karakterden küçük olmamalıdır.")]
        public string SeoTags { get; set; }
        [DisplayName("Kategori")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        public int CategoryId { get; set; }
        [DisplayName("Aktif Mi?")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        public bool IsActive { get; set; }
        [Required]
        public int UserId { get; set; }
        public IList<Category> Categories { get; set; }
    }
}
