

Bu dökümantasyon, dijital ürünlerin satıldığı bir platformun geliştirilmesi için tasarlanan proje hakkında detaylı bilgiler içermektedir. Proje, mobil ve web uygulamaları üzerinden satış yapabilen bir platformun oluşturulmasını hedeflemektedir. Aşağıda proje kapsamında yer alan ana başlıklar ve detayları yer almaktadır.

1. Kullanıcı İşlemleri
   - Sistemde iki farklı kullanıcı rolü bulunmaktadır: normal kullanıcı ve admin kullanıcı.
   - Kullanıcılar, kayıt sayfası üzerinden kayıt ol API'si ile sisteme kayıt olurlar. Kullanıcı adı ve şifre bilgilerini kendileri belirler.
   - Kullanıcılar hesaplarına giriş yaparak alışveriş yapmaya başlayabilirler.
   - Kullanıcıların hesaplarında dijital cüzdan bulunur ve ödeme işlemleri anlık olarak gerçekleştirilir.
 

2. Ürün İşlemleri
   - Kategori ekleme, silme ve güncelleme işlemleri yapılır. 
   - Ürünlerde kazanılan puan miktarını belirleyen bir alan bulunur. Bu alan, üründen satışta %1 tutarında puan kazandırır. Kazanılan puanlar bir sonraki alışverişte kullanılabilir.
   - Kullanılan puan ve kupon puanları düşüldükten sonra puan hesaplaması yapılır, ürün iadesi durumunda ücret iade edilir, iptal edilen ürün toplam tutardan düşülür ve varsa fazlalık puanlar iade edilir
   - sepet ve siparişten item düşülebilir
   - toplam tutar, net tutar toplam indirim tutarı kupon ve puanlardan gelen indirim miktarları hesaplanır, kullanıcı birden fazla kupon ekleyebilir,kullanıcı kullanmak istediği puan miktarını
     kendi ayarlayabilir.
  

3. Kupon İşlemleri
   - Kuponlar oluşturabilir ve kullanıcılara iletebilir.
   - Sabit değerlere sahipdirler kullanılan kuponlar tekrar kullanılamaz
   - kuponlar puan değerlerine tarihlerine kullanılma durumlarına göre kullandıkları siğarişlere göre listelene bilmektedirler.

4. Database İşlemleri
    Bağlantı için appsetting.json dosyası içinde
   "DbType": "SQL",
    "MsSqlConnection": "Server=(localdb)\\MSSQLLocalDB; Database=Ecom;Trusted_Connection=True;",
    "PostgreSqlConnection": "User ID=postgres;Password=qweqwe32;Server=localhost;Port=5435;Database=.;Integrated Security=true;Pooling=true;"
   ksıımları doldurularak bağlantı tolu sağlanmış olur default olarak "SQL" mssql gelmektedir  tercihe göre dbType == "PostgreSql" ile postgre sql kullanılabilir
   -migration işlemleri için view => other windows üzerinden paket yönetici içine girilip Default project Ecomdata seçildikten sonra sırası ile ilk "Add-Migration InitialCreate" ikinci olarak
   " Update-Database " yazılarak gerçekleştirilir

5 product kısmı tamamen kullanım dışı.

.
