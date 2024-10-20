namespace Ambrosia.Services.Utilities
{
    public static class Messages
    {
        public static class Category
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir kategori bulunamadı.";
                return "Böyle bir kategori bulunamadı.";
            }
            public static string Add(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla eklenmiştir.";
            }
            public static string Update(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla güncellenmiştir.";
            }
            public static string Delete(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla silinmiştir.";
            }
            public static string HardDelete(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla veritabanından silinmiştir.";
            }
        }
        public static class Product
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç ürün bulunamadı.";
                return "Böyle bir ürün bulunamadı.";
            }
            public static string Add(string productName)
            {
                return $"{productName} adlı ürün başarıyla eklenmiştir.";
            }
            public static string Update(string productName)
            {
                return $"{productName} adlı ürün başarıyla güncellenmiştir.";
            }
            public static string Delete(string productName)
            {
                return $"{productName} adlı ürün başarıyla silinmiştir.";
            }
            public static string HardDelete(string productName)
            {
                return $"{productName} adlı ürün başarıyla veritabanından silinmiştir.";
            }
        }
        public static class Comment
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir yorum bulunamadı.";
                return "Böyle bir yorum bulunamadı.";
            }

            public static string Add(string createdName)
            {
                return $"Sayın {createdName}, yorumunuz başarıyla eklenmiştir.";
            }

            public static string Update(string createdName)
            {
                return $"{createdName} tarafından eklenen yorum başarıyla güncellenmiştir.";
            }
            public static string Delete(string createdName)
            {
                return $"{createdName} tarafından eklenen yorum başarıyla silinmiştir.";
            }
            public static string HardDelete(string createdName)
            {
                return $"{createdName} tarafından eklenen yorum başarıyla veritabanından silinmiştir.";
            }
        }
    }
}
