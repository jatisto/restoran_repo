using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Restoran.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Institutions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institutions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InstitutionId = table.Column<int>(nullable: false),
                    DishId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Institutions_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Contact = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "В руках шеф-повара Пьера Ганьера меренги пережили второе рождение. Чтобы сделать белок воздушным, он добавляет в него воду и сахар (первым это придумал мастер молекулярной кухни Эрве Тис) —  и делает из него кристаллы.", "Кристалл ветра", 125.0 },
                    { 2, "В Alinea Грант Ахатц (лучший молодой шеф-повар 2002 года по версии F&W) подает на отдельных пьедесталах пять кусочков пальмы с пятью разными начинками — от ванильного пудинга до пюре из трюфеля и ржаного хлеба.", "Пальмовая сердцевина", 253.0 },
                    { 3, "В Momofuku за обеденным столом-прилавком на 12 персон, придуманным Дэвидом Чангом (лучший молодой шеф 2006 года по версии F&W), можно попробовать невероятно нежный реберный край Питера Серпико, готовящийся 48 часов по вакуумной технологии Sous Vide.", "Нежный реберный край с тушеным дайконом, маринованной морковью и семенами горчицы", 532.0 },
                    { 4, "Салат от Мишеля Браса. В зависимости от сезона он подбирает новые сочетания овощей, трав, цветов и семян — до 60 наименований.", "Гаргуйу", 400.0 },
                    { 5, "В Bazaar Хосе Андреаса мидии маринуют в уксусе с ароматом душистого перца и подают в жестяной банке, отдавая должное традиционным испанским маринованным морепродуктам.", "Мидии в маринаде", 143.0 }
                });

            migrationBuilder.InsertData(
                table: "Institutions",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Новое постоянное кафе The Hummus, специализирующееся на хумусе и фалафеле, откроется на фудкорте Даниловского рынка. В меню будут те же блюда, что и в их киоске в саду имени Баумана, например: фалафель в пите с соленьями, свежими овощами и хумусом; пита с курицей; пита с говяжьим кебабом; домашний фри с тхиной; сабих (сэндвич в пите с жареными баклажанами, варёным яйцом, овощами и тхиной); Jerusalem mix (обжаренное куриное филе с луком, грибами, специями, подающееся на тонкой лепёшке). Но добавят и новые позиции: шакшуку, супы, салаты и новые горячие блюда. Акцент собираются сделать на гриле — на нём будут готовить «мясо в иерусалимском стиле». Кроме еды, The Hummus на Даниловском будут продавать израильские, в том числе кошерные, продукты. ", "The Hummus" },
                    { 2, "Проект-участник «Городского маркета еды» «Любовь Пирогова» открывает своё первое постоянное кафе. Его основатели — супруги Вадим Курганов и Мунира Шерманова. В мае 2014 года они впервые стали участниками «Ресторанного дня», после чего решили открыть собственный бизнес. С тех пор Вадим и Мунира постоянно практиковались, участвуя в уличных маркетах еды, и посещали кулинарные курсы. Мунира закончила поварской и кондитерский курсы кулинарной школы Ragout, курс в «Школе Местной Еды» о том, как открыть свой ресторан и курсы HURMA Management. ", "Кафе «Любовь Пирогова»" },
                    { 3, "Кафе открывают Расул Паркуев, Камила Паркуева и Мурад Калаев, то есть команда, открывшая халяльное кафе Lucky на «Автозаводской», дагестанский ресторан «Жи есть» на Орджоникидзе и pop-up проект для уличных маркетов «Чуду».", "Кафе «Дагестанская лавка»»" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "DishId", "InstitutionId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "DishId", "InstitutionId" },
                values: new object[] { 2, 3, 2 });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Contact", "Name", "OrderId" },
                values: new object[] { 1, "+754 45 225 12", "Васья Пупкин", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_OrderId",
                table: "Clients",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DishId",
                table: "Orders",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_InstitutionId",
                table: "Orders",
                column: "InstitutionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "Institutions");
        }
    }
}
