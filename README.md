# Telefon Rehberi - Mehmet Akın ÇABUK

Merhaba! Bu projede; .NET Core 5 tabanlı Telefon Rehberi uygulaması yapılmıştır. Bu uygulamada; rehberinizdeki kişileri görüntüleyebilir, güncelleyebilir, silebilir ve mevcut olan kişilere iletişim bilgileri ekleyebilirsiniz. Kısaca; bu uygulama kişileriniz ve sizin aranızdaki bağı kurmak için birebirdir.

# Uygulama İşlevleri

Uygulama içerisinde yapabileceğiniz özellikler şunlardır;

- Rehberde kişi oluşturma
- Rehberde kişi kaldırma
- Rehberde kişi güncelleme
- Rehberdeki kişilerin listelenmesi
- Rehberdeki kişiye iletişim bilgisi ekleme
- Rehberdeki kişiden iletişim bilgisi kaldırma
- Rehberdeki bir kişiyle ilgili iletişim bilgilerinin de yer aldığı detay bilgilerin getirilmesi
- Rehberdeki kişilerin bulundukları konuma göre istatistiklerini çıkartan bir rapor(to do v2)

## Teknik Özellikler

- .NET Core 5
- Entity Framework 6.4.4 ile Migration
- MSSQL
- Redis (to do v2)

## Kurulum

- Projeyi kullanıma başlamadan önce; komut satırına aşağıdaki komutu yazarak ya da NuGet Package Manager üzerinden projemize Entity Framework'ü dahil etmeniz gerekmektedir.

```
dotnet  tool install --global dotnet-ef
```

- Ardından veri tabanına Entity Framework'ü kullanarak migrate etmenin ilk konfigürasyonunu yapmak için aşağıdaki komut kullanılmalıdır;

```
enable-migrations
```

- Veri tabanına migrate edebilmek için vereceğiniz migrate ismiyle birlikte aşağıdaki komut çalıştırılmalıdır ;

```
add-migration "MigrationName"
```

- Kendi bilgisayarımız içerisinde oluşturduğumuz migration'ı, veri tabanımız üzerine migrate edebilmek için aşağıdaki komu satırı çalıştırılmalıdır;

```
update-database
```

- Ardından MSSQL üzerinde "PhoneBookDb" veri tabanının oluştuğunu kontrol ediniz.

## Kullanım

- Index sayfası üzerinden rehberinizdeki kişileri listeleebilir, Kişi ekle butonu ile rehberinize yeni kişi ekleyebilirsiniz.
- Index sayfası üzerinde listelenen kişileri güncelleyebilir, silebilir, detayına bakabilir ve iletişim bilgisi ekleyebilirsiniz.
- İletişim bilgisi ekleme sayfamızda seçili kişiye telefon numarası, e-posta adresi ve konum bilgisi ekleyebilir. Eklenmiş olan mevcut verileri güncelleyip silebilirsiniz.
- İletişim bilgisi ekleme sayfasında her bir seçili kişi için istenilen miktarda telefon numarası, e-posta adresi ve konum bilgisi eklenebilir.
- Rehberinizdeki kişileri konumlarına göre raporlayabilirsiniz. (To do v2)
