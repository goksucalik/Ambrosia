using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ambrosia.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
            "INSERT INTO [Ambrosia].dbo.Categories (Name,Description,CreatedDate,CreatedName,ModifiedDate,ModifiedName,IsActive,IsDeleted) VALUES ('Aperatifler','Taze sebzeler, meyveler, tahıllar ve protein kaynaklarıyla zenginleştirilen salatalar, hem lezzetli hem de besleyici bir öğün sunar.',GETDATE(),'Migration',GETDATE(),'Migration',1,0)");
            migrationBuilder.Sql(
            "INSERT INTO [Ambrosia].dbo.Categories (Name,Description,CreatedDate,CreatedName,ModifiedDate,ModifiedName,IsActive,IsDeleted) VALUES ('İçecekler','Sağlıklı yaşam tarzınızı desteklemek için en taze ve besleyici içecekleri sunuyoruz. Doğal malzemelerle hazırlanan içeceklerimiz, hem lezzetli hem de sağlıklı bir alternatif arayanlar için mükemmel bir seçimdir. İster enerji dolu bir başlangıç yapmak, ister gün içinde ferahlamak isteyin, geniş ürün yelpazemizle her ihtiyaca uygun bir içecek bulabilirsiniz.',GETDATE(),'Migration',GETDATE(),'Migration',1,0)");
            migrationBuilder.Sql(
            "INSERT INTO [Ambrosia].dbo.Categories (Name,Description,CreatedDate,CreatedName,ModifiedDate,ModifiedName,IsActive,IsDeleted) VALUES ('Tatlılar','Tatlı krizlerinizi sağlıklı ve lezzetli alternatiflerle gidermeye hazır mısınız? Sağlıklı Tatlılar Dünyası olarak, doğal ve besleyici malzemelerle hazırlanan tatlılarımızla sizlere hem lezzetli hem de sağlıklı seçenekler sunuyoruz. İster enerji dolu bir atıştırmalık, ister hafif bir tatlı arayın, geniş ürün yelpazemizle her ihtiyaca uygun bir tatlı bulabilirsiniz.',GETDATE(),'Migration',GETDATE(),'Migration',1,0)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
