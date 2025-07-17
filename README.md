# 🚗 Araç Yönetim Sistemi – ASP.NET Core Razor Pages

Bu proje, **ASP.NET Core Razor Pages** kullanılarak geliştirilen, kullanıcıların araç ekleyip yönetebildiği basit ve modern bir web uygulamasıdır. Temiz kod yapısı, kullanıcı dostu arayüz ve güvenli kimlik doğrulama özellikleriyle öne çıkar.

---

## 📋 Genel Özellikler

- ✅ Kullanıcı kayıt ve giriş sistemi (ASP.NET Core Identity ile)
- ✅ Kullanıcıya özel araç listesi (her kullanıcı yalnızca kendi araçlarını görebilir)
- ✅ CRUD işlemleri (ekle, listele, güncelle, sil)
- ✅ AJAX destekli modal detay gösterimi (sayfa yenilenmeden)
- ✅ Otomatik kaybolan alert mesajları
- ✅ Responsive ve modern Bootstrap 5.3 arayüz

---

## 🛠️ Kullanılan Teknolojiler

| Teknoloji             | Açıklama |
|-----------------------|---------|
| ASP.NET Core 9.0      | Modern, performanslı web uygulama çatısı |
| Razor Pages           | Sayfa tabanlı, sade yapı |
| Entity Framework Core | ORM (veritabanı ile çalışma) |
| ASP.NET Core Identity | Kimlik doğrulama ve kullanıcı yönetimi |
| PostgreSQL + LocalDB  | Veritabanı sistemleri |
| Bootstrap 5.3         | Duyarlı arayüz tasarımı |
| AJAX                  | Dinamik ve eşzamansız içerik yükleme |

---

## 🚀 Kurulum Adımları

### 1. 💻 Projeyi Açın
- `Car.sln` dosyasını Visual Studio ile açın.

### 2. 🐘 PostgreSQL Kurulumu
- [PostgreSQL resmi sitesinden](https://www.postgresql.org/) PostgreSQL'i indirip kurun.
- Kurulum esnasında English-US seçin yoksa hata verir.
- `pgAdmin` üzerinden yeni bir veritabanı oluşturun: **CarDB**

### 3. ⚙️ `appsettings.json` Yapılandırması

> 🔐 `your_pg_username` ve `your_pg_password` alanlarını kendi PostgreSQL bilgilerinizle değiştirin.


```bash
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
```

---

### 4. 📦 Bağımlılıkları Yükleyin

#### Visual Studio Kullanıcıları:
- Projeyi açınca NuGet paketleri otomatik yüklenecektir.
- Ardından `Rebuild Solution` yapın.

#### Terminal Üzerinden:
```bash
dotnet restore
dotnet build
```

---

### 5. 🗄️ Veritabanı Migrasyonları

\`\`\`bash
dotnet ef database update --project Car.csproj --startup-project Car.csproj
\`\`\`

> Gerekirse `--project` parametresini kendi `.csproj` dosyanıza göre güncelleyin.

---

### 6. ▶️ Uygulamayı Çalıştırın

#### Visual Studio:
- F5 tuşu veya "Yeşil Başlat" butonuna tıklayın.

#### Terminal:
\`\`\`bash
dotnet run --project Car.csproj
\`\`\`

> Tarayıcıda genellikle `https://localhost:7001` adresinde açılır.

---

## 👤 Kullanıcı İşlemleri

### 📝 Kayıt Ol
- Sağ üstten “Kayıt Ol” butonuna tıklayın.
- “Kullanıcı Adı” alanını da doldurun (sadece karşılama mesajı için kullanılır).

### 🔐 Giriş Yap
- E-posta ve şifreyle giriş yapın.
- Ana sayfada: `Merhaba, [KullanıcıAdı]` mesajı görünür.

---

## 🛠️ Araç Yönetimi

- “Araçlar” menüsünden:
  - Yeni araç ekleyin.
  - Listeleme, detay görüntüleme (modal), düzenleme ve silme işlemleri yapın.
  - 🔒 Sadece kendi eklediğiniz araçları görebilir ve yönetebilirsiniz.

---
