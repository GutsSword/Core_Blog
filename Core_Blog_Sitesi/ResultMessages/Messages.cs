namespace Core_Blog_Sitesi.ResultMessages
{
    public static class Messages
    {
        public static string Add(string articleTitle)
        {
            return $"{articleTitle} başlıklı makale başarıyla eklenmiştir.";
        }
        public static string Update(string articleTitle)
        {
            return $"{articleTitle} başlıklı makale başarıyla güncellenmiştir.";
        }
        public static string Delete(string articleTitle)
        {
            return $"{articleTitle} başlıklı makale başarıyla silinmiştir.";
        }
        public static string UndoDelete(string articleTitle)
        {
            return $"{articleTitle} başlıklı makale başarıyla geri yüklenmiştir.";
        }
        public static class Categories
        {
            public static string Add(string categoryName)
            {
                return $"{categoryName} isimli kategori başarıyla eklenmiştir.";
            }
            public static string UndoDelete(string categoryName)
            {
                return $"{categoryName} isimli kategori başarıyla geri yüklenmiştir.";
            }
        }
        public static class Users
        {
            public static string Add(string userName , string lastName)
            {
                return $"{userName} {lastName} isimli kullanıcı başarıyla eklenmiştir.";
            }
            public static string Update(string userName, string lastName)
            {
                return $"{userName} {lastName} isimli kullanıcı başarıyla güncellenmiştir.";
            }
            public static string Delete(string userName, string lastName)
            {
                return $"{userName} {lastName} isimli kullanıcı başarıyla silinmiştir.";
            }
        }
    }
}
