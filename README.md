#🚗 ASP.NET Core Razor Pages ile Araç Yönetim Sistemi

Bu proje, **ASP.NET Core Razor Pages** altyapısıyla geliştirilmiş, kullanıcıların araçları kolayca listeleyebileceği ve yönetebileceği basit bir sistemdir. Modern web standartları ve temiz arayüz yapısı göz önünde bulundurularak geliştirilmiştir.

---

## Genel Bakış

Kullanıcılar bu sistem aracılığıyla araç ekleme, mevcut araçları listeleme, güncelleme ve silme gibi temel işlemleri gerçekleştirebilirler. Proje, web uygulamalarının geliştirilmesinde sıkça kullanılan güncel teknolojileri bir araya getirerek hem işlevsel hem de kullanıcı dostu bir deneyim sunar.

---

## Kullanılan Teknolojiler

* **ASP.NET Core 9.0:** Güçlü ve performanslı web uygulamaları geliştirmek için tercih edilen açık kaynaklı bir framework.
* **Razor Pages:** ASP.NET Core içinde sayfa tabanlı, daha basit ve üretken web arayüzleri oluşturmak için kullanılan bir model.
* **Entity Framework Core:** .NET geliştiricilerinin veritabanı işlemleri için nesne-ilişkisel eşleyici (ORM) aracı.
* **Identity (Kullanıcı Giriş/Çıkış Sistemi):** Kullanıcı kayıt, giriş ve kimlik doğrulama süreçlerini yönetmek için ASP.NET Core'un sağladığı bir özellik.
* **SQL Server LocalDB:** Geliştirme ortamında kullanılan hafif ve kolay dağıtılabilir bir SQL Server veritabanı sürümü.
* **Bootstrap 5.3:** Modern ve duyarlı web tasarımları oluşturmak için popüler bir CSS framework'ü.
* **AJAX:** Araç detaylarını dinamik modal pencereler içinde göstermek gibi eşzamansız işlemleri gerçekleştirmek için kullanılmıştır.

---

## Özellikler

* **Kullanıcı Kayıt ve Kimlik Doğrulama:** ASP.NET Core Identity altyapısı sayesinde güvenli kullanıcı kayıt ve giriş sistemleri.
* **Giriş Yapan Kullanıcıya Özel Araç Ekleme:** Her kullanıcının sadece kendi eklediği araçları yönetebilmesi.
* **Araç Yönetimi:** Araçların detaylı listelenmesi, kolayca düzenlenmesi ve silinmesi işlemleri.
* **Dinamik Detay Gösterimi:** AJAX kullanılarak araç detaylarının bir modal (açılır pencere) içinde anında ve sayfa yenilemeden görüntülenmesi.
* **Geri Bildirim Mesajları:** Başarılı işlemler sonrasında kullanıcıya otomatik kaybolan uyarı (alert) mesajları sunarak daha iyi bir kullanıcı deneyimi.
* **Sade ve Kullanıcı Dostu Arayüz:** Temiz ve anlaşılır bir tasarım ile kullanıcıların sistemi kolayca kullanabilmesi.


Projeyi Visual Studio'da açın:

Proje klasörüne gidin ve Car.sln (veya çözüm dosyanızın adı) uzantılı dosyaya çift tıklayın.

2. PostgreSQL Veritabanını Hazırlayın
Bu proje, verilerini depolamak için bir PostgreSQL veritabanı kullanır.

PostgreSQL Sunucunuzun Çalıştığından Emin Olun:
Eğer kurulu değilse, PostgreSQL'in resmi web sitesinden işletim sisteminize uygun sürümü indirip kurun. Kurulum sırasında bir yönetici kullanıcı adı (örn. postgres) ve şifre belirlemeyi unutmayın.

Veritabanı yönetimi için pgAdmin kullanmanız önerilir.

Yeni Bir Veritabanı Oluşturun:
pgAdmin veya tercih ettiğiniz başka bir PostgreSQL istemcisi aracılığıyla sunucunuza bağlanın.

Sunucunuzda CarDB adında yeni ve boş bir veritabanı oluşturun.

Veritabanı Bağlantı Dizgesini Yapılandırın:
Projenizin ana dizininde bulunan appsettings.json dosyasını açın.

ConnectionStrings bölümündeki DefaultConnection değerini kendi PostgreSQL sunucunuzun bilgileriyle güncelleyin:

JSON

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
your_pg_username yerine kendi PostgreSQL kullanıcı adınızı (örn. postgres) ve your_pg_password yerine PostgreSQL şifrenizi yazın. Database kısmının CarDB (veya oluşturduğunuz veritabanı adı) ile eşleştiğinden emin olun.

3. NuGet Paketlerini Yükleyin ve Projeyi Derleyin
Projenin tüm bağımlılıklarının yüklendiğinden ve derlenebildiğinden emin olun.

Visual Studio Kullanıcıları İçin:
Visual Studio'da projeyi açtığınızda, gerekli NuGet paketleri otomatik olarak geri yüklenecektir.

Çözüm Gezgini'nde projenize sağ tıklayın ve Build (Derle) > Rebuild Solution (Çözümü Yeniden Oluştur) seçeneğini seçerek projenin hatasız derlendiğinden emin olun.

Komut Satırı Kullanıcıları İçin:
Projenizin ana dizininde (yani Car.sln dosyasının bulunduğu dizin) bir terminal veya komut istemcisi açın.

Bağımlılıkları geri yüklemek için:

Bash

dotnet restore
Projeyi derlemek için:

Bash

dotnet build
4. Veritabanı Migrasyonlarını Uygulayın
Bu adım, Entity Framework Core kullanarak veritabanı şemasını (hem uygulama verileri hem de Identity tabloları) PostgreSQL veritabanınıza uygulayacaktır.

Terminal veya Komut İstemi'ni Açın: Projenizin ana dizininde olduğunuzdan emin olun.

Aşağıdaki komutu çalıştırın:

Bash

dotnet ef database update --project Car.csproj --startup-project Car.csproj
Not: --project Car.csproj ve --startup-project Car.csproj kısmında, kendi ana web projenizin .csproj dosyasının adını kullanmalısınız (varsayılan olarak Car.csproj).

5. Projeyi Çalıştırın
Proje artık çalışmaya hazır!

Visual Studio ile Çalıştırma:
Visual Studio'da F5 tuşuna basın veya üst menüdeki yeşil "Play" (Oynat) butonuna tıklayın. Uygulama derlenecek ve varsayılan web tarayıcınızda açılacaktır (genellikle https://localhost:7001 gibi bir adreste).

Komut Satırı ile Çalıştırma:
Projenizin ana dizininde bir terminal veya komut istemcisi açın.

Aşağıdaki komutu çalıştırın:

Bash

dotnet run --project Car.csproj
Konsolda uygulamanın çalıştığı URL'yi göreceksiniz. Bu URL'yi kopyalayıp web tarayıcınızda açın.

6. Uygulamayı Kullanmaya Başlayın
Uygulama tarayıcınızda açıldığında:

Kayıt Olma: Sağ üst köşedeki "Kayıt Ol" bağlantısına tıklayarak yeni bir kullanıcı hesabı oluşturun. Kayıt formunda "Kullanıcı Adı" alanını doldurmayı unutmayın.

Giriş Yapma: Oluşturduğunuz hesap bilgileriyle (e-posta ve şifre) giriş yapın. Başarılı bir girişin ardından ana ekranda "Merhaba [Kullanıcı Adınız]!" şeklinde kişiselleştirilmiş bir karşılama görmelisiniz.

Araç Yönetimi: Navigasyon menüsündeki "Araçlar" veya ilgili bağlantıları kullanarak araç ekleme, listeleme, detaylarını görüntüleme, düzenleme ve silme işlemlerini gerçekleştirebilirsiniz. Unutmayın, güvenlik gereği, yalnızca kendi eklediğiniz araçları düzenleyebilir veya silebilirsiniz.
