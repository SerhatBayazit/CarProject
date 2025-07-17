ASP.NET Core Razor Pages ile Araç Yönetim Sistemi
Bu proje, ASP.NET Core Razor Pages altyapısıyla geliştirilmiş, kullanıcıların araçları kolayca listeleyebileceği ve yönetebileceği basit bir sistemdir. Modern web standartları ve temiz arayüz yapısı göz önünde bulundurularak geliştirilmiştir.
________________________________________
Genel Bakış
Kullanıcılar bu sistem aracılığıyla araç ekleme, mevcut araçları listeleme, güncelleme ve silme gibi temel işlemleri gerçekleştirebilirler. Proje, web uygulamalarının geliştirilmesinde sıkça kullanılan güncel teknolojileri bir araya getirerek hem işlevsel hem de kullanıcı dostu bir deneyim sunar.
________________________________________
Kullanılan Teknolojiler
•	ASP.NET Core 9.0: Güçlü ve performanslı web uygulamaları geliştirmek için tercih edilen açık kaynaklı bir framework.
•	Razor Pages: ASP.NET Core içinde sayfa tabanlı, daha basit ve üretken web arayüzleri oluşturmak için kullanılan bir model.
•	Entity Framework Core: .NET geliştiricilerinin veritabanı işlemleri için nesne-ilişkisel eşleyici (ORM) aracı.
•	Identity (Kullanıcı Giriş/Çıkış Sistemi): Kullanıcı kayıt, giriş ve kimlik doğrulama süreçlerini yönetmek için ASP.NET Core'un sağladığı bir özellik.
•	SQL Server LocalDB: Geliştirme ortamında kullanılan hafif ve kolay dağıtılabilir bir SQL Server veritabanı sürümü.
•	Bootstrap 5.3: Modern ve duyarlı web tasarımları oluşturmak için popüler bir CSS framework'ü.
•	AJAX: Araç detaylarını dinamik modal pencereler içinde göstermek gibi eşzamansız işlemleri gerçekleştirmek için kullanılmıştır.
________________________________________
Özellikler
•	Kullanıcı Kayıt ve Kimlik Doğrulama: ASP.NET Core Identity altyapısı sayesinde güvenli kullanıcı kayıt ve giriş sistemleri.
•	Giriş Yapan Kullanıcıya Özel Araç Ekleme: Her kullanıcının sadece kendi eklediği araçları yönetebilmesi.
•	Araç Yönetimi: Araçların detaylı listelenmesi, kolayca düzenlenmesi ve silinmesi işlemleri.
•	Dinamik Detay Gösterimi: AJAX kullanılarak araç detaylarının bir modal (açılır pencere) içinde anında ve sayfa yenilemeden görüntülenmesi.
•	Geri Bildirim Mesajları: Başarılı işlemler sonrasında kullanıcıya otomatik kaybolan uyarı (alert) mesajları sunarak daha iyi bir kullanıcı deneyimi.
•	Sade ve Kullanıcı Dostu Arayüz: Temiz ve anlaşılır bir tasarım ile kullanıcıların sistemi kolayca kullanabilmesi.

