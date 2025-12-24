# LibraryAPI

ASP.NET Core ile geliştirilmiş basit bir kütüphane yönetim API’sidir.  
Sistem; kütüphane, kitap ve öğrenci bilgilerinin yönetilmesini, kitap ödünç alma ve iade işlemlerinin yapılmasını sağlar.  
Veriler SQL Server üzerinde saklanır ve Swagger arayüzü ile tüm işlemler test edilebilir.

## 🧱 Proje Mimarisi

- **Models**  
  Entity Framework Core tarafından kullanılan veritabanı modellerini içerir.  
  (Library, Book, Student, StudentBook vb.)

- **Dtos**  
  API istek ve cevaplarında kullanılan DTO sınıflarını içerir.  
  - `CreateDto` → POST işlemleri için  
  - `ResponseDto` → GET işlemleri için  

- **Controllers**  
  API endpoint’lerini barındırır. Controller’lar doğrudan Model değil, DTO’lar üzerinden çalışır.

- **Data**  
  `ApplicationDbContext` ve EF Core yapılandırmalarını içerir.

- **Migrations**  
  Entity Framework Core migration dosyaları.

## 🛠 Kullanılan Teknolojiler

ASP.NET Core Web API

Entity Framework Core

SQL Server

DTO (Data Transfer Object) Pattern

Swagger / OpenAPI



## 🚀 Kurulum ve Çalıştırma

 1️⃣ Depoyu klonla
 
git clone https://github.com/eceaaksu/LibraryAPI.git

cd LibraryAPI

2️⃣ NuGet paketlerini yükle

dotnet restore

3️⃣ Veritabanını oluştur


dotnet ef database update

4️⃣ Uygulamayı çalıştır

dotnet run

5️⃣ Swagger

Tarayıcıdan aşağıdaki adrese giderek API’yi test edebilirsin:


https://localhost:{port}/swagger

{port} değeri uygulama çalıştırıldığında terminal çıktısında görüntülenir.

## 📌 API Endpointleri

### 📚 Library
| HTTP | Endpoint | Açıklama |
|-----|---------|----------|
| GET | `/api/Library` | Tüm kütüphaneleri listeler |
| POST | `/api/Library` | Yeni kütüphane ekler |

---

### 📖 Book
| HTTP | Endpoint | Açıklama |
|-----|---------|----------|
| GET | `/api/Book` | Tüm kitapları listeler |
| POST | `/api/Book` | Yeni kitap ekler |

---

### 👤 Student
| HTTP | Endpoint | Açıklama |
|-----|---------|----------|
| POST | `/api/Students` | Öğrenci kaydı oluşturur |
| POST | `/api/Students/login` | Öğrenci girişi yapar |

---

### 🔄 StudentBook (Ödünç Alma / İade)
| HTTP | Endpoint | Açıklama |
|-----|---------|----------|
| POST | `/api/StudentBook` | Kitap ödünç alır |
| DELETE | `/api/StudentBook/{id}` | Kitap iade eder |

---

### 📊 Reports
| HTTP | Endpoint | Açıklama |
|-----|---------|----------|
| GET | `/api/Reports/student-books/{studentId}` | Öğrencinin aldığı kitapları listeler |
| GET | `/api/Reports/library-books/{libraryId}` | Kütüphanedeki kitapları listeler |
| GET | `/api/Reports/who-has-books` | Hangi öğrenci hangi kitabı almış gösterir |







