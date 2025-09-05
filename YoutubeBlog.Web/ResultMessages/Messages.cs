namespace YoutubeBlog.Web.ResultMessages
{
    public static class Messages
    {
        public static class Article
        {
            public static string Add(string articleTitle)
            {
                return $"{articleTitle} başlıklı makale başarıkla oluşturulmuştur.";
            }
            public static string Update(string articleTitle)
            {
                return $"{articleTitle} başlıklı makale başarıkla güncellenmiştir.";
            }
            public static string Delete(string articleTitle)
            {
                return $"{articleTitle} başlıklı makale başarıyla silinmiştir.";
            }
            public static string UndoDelete(string articleTitle)
            {
                return $"{articleTitle} başlıklı makale başarıyla geri alınmıştır.";
            }
        }
        public static class Category
        {
            public static string Add(string categoryName)
            {
                return $"{categoryName} başlıklı kategori başarıkla oluşturulmuştur.";
            }
            public static string Update(string categoryName)
            {
                return $"{categoryName} başlıklı kategori başarıkla güncellenmiştir.";
            }
            public static string Delete(string categoryName)
            {
                return $"{categoryName} başlıklı kategori başarıyla silinmiştir.";
            }
            public static string UndoDelete(string categoryName)
            {
                return $"{categoryName} başlıklı kategori başarıyla geri alınmıştır.";
            }
        }
        public static class User
        {
            public static string Add(string userName)
            {
                return $"{userName} mail adresli kullanıcı başarıyla oluşturulmuştur.";
            }
            public static string Update(string userName)
            {
                return $"{userName} mail adresli kullanıcı başarıyla güncellenmiştir.";
            }
            public static string Delete(string userName)
            {
                return $"{userName} mail adresli kullanıcı başarıyla silinmiştir.";
            }
        }
    }
}
