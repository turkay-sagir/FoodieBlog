<!DOCTYPE html>
<html lang="tr">
<body>

 <h1>FoodieBlog Projesi</h1>
 <p>MY Yazılım Akademi bünyesinde Murat Yücedağ hocamız tarafından gerçekleştirilen ASP.NET Core eğitimine ait bir Blog projesidir. Yapılan bu proje, akademi bünyesindeki 3.projedir.</p>
 <h2>Projeye Genel Bakış</h2>
<p>Bir blog projesi olarak tasarlanan çalışmaya, yazar paneliyle birlikte modülerlik kazandırılmıştır. Yazarların yazdığı blogların anasayfada yayımlanması, 
    yorum yapılabilmesi, blogların Summernote eklentisiyle birlikte html olarak düzenlenebilmesi gibi bir blog sayfasının ihtiyacı olan tüm özellikler projede mevcuttur.
    ViewComponent, Area gibi yapılarla yönetilebilirlik sağlanmıştır. Rollemeyle birlikte admin paneline erişim kısıtı getirilmiştir. ViewModel kullanılarak kullanıcı
    gruplarının görebileceği entity özellikleri sınırlandırılmıştır. Tümüyle yönetilebilir ve modüler bir yapı oluşturularak Blog projesi hazırlanmıştır.
</p>
<h2>Kullanılan Teknolojiler</h2>
<p>🟢 <b>ASP.NET Core 6.0 :</b> Platform bağımsız bir seçenek sunmasıyla öne çıkan .Net Core geliştirme ortamı, performans, modülerlik ve yenilikçi olması nedeniyle tercih edilmiştir.</p>
<p>🟢 <b>Entity Framework 6.0 :</b> Veritabanı ilişkisi için Object Relation Mapping(ORM) araçlarından biri olan Entity Framework kullanılmıştır.</p>
<p>🟢 <b>Code First Yaklaşımı :</b> Entityler ve diğer tüm yapılar, ORM Modelleme yöntemlerinden biri olan <b>Code First Yaklaşımı</b> ile oluşturulmuştur.</p>
<p>🟢 <b>Microsoft SQL Server :</b> Veritabanı yönetim sistemi olarak MSSQL kullanılmıştır.</p>
<p>🟢 <b>N-Katmanlı Mimari ve Repository Design Pattern :</b> Projenin Entity, DataAcces, Business ve Presentation katmanlarına ayrılarak yönetilebilir ve modüler bir yapıda
olması sağlanmıştır. DataAccess katmanında veri erişimini Repository Design Pattern ile soyutlayarak veritabanı işlemleri gerçekleştirilmiştir.</p>
<p>🟢 <b>Identity :</b> Projede, kullanıcı kimlik doğrulama ve yetkinlendirme yapmak için login ve register işlemlerinde kullanılmıştır.</p>
<p>🟢 <b>Fluent Validation :</b> Business katmanı içinde belirlenen doğrulama şartlarını yönetmek amacıyla kullanılmıştır.</p>
<p>🟢 <b>API (Application Programming Interface) :</b> Anlık hava durumu bilgisi sağlaması amacıyla yazar panelinde Dashboard içerisinde kullanılmıştır.</p>
<p>🟢 <b>HTML-CSS-Bootstrap :</b> Frontend tarafındaki tasarımlar için HTML, CSS ve Bootstrap kullanılmıştır.</p>
<p>🟢 <b>AJAX :</b> Bloglara kullanıcı yorumları eklemek için tercih edilmiştir. SweatAlert eklentisiyle kullanıcıya bildirim oluşturulmuştur.</p>
<p>🟢 <b>LINQ :</b> CRUD işlemler sırasında sorgulama, gruplama, sıralama gibi işlemler için LINQ kullanılmıştır.</p>

<h2>Projeden Görüntüler</h2>

<h3>Veritabanı</h3>
<img src="https://github.com/turkay-sagir/FoodieBlog/blob/master/MyBlogPresentationLayer/wwwroot/ProjectImages/Database.jpg">

<hr>
<h3>Anasayfa</h3>
<img src="https://github.com/turkay-sagir/FoodieBlog/blob/master/MyBlogPresentationLayer/wwwroot/ProjectImages/Anasayfa.jpeg">

<hr>
<h3>İletişim</h3>
<img src="https://github.com/turkay-sagir/FoodieBlog/blob/master/MyBlogPresentationLayer/wwwroot/ProjectImages/ContactPage.jpeg">

<hr>
<h3>Blog Detayı 1</h3>
<img src="https://github.com/turkay-sagir/FoodieBlog/blob/master/MyBlogPresentationLayer/wwwroot/ProjectImages/Detail1.jpeg">

<hr>
<h3>Blog Detayı 2</h3>
<img src="https://github.com/turkay-sagir/FoodieBlog/blob/master/MyBlogPresentationLayer/wwwroot/ProjectImages/Detail2.jpeg">

<hr>
<h3>Login Sayfası</h3>
<img src="https://github.com/turkay-sagir/FoodieBlog/blob/master/MyBlogPresentationLayer/wwwroot/ProjectImages/LoginPage.jpeg">

<hr>
<h3>Register Sayfası</h3>
<img src="https://github.com/turkay-sagir/FoodieBlog/blob/master/MyBlogPresentationLayer/wwwroot/ProjectImages/RegisterPage.jpeg">

<hr>
<h3>404 Hata Sayfası</h3>
<img src="https://github.com/turkay-sagir/FoodieBlog/blob/master/MyBlogPresentationLayer/wwwroot/ProjectImages/Error404.jpg">

<hr>
<h3>401 Hata Sayfası</h3>
<img src="https://github.com/turkay-sagir/FoodieBlog/blob/master/MyBlogPresentationLayer/wwwroot/ProjectImages/Error401.jpg">

<hr>
<h3>Yazar Kısmı Blog Sayfası</h3>
<img src="https://github.com/turkay-sagir/FoodieBlog/blob/master/MyBlogPresentationLayer/wwwroot/ProjectImages/YazarBlog.jpeg">

<hr>
<h3>Yazar Kısmı Mesaj Sayfası</h3>
<img src="https://github.com/turkay-sagir/FoodieBlog/blob/master/MyBlogPresentationLayer/wwwroot/ProjectImages/YazarMesaj.jpeg">

<hr>
<h3>Admin Blog Listesi</h3>
<img src="https://github.com/turkay-sagir/FoodieBlog/blob/master/MyBlogPresentationLayer/wwwroot/ProjectImages/AdminBlogList.jpeg">

<hr>
<h3>Admin Tüm Blog Listesi</h3>
<img src="https://github.com/turkay-sagir/FoodieBlog/blob/master/MyBlogPresentationLayer/wwwroot/ProjectImages/AdminTumBlogList.jpeg">

<hr>
<h3>Admin Blog Güncelleme</h3>
<img src="https://github.com/turkay-sagir/FoodieBlog/blob/master/MyBlogPresentationLayer/wwwroot/ProjectImages/AdminBlogGuncelleme.jpeg">

<hr>
<h3>Admin Yeni Blog Ekleme</h3>
<img src="https://github.com/turkay-sagir/FoodieBlog/blob/master/MyBlogPresentationLayer/wwwroot/ProjectImages/AdminYeniBlog.jpeg">

<hr>
<h3>Admin BLog Etiket Ekleme</h3>
<img src="https://github.com/turkay-sagir/FoodieBlog/blob/master/MyBlogPresentationLayer/wwwroot/ProjectImages/AdminBlogEtiket.jpeg">

<hr>
<h3>Admin Dashboard</h3>
<img src="https://github.com/turkay-sagir/FoodieBlog/blob/master/MyBlogPresentationLayer/wwwroot/ProjectImages/AdminDashboard.jpeg">

<hr>
<h3>Admin Profil Düzenleme </h3>
<img src="https://github.com/turkay-sagir/FoodieBlog/blob/master/MyBlogPresentationLayer/wwwroot/ProjectImages/AdminBilgiDuzenle.jpeg">

<hr>
<h3>Admin Gelen Mesaj</h3>
<img src="https://github.com/turkay-sagir/FoodieBlog/blob/master/MyBlogPresentationLayer/wwwroot/ProjectImages/AdminGelenMesaj.jpeg">

<hr>
<h3>Admin Giden Mesaj</h3>
<img src="https://github.com/turkay-sagir/FoodieBlog/blob/master/MyBlogPresentationLayer/wwwroot/ProjectImages/AdminGidenMesaj.jpeg">

<hr>
<h3>Admin Mesaj Gönderme</h3>
<img src="https://github.com/turkay-sagir/FoodieBlog/blob/master/MyBlogPresentationLayer/wwwroot/ProjectImages/AdminMesajGonder.jpeg">

<hr>
<h3>Admin Bildirim Listesi</h3>
<img src="https://github.com/turkay-sagir/FoodieBlog/blob/master/MyBlogPresentationLayer/wwwroot/ProjectImages/AdminBildirimList.jpeg">

<hr>
<h3>Admin Yeni Bildirim Oluşturma</h3>
<img src="https://github.com/turkay-sagir/FoodieBlog/blob/master/MyBlogPresentationLayer/wwwroot/ProjectImages/AdminYeniBildirim.jpeg">

<hr>
<h3>Admin Yorum Listesi</h3>
<img src="https://github.com/turkay-sagir/FoodieBlog/blob/master/MyBlogPresentationLayer/wwwroot/ProjectImages/AdminYorumlar.jpeg">

<hr>
<h3>Admin Yorum Detayı</h3>
<img src="https://github.com/turkay-sagir/FoodieBlog/blob/master/MyBlogPresentationLayer/wwwroot/ProjectImages/AdminYorumDetay.jpeg">

<hr>
<h3>Admin Rol Listesi</h3>
<img src="https://github.com/turkay-sagir/FoodieBlog/blob/master/MyBlogPresentationLayer/wwwroot/ProjectImages/AdminRolList.jpeg">

<hr>
<h3>Admin Rol Güncelleme</h3>
<img src="https://github.com/turkay-sagir/FoodieBlog/blob/master/MyBlogPresentationLayer/wwwroot/ProjectImages/AdminRolGuncelleme.jpeg">

<hr>
<h3>Admin Yeni Rol Ekleme</h3>
<img src="https://github.com/turkay-sagir/FoodieBlog/blob/master/MyBlogPresentationLayer/wwwroot/ProjectImages/AdminYeniRol.jpeg">

<hr>
<h3>Admin Kullanıcı Listesi</h3>
<img src="https://github.com/turkay-sagir/FoodieBlog/blob/master/MyBlogPresentationLayer/wwwroot/ProjectImages/AdminKullan%C4%B1c%C4%B1List.jpeg">

<hr>
<h3>Admin Yeni Rol Ata</h3>
<img src="https://github.com/turkay-sagir/FoodieBlog/blob/master/MyBlogPresentationLayer/wwwroot/ProjectImages/AdminRolAta1.jpeg">

<hr>
<h3>Admin İstatistik</h3>
<img src="https://github.com/turkay-sagir/FoodieBlog/blob/master/MyBlogPresentationLayer/wwwroot/ProjectImages/AdminIstatistik.jpeg">

<hr>
<h3>Admin Etiket Listesi</h3>
<img src="https://github.com/turkay-sagir/FoodieBlog/blob/master/MyBlogPresentationLayer/wwwroot/ProjectImages/AdminEtiket.jpeg">

<hr>
<h3>Admin Navbar Bildirimler</h3>
<img src="https://github.com/turkay-sagir/FoodieBlog/blob/master/MyBlogPresentationLayer/wwwroot/ProjectImages/AdminNavbarBildirim.jpeg">

<hr>
<h3>Admin Navbar Mesajlar</h3>
<img src="https://github.com/turkay-sagir/FoodieBlog/blob/master/MyBlogPresentationLayer/wwwroot/ProjectImages/AdminNavbarMesaj.jpeg">

</body>
</html>
