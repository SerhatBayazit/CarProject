# 🚗 ASP.NET Core Razor Pages ile Araç Yönetim Sistemi

Bu proje, **ASP.NET Core Razor Pages** altyapısıyla geliştirilmiş, kullanıcıların araçları kolayca listeleyip yönetebileceği basit bir araç yönetim sistemidir. Modern web standartları ve temiz bir arayüz yapısı göz önünde bulundurularak tasarlanmıştır.

---

## 📌 Genel Bakış

Kullanıcılar bu sistem aracılığıyla araç ekleme, listeleme, güncelleme ve silme gibi temel işlemleri gerçekleştirebilirler. Proje, web uygulama geliştirme sürecinde sıkça kullanılan güncel teknolojileri bir araya getirerek işlevsel ve kullanıcı dostu bir deneyim sunar.

---

## 🛠️ Kullanılan Teknolojiler

- **ASP.NET Core 9.0** – Performanslı ve modern web uygulamaları geliştirmek için açık kaynaklı bir framework.
- **Razor Pages** – Sayfa tabanlı, sade ve üretken web arayüzleri oluşturmak için kullanılan ASP.NET Core modeli.
- **Entity Framework Core** – .NET geliştiricileri için nesne-ilişkisel eşleme (ORM) çözümü.
- **ASP.NET Core Identity** – Kullanıcı kayıt, giriş ve kimlik doğrulama işlemleri için güvenli bir sistem.
- **SQL Server LocalDB** – Geliştirme ortamı için hafif ve dağıtımı kolay bir SQL Server sürümü.
- **Bootstrap 5.3** – Duyarlı ve modern tasarımlar için popüler bir CSS framework’ü.
- **AJAX** – Dinamik içerik yükleme (örneğin modal pencerede araç detayları) için eşzamansız veri işlemleri.

---

## 🚀 Özellikler

- **Kullanıcı Kayıt & Giriş Sistemi:** ASP.NET Core Identity sayesinde güvenli bir kullanıcı kimlik doğrulama altyapısı.
- **Kullanıcıya Özel Araç Yönetimi:** Her kullanıcı yalnızca kendi eklediği araçları görebilir ve yönetebilir.
- **CRUD İşlemleri:** Araç ekleme, düzenleme, silme ve listeleme işlemleri kolaylıkla yapılabilir.
- **AJAX ile Detay Gösterimi:** Araç detayları modal pencere ile dinamik olarak gösterilir, sayfa yenilenmeden veri çekilir.
- **Geri Bildirim Mekanizması:** Başarılı işlemler sonrası kullanıcıya kayan ve otomatik kaybolan alert mesajları gösterilir.
- **Temiz ve Modern Arayüz:** Kullanıcı dostu, sade ve responsive tasarım.

1. 💻 Projeyi Visual Studio ile Açın
Proje klasörüne gidin.

Car.sln (veya sizin çözüm dosyanızın adı neyse) uzantılı dosyaya çift tıklayarak Visual Studio'da açın.

2. 🐘 PostgreSQL Veritabanını Hazırlayın
2.1 PostgreSQL'i Yükleyin
Eğer PostgreSQL sisteminizde yüklü değilse, resmi web sitesi üzerinden işletim sisteminize uygun sürümü indirip kurun.

Kurulum sırasında bir kullanıcı adı (genellikle postgres) ve şifre belirlemeyi unutmayın.

Veritabanı yönetimi için pgAdmin arayüzü önerilir.

2.2 Yeni Veritabanı Oluşturun
pgAdmin veya başka bir PostgreSQL istemcisiyle sunucuya bağlanın.

CarDB adında yeni ve boş bir veritabanı oluşturun.

3. ⚙️ appsettings.json Dosyasını Yapılandırın
Proje dizinindeki appsettings.json dosyasını açın ve ConnectionStrings bölümünü aşağıdaki gibi düzenleyin:

json
Kopyala
Düzenle
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=CarDB;Username=your_pg_username;Password=your_pg_password"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
🔒 your_pg_username yerine PostgreSQL kullanıcı adınızı (örneğin postgres),
your_pg_password yerine şifrenizi yazın.
Database=CarDB kısmı, az önce oluşturduğunuz veritabanı adıyla eşleşmelidir.

4. 📦 NuGet Paketlerini Yükleyin ve Projeyi Derleyin
🔹 Visual Studio Kullanıcıları İçin
Visual Studio projeyi açtığınızda NuGet paketleri genellikle otomatik yüklenir.

Ardından Çözüm Gezgini üzerinden projeye sağ tıklayın → Build > Rebuild Solution ile projeyi derleyin.

🔹 Komut Satırı Kullanıcıları İçin
Proje dizinine terminal/komut istemcisiyle gidin:

bash
Kopyala
Düzenle
dotnet restore
Gerekli NuGet paketlerini yükler.

bash
Kopyala
Düzenle
dotnet build
Projeyi derler ve hataları kontrol eder.

5. 🗄️ Veritabanı Migrasyonlarını Uygulayın
Entity Framework Core kullanılarak veritabanı tabloları otomatik olarak oluşturulacaktır.

Proje dizininde şu komutu çalıştırın:

bash
Kopyala
Düzenle
dotnet ef database update --project Car.csproj --startup-project Car.csproj
Not: Car.csproj yerine kendi web projenizin .csproj dosyasını yazmalısınız.

6. ▶️ Uygulamayı Başlatın
🔹 Visual Studio Kullanıcıları
F5 tuşuna basın veya üst menüden **"Yeşil Başlat Butonu"**na tıklayın.

Uygulama genellikle https://localhost:7001 gibi bir adreste açılır.

🔹 Komut Satırı Kullanıcıları
Aşağıdaki komutu çalıştırın:

bash
Kopyala
Düzenle
dotnet run --project Car.csproj
Konsolda verilen URL’yi tarayıcınızda açarak uygulamayı kullanmaya başlayabilirsiniz.

7. 🚗 Uygulamayı Kullanmaya Başlayın
👤 Kullanıcı Kaydı
Sağ üstteki “Kayıt Ol” bağlantısına tıklayın.

Kayıt formunda "Kullanıcı Adı" alanını doldurduğunuzdan emin olun.

🔐 Giriş Yapma
Oluşturduğunuz e-posta ve şifreyle giriş yapın.

Giriş yaptıktan sonra ana ekranda “Merhaba, [Kullanıcı Adınız]!” mesajını göreceksiniz.

🛠️ Araç Yönetimi
Navigasyon menüsünden Araçlar sayfasına gidin.

Araç ekleme, listeleme, detay görüntüleme, düzenleme ve silme işlemlerini gerçekleştirebilirsiniz.

🔒 Güvenlik gereği, sadece kendi eklediğiniz araçlar üzerinde işlem yapabilirsiniz.
