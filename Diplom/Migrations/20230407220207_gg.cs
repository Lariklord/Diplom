using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diplom.Migrations
{
    public partial class gg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserSurname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Points = table.Column<int>(type: "int", nullable: false),
                    Birthday = table.Column<DateTime>(type: "date", nullable: true),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "card"),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SideUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShopCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopCarts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Composition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<int>(type: "int", nullable: false),
                    ShelfLife = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MainUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SideUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    House = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Entrance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Flour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Flat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AccruedPoints = table.Column<int>(type: "int", nullable: false),
                    SpentPoints = table.Column<int>(type: "int", nullable: false),
                    ShopCartId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_ShopCarts_ShopCartId",
                        column: x => x.ShopCartId,
                        principalTable: "ShopCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AddedProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ShopCartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddedProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddedProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AddedProducts_ShopCarts_ShopCartId",
                        column: x => x.ShopCartId,
                        principalTable: "ShopCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavouriteProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavouriteProducts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FavouriteProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "MainUrl", "Name", "SideUrl" },
                values: new object[,]
                {
                    { 1, "https://api.yamigom.by/storage/publicImages/MqDVYYrIrlparST5Gt0Nn3YUG7v0146Z5Spyn7uX.jpg", "Вы уже заказывали", "/categories/zakazivali.webp" },
                    { 2, "https://api.yamigom.by/storage/publicImages/WKJXwZoyzrw3qJtXxQarljJtwGcGAs81IZ2oVKkM.jpg", "Готовая еда", "/categories/complete.webp" },
                    { 3, "https://api.yamigom.by/storage/publicImages/v1Q6YSq0weZcHvefU3fiV1oFfW6pHrnTcFB8tlBT.jpg", "Молочное и яйца", "/categories/milk.webp" },
                    { 4, "https://api.yamigom.by/storage/publicImages/bD1WNK2YuMweU2OGi7Mu7cfRA1a5ynIsFBvTCniy.jpg", "Сыр", "/categories/cheese.webp" },
                    { 5, "https://api.yamigom.by/storage/publicImages/meQLS9NwXWcNBQtFUyY0PclM8sALbAQy6tpaFGgD.jpg", "Овощи и фрукты", "/categories/fruit.webp" },
                    { 6, "https://api.yamigom.by/storage/publicImages/ETzCmQCm7cXmgKYaP1tO8M4kBDucCfjpv9WIkX0V.jpg", "Хлеб и выпечка", "/categories/bread.webp" },
                    { 7, "https://api.yamigom.by/storage/publicImages/kvyuaDIJBpWcedxMmbCYjaMl6rQrJXOJkxmzsW5I.jpg", "Вода и напитки", "/categories/water.webp" },
                    { 8, "https://api.yamigom.by/storage/publicImages/tleOxOl1xlOrgfnOyvr2ykbw6m0unK9bDAx1OOcD.jpg", "Мясо и птица", "/categories/meat.webp" },
                    { 9, "https://api.yamigom.by/storage/publicImages/ExKV5jIRkkSIGAsVvDY0pDNzc8gAjUWXPUHqt1za.jpg", "Рыба и дары моря", "/categories/fish.webp" },
                    { 10, "https://api.yamigom.by/storage/publicImages/R9UhKFQcShn2tpocMqir8A3U3c9vwcH0N2aBMknT.jpg", "Колбасы, сосиски, паштеты", "/categories/sosiges.webp" },
                    { 11, "https://api.yamigom.by/storage/publicImages/TibVKrJLYIgbGGshi7ysQ9F3JqFEG9bE38yfT85Q.jpg", "Морозилка", "/categories/moroz.webp" },
                    { 12, "https://api.yamigom.by/storage/publicImages/hx6hSQSCGXZCl87LwjvIqxWPqkyFuiSzdYuQAvzV.jpg", "Закатки и консервы", "/categories/zakat.webp" },
                    { 13, "https://api.yamigom.by/storage/publicImages/9WxU31mjSk6gINY9zVDa562ftaJthQL1mk8xBXuk.jpg", "Масло и соусы", "/categories/oil.webp" },
                    { 14, "https://api.yamigom.by/storage/publicImages/hdnyuBZigIG0EkYJJGp9LOoBQNdeZeMFA9aJKHaN.jpg", "Соль, сахар, специи", "/categories/salt.webp" },
                    { 15, "https://api.yamigom.by/storage/publicImages/WnVBykuFNwluGI3SNrybOSY5WZag0ole6uobM83k.jpg", "Макароны, крупа и мука", "/categories/flour.webp" },
                    { 16, "https://api.yamigom.by/storage/publicImages/1lcxPoJdeDrtjuFdqikoIpkglF3jcKnLiMqX0Bf3.jpg", "Почти готово", "/categories/bitcomplete.webp" },
                    { 17, "https://api.yamigom.by/storage/publicImages/BVAPW56LCO3phz0PM6qlXab9Mf8XVX5hegUimeUE.jpg", "Чай, кофе, какао", "/categories/tea.webp" },
                    { 18, "https://api.yamigom.by/storage/publicImages/l9nvXokkGKYEsrdjPk0Bkk5GIiCnBGxjUUN8m6VP.jpg", "Сладости", "/categories/sweat.webp" },
                    { 19, "https://api.yamigom.by/storage/publicImages/CrHGJPpzhpz4by3gnhaQfuk4HvP76qeUb9CYejZj.jpg", "Мороженое", "/categories/ice.webp" },
                    { 20, "https://api.yamigom.by/storage/publicImages/mPx0lgXPXprTXwN0ShAzgi02gQpFExBjMimHIo2K.jpg", "Чипсы, снэки и сухарики", "/categories/snaki.webp" },
                    { 21, "https://api.yamigom.by/storage/publicImages/UrwaTiHXeCAyjps1sS9G4gPxgSf55rF4VEFfqIl7.jpg", "Орехи и сухофрукты", "/categories/oreh.webp" },
                    { 22, "https://api.yamigom.by/storage/publicImages/mrQyvhsu27cCZFZslPVoY4qEZizIUXrNBPG76fEC.jpg", "Здоровое питание", "/categories/healthy.webp" },
                    { 23, "https://api.yamigom.by/storage/publicImages/PdTosFSmyZClbO9reHntDI4Ufo53XcuM3eOfDkll.jpg", "Детское питание", "/categories/babyfood.webp" },
                    { 24, "https://api.yamigom.by/storage/publicImages/O4IHCrLbM410iNvllnb4IhTHN6HfTE6uRX4saP6r.jpg", "Уход за детьми", "/categories/baby.webp" },
                    { 25, "https://api.yamigom.by/storage/publicImages/FOhJDdguwPLjt2KYI81DjAqbP4LegFZyDo9zWzs5.jpg", "Косметика и личная гигиена", "/categories/cosmetic.webp" },
                    { 26, "https://api.yamigom.by/storage/publicImages/ursVMi4PW9ROF1JtKSQ24kKdYZQe1QYQQKhDtVCb.jpg", "Для дома", "/categories/home.webp" },
                    { 27, "https://api.yamigom.by/storage/publicImages/Vro7QpFoqq8jtmiJbiQ0gg7oZvelL0erwtnuUAaQ.jpg", "Для животных", "/categories/animal.webp" },
                    { 28, "https://api.yamigom.by/storage/publicImages/1fj3pnXzRlzxodEkYm7XxIX65DkPajGNln2iVWUg.jpg", "Полезные мелочи", "/categories/meloch.webp" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Code", "Composition", "Description", "MainUrl", "Name", "Price", "ShelfLife", "SideUrl", "Weight" },
                values: new object[,]
                {
                    { 1, 2, 1256381, "цыпленок-бройлер филе замороженное, хлеб пшеничный, свинина шпик замороженный, яйцо куриное, лук репчатый, соль, приправа Селянская (сушеные овощи (чеснок), специи (кориандр), тмин, перец черный, лавровый лист)). Может содержать следовые количества компонентов, используемых в производстве других продуктов (горчица, яйца, злаки, содержащие глютен, молоко (в том числе лактоза) и продукты их переработки.", "ФЕРМЕРСКИЙ ПРОДУКТ. Фермерское хозяйство «Вясковыя прысмаки». Кулинарный полуфабрикат из мяса птицы рубленый. Производитель - Крестьянское фермерское хозяйство «Вясковые прысмаки», 220099, г. Минск, ул. Ландера, 22, Республика Беларусь.", "https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F6381%2F01256381%2Fnorm%2Fthumbs%2F01256381.n_1_500x500.png.jpg%3F2023020517&w=640&q=75", "Фрикадельки «Фермерские» замороженные, 350г", 14.91m, "Условия и сроки хранения - срок годности 90 суток при температуре хранения не выше минус 18 °С", null, 0.34999999999999998 },
                    { 2, 2, 1727772, "свинина котлетное мясо, цыпленок-бройлер, филе охл, свинина шпик, вода питьевая, пшеничная клетчатка, соль пищевая йодированная (соль поваренная пищевая, йодат калия (м.д. йода 40+-15) мкг/г), чеснок свежий очищенный, приправа кориандр молотый, оболочка искусственная, приправа перец черный молотый, приправа тмин молотый.", "Производитель - ЗАО \"Интернет-магазин Евроопт\", Минская обл., Минский р-н, Щомыслицкий с/с, Западный п/у, ТЭЦ-4, каб.229, Республика Беларусь", "https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F7772%2F01727772%2Fnorm%2Fthumbs%2F01727772.n_1_500x500.png.jpg%3F2023020517&w=640&q=75", "Полуфабрикат Колбаса «Сочная», замороженный, 600г", 14.15m, "Условия и сроки хранения - хранить при t не выше - 10 °С. Срок хранения в течение: 720 часов", null, 0.59999999999999998 },
                    { 3, 3, 1344717, null, "Производитель - ПУП «Птицефабрика Оршанская» 211035, Витебская обл., Оршанский р-н, аг. Бабиничи, Республика Беларусь.", "https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F4717%2F01344717%2Fnorm%2Fthumbs%2F01344717.n_1_500x500.png.jpg%3F2023020517&w=640&q=75", "Яйцо куриное цветное, С1, 10 шт, 590г", 4.69m, "Условия и сроки хранения - срок годности 120 суток при температуре хранения от 0°С до -2°С, 25 суток при температуре хранения не выше +20°С", null, 0.58999999999999997 },
                    { 4, 3, 638603, "молоко нормализованное.", "Производитель - ГП «Молочный гостинец» 220075, г. Минск, пр-т. Партизанский 170, Беларусь.", "https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F8603%2F00638603%2Fnorm%2Fthumbs%2F00638603.n_1_500x500.png.jpg%3F2023020517&w=640&q=75", "Молоко «Молочный гостинец» ультрапастеризованное, 3.2%, 200 мл", 3.5m, "Условия и сроки хранения - хранить при t не выше - 10 °С. Срок хранения в течение: 720 часов", null, 0.20000000000000001 },
                    { 5, 4, 855382, "молоко коровье нормализованное пастеризованное, закваска на основе молочнокислых и термофильных бактерий, соль поваренная пищевая выварочная (содержит агент антислеживающий ферроцианид калия), консервант нитрат натрия, краситель аннато, уплотнитель хлорид кальция, ферментный препарат животного происхождения: пепсин, химозин.", "Фасованный. Слайсерная нарезка. Без ГМО. Упакован в газовой среде. Производитель - ОАО «Савушкин продукт», 274028, г. Брест, ул. Янки Купалы, 118, Республика Беларусь.", "https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F5382%2F00855382%2Fnorm%2Fthumbs%2F00855382.n_1_500x500.png.jpg%3F2023020517&w=640&q=75", "Сыр полутвёрдый «Брест-Литовск» российский, 50%, 150 г", 24.4m, "Условия и сроки хранения - хранить при температуре от 0 °C до +10 °C и относительной влажности воздуха 90%. После вскрытия упаковки хранить продукт при температуре от +2 °C до +6 °C. Срок годности и дата изготовления указаны на упаковке", null, 0.14999999999999999 },
                    { 6, 4, 822168, "молоко нормализованное пастеризованное, соль (содержит агент антислеживающий Е536), уплотнитель-хлорид кальция, закваска на основе молочноуислых мезофильных и термофильных микроаорганизмов, молокосвертывающий ферментный препарат микробного происхождения, комплексная пищевая добавка, краситель пищевой (сахар, вода, хлорид, натрия, казеинат кальция, подсолнечное масло, краситель бета-каротин, антиокислитель: токоферолы, эмульгатор; лецитины).", "С массовой долей жира в сухом веществе 45%. Упаковано в газовой среде. Производитель - СООО «Белсыр» 247710, Гомельская обл., г. Калинковичи, ул. Советская, д. 7, РБ.", "https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F2168%2F00822168%2Fnorm%2Fthumbs%2F00822168.n_1_500x500.png.jpg%3F2023020517&w=640&q=75", "Сыр фасованный «Edam», 180 г", 21.61m, "Условия и сроки хранения - хранить при t от -4°C до +6°С и относительной влажности воздуха 80-85%. Дата изготовления и срок годности указаны на упаковке", null, 0.17999999999999999 },
                    { 7, 5, 1258394, null, "Производитель - Джининг Греенстреам Фрюитс энд Вегетаблес Ко., Лтд Флоор 10, Блок С, Кюидю бюилдинг, Ренченг Авенюе, Джининг, Шандонг, Китай.", "https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F8394%2F01258394%2Fnorm%2Fthumbs%2F01258394.n_1_500x500.png.jpg%3F2023020517&w=640&q=75", "Чеснок, 400 г", 5.63m, "Условия и сроки хранения - хранить при температуре от +1°С до +3°С и относительной влажности воздуха 85-90%. Срок годности 90 суток. Дата упаковывания указана на стикере", null, 0.40000000000000002 },
                    { 8, 5, 1248939, null, "Производитель - ООО «Овощи ставрополье», 357315, Ставропольский край, Кировский р-н, ст.Марьинская, ул. Садовая, д. 1 «В», Россия.", "https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F8939%2F01248939%2Fnorm%2Fthumbs%2F01248939.n_1_500x500.png.jpg%3F2023020518&w=640&q=75", "Томат черри, 250 г", 28.36m, "Условия и сроки хранения - хранить при t +2°С до +16°С и относительной влажности воздуха от 85% до 90%. Срок годности и дата изготовления указаны на упаковке", null, 0.25 },
                    { 9, 6, 1257517, "мука пшеничная в/с, вода питьевая, сахар, масло подсолнечное рафинированное дезодорированное, соль йодированная, дрожжи хлебопекарные прессованные.", "Производитель - КУП «Минскхлебпром» 220103, г. Минск, ул. Калиновского, 4, Хлебозавод № 5, Республика Беларусь", "https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F7517%2F01257517%2Fnorm%2Fthumbs%2F01257517.n_1_500x500.png.jpg%3F2023020518&w=640&q=75", "Батон «Минский» мини, 250 г", 2.8m, "Условия и сроки хранения - срок годности 5 суток с даты изготовления при температуре хранения не ниже +6°С и относительной влажности воздуха не более 75%. Дата изготовления указана на упаковке", null, 0.25 },
                    { 10, 6, 560208, "мука ржаная хлебопекарная сеяная, мука пшеничная первого сорта, солод ржаной сухой, соль поваренная пищевая йодированная (калий йодноватокислый), смесь сухая хлебопекарная Ржаная новая (мука экструзионная ржаная, солод ржаной неферментированный, ферментный препарат), пюре картофельное сухое (картофель свежий, стабилизатор: моно-и диглицериды жирных кислот), экстракт солодовый ячменный светлый охмеленный, дрожжи прессованные Столичные Люкс, экстракт люцерны, экстракт стевии концентрированный, вода питьева.", "Производитель - КУП «Минскхлебпром», 220088, Хлебозавод «Автомат», г. Минск, ул. Слесарная, 41, Республика Беларусь.", "https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F0208%2F00560208%2Fnorm%2Fthumbs%2F00560208.n_1_500x500.png.jpg%3F2023020518&w=640&q=75", "Хлеб «Водар» светлый, нарезанный, 430 г", 2.53m, "Условия и сроки хранения - срок годности 4 суток с даты изготовления при температуре хранения не ниже +6°С и относительной влажности воздуха не более 75%. Дата изготовления указана на упаковке", null, 0.42999999999999999 },
                    { 11, 7, 12103, "вода, сахар, краситель сахарный колер IV, регулятор кислотности ортофосфорная кислота, натуральные ароматизаторы, кофеин.", "Coca-Cola – один из самых популярных безалкогольных напитков в истории, а также один из наиболее узнаваемых брендов в мире. Coca-Cola была создана в 1886 году в Атланте доктором Джоном С. Пэмбертоном и продавалась как разливной напиток на основе сиропа Coca-Cola и газированной воды. Сегодня неповторимый вкус Coca-Cola Classic знаком миллионам людей по всему миру. Она освежает и наполняет энергией, оставляя приятное пряное послевкусие. Производитель - Унитарное предприятие «Кока-Кола Бевриджиз Белоруссия». Юридический адрес: 223056, Минский р-н, д. Колядичи, д. 147/2. Адрес производства: 223056, Минский р-н, д. Колядичи, д. 147, Беларусь.", "https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F2103%2F00012103%2Fnorm%2Fthumbs%2F00012103.n_1_500x500.png.jpg%3F2023020518&w=640&q=75", "Напиток газированный «Coca-Cola», 330 мл", 3.82m, "Условия и сроки хранения - хранить при температуре от 0°С до +30°C. Открытую банку хранить в холодильнике, употреблять в течении 6 часов", null, 0.33000000000000002 },
                    { 12, 7, 1273776, "Вода, сахар, комплексная пищевая добавка «Подкисляющий компонент» (краситель Е150d, регулятор кислотности Е338, кофеин), ароматизаторы натуральные (в составе стабилизатор гуммиарабик,) подсластитель сукралоза ( в составе вода, подсластитель сукралоза, консерванты: бензоат натрия и сорбат калия, регуляторы кислотности: Е300 и Е331(iii)), регулятор кислотности Е300, ароматизатор натуральный, подсластитель ацесульфам калия.", "Производитель - ОАО «Лидское пиво», 231300, Гродненская область, г. Лида, ул. Мицкевича 32, Республика Беларусь.", "https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F3776%2F01273776%2Fnorm%2Fthumbs%2F01273776.n_1_500x500.png.jpg%3F2023020518&w=640&q=75", "Напиток газированный «Pepsi», 330 мл", 3.63m, "Условия и сроки хранения - хранить при температуре от 0 °С до 22 °С в затемненных, вентилируемых, не имеющих посторонних запахов помещениях. Срок годности и дата изготовления указаны на упаковке", null, 0.33000000000000002 },
                    { 13, 8, 1256722, "мясная мякоть шейной и/или шейно-подлопаточной частей.", "Полуфабрикат мясной натуральный из свинины порционный бескостный. Упаковано под вакуумом. Производитель - ОАО «Брестский мясокомбинат» г. Брест, ул. Писателя Смирнова, 4, Республика Беларусь.", "https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F6722%2F01256722%2Fnorm%2Fthumbs%2F01256722.n_1_500x500.png.jpg%3F2023020519&w=640&q=75", "Полуфабрикат «Стейк из шейки» охлажденный, 0.5 кг", 23.72m, "Условия и сроки хранения - годнен в течение 15 суток с даты изготовления при температуре воздуха от 0°С до плюс 6°С. Дата изготовления указана на упаковке", null, 0.5 },
                    { 14, 8, 766755, null, "Производитель - ЗАО «Серволюкс Агро» 213136, Могилевская обл, Могилевский р-н, Дашковский с/с, Межисеткий, ул. Фабричная,14, Республика Беларусь", "https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F6755%2F00766755%2Fnorm%2Fthumbs%2F00766755.n_1_500x500.png.jpg%3F2023020519&w=640&q=75", "Голень цыпленка-бройлера «Петруха» охлажденная, 750 г", 7.16m, "Условия и сроки хранения - срок годности: 9 суток в упакованном виде при температуре хранения от 0°С до +2°С; 48 часов после нарушения целостности упаковки (в пределах общего срока годности) продукт хранить при температуре от 0°С до +2°С", null, 0.75 },
                    { 15, 9, 1647691, "икра русского осетра, комплексно-пищевая добавка Варэкс-11 (пищевая соль, консервант Е200, антиокислитель Е315).", "Производитель - ООО РВК \"Раскат\", 414015, г. Астрахань, ул. Дзержинского, 80, РФ.", "https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F7691%2F01647691%2Fnorm%2Fthumbs%2F01647691.n_1_500x500.png.jpg%3F2023021218&w=256&q=75", "Икра зернистая «Caviar» осетровая, 56.8г", 3245.44m, "Условия и сроки хранения - хранить при температуре от -2 до -4°С. Срок хранения и годности не более 12 месяцев с даты изготовления", null, 0.056800000000000003 },
                    { 16, 9, 429030, null, "Полуфабрикат. Производитель - ООО СП «Санта Бремор», 224025, г. Брест, ул. Катин Бор, 106, Республика Беларусь.", "https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F9030%2F00429030%2Fnorm%2Fthumbs%2F00429030.n_1_500x500.png.jpg%3F2023020519&w=640&q=75", "Стейк семги «Санта Бремор» замороженный, 400 г", 89.6m, "Условия и сроки хранения - хранить при t от -8 °C, 300 суток, от даты изготовления указанной на упаковке", null, 0.40000000000000002 },
                    { 17, 10, 524221, "шпик хребтовый, свинина, говядина, добавка комплексная пищевая для мясной продукции с йодом (соль поваренная пищевая выварочная экстра (содержит агент антислеживающий (ферроцианид калия)), фиксатор окраски (нитрит натрия), йодат калия)), комплексная пищевая добавка (декстроза, специи (чеснок, лук, кориандр), усилитель вкуса и аромата (глутамат натрия 1-замещенный), соль, антиокислитель (аскорбиновая кислота, L-), экстракты специй (паприка, чеснок)), соль поваренная пищевая йодированная (йодат калия, агент антислеживающий (ферроцианид калия)), стартовые культуры (staphylococcus carnosus, lactobacillus curvatus, pediococcus pentosaceus, декстроза).", "Колбасное изделие мясное, высшего сорта. Охлажденная, упаковано под вакуумом. Производитель - Филиал «Беламит» ЗАО «Серволюкс Агро» 213320, Могилевская обл., Быховский р-н, г. Быхов, ул. Гвардейская, 2а, Республика Беларусь.", "https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F4221%2F00524221%2Fnorm%2Fthumbs%2F00524221.n_1_500x500.png.jpg%3F2023020519&w=640&q=75", "Колбаса сырокопченая салями «Мюнхенская», 100 г", 30.6m, "Условия и сроки хранения - хранить при t от +2 °С до +6 °С и относительной влажности воздуха (75-78)% не более 25 суток с даты изготовления в целой упаковке, при нарушении целостности упаковки - не хранить. Дата изготовления указана на упаковке", null, 0.10000000000000001 },
                    { 18, 10, 719634, "мясные ингредиенты (филе цыплят-бройлеров, мясо цыплят-бройлеров кусковое бескостное, эмульсия из свиной шкурки, жир-сырец свиной), вода питьевая, масло растительное, комплексные пищевые добавки (стабилизаторы: трифосфат калия, полифосфат калия, загустители: ксантановая камедь, гуаровая камедь, декстроза, желирующий агент, каррагинан и его соли, усилитель вкуса и аромата глутамат натрия, ароматизатор «Мясо» антиокислитель изоаскорбат натрия, пряности (кардамон) и их экстракты (кардамон, перец белый), соль поваренная пищевая (антислеживающий агент ферроцианид калия), фиксатор окраски нитрит натрия, йодат калия, животный белок, экстракты пряностей), соль поваренная пищевая йодированная (антислеживающий агент ферроцианид калия), пищевая добавка (краситель кармин).", "Изделие колбасное вареное из мяса птицы. Высшего сорта. Охлажденные. Упаковано в модифицированной газовой среде. Производитель - ЗАО «Дзержинский мясокомбинат» 222750, Минская область, Дзержинский р-н, г. Фаниполь, ул. Заводская, 25, Республика Беларусь.", "https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F9634%2F00719634%2Fnorm%2Fthumbs%2F00719634.n_1_500x500.png.jpg%3F2023020519&w=640&q=75", "Сосиски «Родныя мясціны» из куриного филе, 350 г", 13.34m, "Условия и сроки хранения - срок годности 30 суток с даты изготовления в целой упаковке при t (4±2)°С и относительной влажности воздуха (75±5)%. Дата изготовления указана на упаковке", null, 0.34999999999999998 },
                    { 19, 11, 732852, "грибы шампиньоны резанные.", "Повторное замораживание не допускается. Производитель - ООО «РПК» г. Санкт-Петербург, 196603, г. Пушкин, ул. Саперная, дом 79/1, литер Е, Россия.", "https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F2852%2F00732852%2Fnorm%2Fthumbs%2F00732852.n_1_500x500.png.jpg%3F2023020519&w=640&q=75", "Шампиньоны резанные быстрозамороженные «Свой урожай», 300 г", 8.3m, "Условия и сроки хранения - хранить при температуре не выше -18°C и относительной влажности воздуха не более 95%. Срок годности 24 месяца. Дата изготовления указана на упаковке", null, 0.29999999999999999 },
                    { 20, 11, 1504152, "грибы опята.", "Производитель - ООО «Русберри Лайн» 162840, Вологодская обл., Устюженский р-н, г. Устюжна, ул. Володарского, 77, Россия.", "https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F4152%2F01504152%2Fnorm%2Fthumbs%2F01504152.n_1_500x500.png.jpg%3F2023020519&w=640&q=75", "Опята Намеко «Rusberry» замороженные, 300 г", 21.45m, "Условия и сроки хранения - срок годности 18 месяцев с даты изготовления при температуре хранения не выше -18°С Дата изготовления указана на упаковке", null, 0.29999999999999999 },
                    { 21, 12, 625098, "тунец, соль, вода", "Стерилизованные. 100% натуральный продукт. Производитель - С.П.А. Интернэшнл Фуд Груп Ко ЛТД, Донтоом, 73150, Нахонпатхом, Таиланд", "https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F5098%2F00625098%2Fnorm%2Fthumbs%2F00625098.n_1_500x500.png.jpg%3F2023020519&w=640&q=75", "Консервы рыбные «Morrel» тунец в собственном соку, рубленный, 185 г", 23.51m, "Условия и сроки хранения - хранить при t от 0°С до +25°С и относительной влажности воздуха не более 75%. После вскрытия хранить при t от 0°С до +4°С не более 24 часов. Срок годности – и дата изготовления указаны на упаковке", null, 0.185 },
                    { 22, 12, 373878, "огурцы, маринад (вода питьевая, сахар, соль, регулятор кислотности - уксусная кислота, смесь подсластителей: ацесульфам калия, сукралоза), стебель укропа сушенный, лук репчатый сушенный, чеснок сушенный, перец черный горошек, перец душистый горошек, горчичное семя, хрен-корень сушенный, лавровый лист.", "Консервы пастеризованные. Производитель - ООО «Техада» 352040, Краснодарский край, ст. Павловская, ул. Хлебная, д. 4, Россия.", "https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F3878%2F00373878%2Fnorm%2Fthumbs%2F00373878.n_1_500x500.png.jpg%3F2023020520&w=640&q=75", "Огурцы консервированные «Green Rey» маринованные, 670 г", 6.87m, "Условия и сроки хранения - хранить при температуре от 0 °C до +25 °C и относительной влажности воздуха не более 75%. Срок годности 3 года с даты изготовления, указанной на упаковке", null, 0.67000000000000004 },
                    { 23, 13, 1280492, "вода, паста томатная, уксус натуральный, соль, экстракты специй (содержат сельдерей).", "Производитель - ООО «Петропродукт-Отрадное» 187330, Ленинградская обл., Кировский р-н, г. Отрадное, ул. Железнодорожная, д.1, Россия", "https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F0492%2F01280492%2Fnorm%2Fthumbs%2F01280492.n_1_500x500.png.jpg%3F2023020520&w=640&q=75", "Кетчуп «Heinz» томатный, 320 г", 12.97m, "Условия и сроки хранения - срок годности 12 месяцев с даты изготовления при температуре хранения от 0 °С до +25 °С и относительной влажности воздуха не более 75%. Дата изготовления указана на упаковке", null, 0.32000000000000001 },
                    { 24, 13, 202510, "масло подсолнечное, вода, яичный желток, сахар, соль, уксус из пищевого сырья, яйцо перепелиное маринованное, сок лимонный, масло горчичное, пищевая добавка консервант, сорбиновая кислота, провитамин А.", "Производитель - ЗАО «Эссен Продакшн АГ», 445130, Россия, Самарская обл., Ставропольский р-н, с. Васильевка, ул. Коллективная, д. 54а.", "https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F2510%2F00202510%2Fnorm%2Fthumbs%2F00202510.n_1_500x500.png.jpg%3F2023020520&w=640&q=75", "Майонез «Махеевъ» с перепелиным яйцом, 380 г", 9.18m, "Условия и сроки хранения - хранить при t от 0 до +14 °C, 180 суток; свыше +14 °C до +20 °C - 90 суток", null, 0.38 },
                    { 25, 14, 17355, null, "Производитель - ОАО «Слуцкий сахарорафинадный комбинат» 223610, г. Слуцк, ул. Головащенко, д. 6, Беларусь.", "https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F7355%2F00017355%2Fnorm%2Fthumbs%2F00017355.n_1_500x500.png.jpg%3F2023020520&w=640&q=75", "Сахар свекловичный «Слуцкий» ТС2, песок, 1 кг", 2.61m, "Условия и сроки хранения - хранить при t воздуха не выше +40°C. Дата изготовления и срок годности указаны на упаковке", null, 1.0 },
                    { 26, 14, 141061, "соль поваренная пищевая выварочная экстра Полесье, соль каменная поваренная пищевая, агент антислеживающий Е536", "Помол: до 1.0 мм - 70%, свыше 2.5 мм - 5% Производитель - Концерн «Белгоспищепром» ОАО «Мозырьсоль», 247760, Гомельская обл., г. Мозырь, Республика Беларусь.", "https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F1061%2F00141061%2Fnorm%2Fthumbs%2F00141061.n_1_500x500.png.jpg%3F2023020520&w=640&q=75", "Соль пищевая «Мозырьсоль» Белорусская, поваренная, 1 кг", 0.71m, "Условия и сроки хранения - Хранить в упаковке изготовителя в сухом месте 2 года", null, 1.0 },
                    { 27, 15, 92758, null, "Производитель - ОАО «Барановичский комбинат хлебопродуктов», 225406, г. Барановичи, ул. 50 лет БССР, 21, Республика Беларусь.", "https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F2758%2F00092758%2Fnorm%2Fthumbs%2F00092758.n_1_500x500.png.jpg%3F2023020520&w=640&q=75", "Мука пшеничная «Гаспадар» М 54-28, высший сорт, 1 кг", 1.38m, "Условия и сроки хранения - хранить при t не выше +25 °С и относительной влажности воздуха не более 75 %, срок хранения 12 месяцев", null, 1.0 },
                    { 28, 15, 592267, "мука пшеничная сорт крупка марка МКР-28, вода питьевая.", "Группа Б, сорт крупка. Производитель - ОАО «Лидахлебопродукт», 231300, Гродненская обл., г. Лида, ул. Булата, 1, Республика Беларусь.", "https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F2267%2F00592267%2Fnorm%2Fthumbs%2F00592267.n_1_500x500.png.jpg%3F2023020520&w=640&q=75", "Макаронные изделия «Ligrano» рожки обыкновенные, 900 г", 2.14m, "Условия и сроки хранения - срок годности 24 месяца. Дата изготовления указана на упаковке. Хранить при t не более +30°С и относительной влажности воздуха не более 70%", null, 0.90000000000000002 },
                    { 29, 16, 406193, "зерновые продукты (76,1%) (пшеница (содержит глютен) (50,7%), кукуруза (25,4%)), сахар, какао-порошок алкализованный (4,7%), патока, масло подсолнечное, соль, регулятор кислотности (фосфаты натрия), карбонат кальция.", "Готовый завтрак Хрутка Шоколадные колечки- это именно то, что вам нужно! Добавьте молоко, йогурт, кефир или сок и ваше утро начнется со вкусного разнообразного завтрака для всех и каждого! В состав готового завтрака Хрутка Медовые хлопья входят цельные злаки, которые помогают обеспечить организм важными питательными веществами сложными углеводами, белками и минеральными веществами. Внешняя оболочка цельных злаков (отруби) содержит пищевые волокна, которые способствуют нормальному пищеварению. Производитель - ООО «Сириал Партнерс Рус», 115054, Россия, г. Москва, Павелецкая пл., д. 2, стр. 1.", "https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F6193%2F00406193%2Fnorm%2Fthumbs%2F00406193.n_1_500x500.png.jpg%3F2023020520&w=640&q=75", "Готовый завтрак «Хрутка» шоколадные колечки, 210 г", 12.33m, "Условия и сроки хранения - срок годности: 360 дней при до 20 C° хранить в сухом, прохладном месте", null, 0.20999999999999999 },
                    { 30, 16, 55540, "сахар, масло подсолнечное рафинированное дезодорированное, крупа рисовая, сухой молочный продукт, мука пшеничная, крахмал кукурузный, крупа овсяная, соль йодированная, эмульгатор (соевый лецитин).", "Производитель - КУП «Витебский кондитерский комбинат «Витьба», 210038 г. Витебск, ул. Короткевича, 3", "https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F5540%2F00055540%2Fnorm%2Fthumbs%2F00055540.n_1_500x500.png.jpg%3F2023020520&w=640&q=75", "Сухой завтрак «Витьба» Подушечки, с молочной начинкой, 250 г", 10.64m, "Условия и сроки хранения - годен в течении 9 месяцев. Хранить при t не выше +20 °C и относительной влажности воздуха не более 75 %", null, 0.25 },
                    { 31, 17, 8033, null, "Натуральный жареный, молотый. Производитель - ООО «НЕП» 188682, Ленинградская область, Всеволожский р-н, пос. им. Свердлова, мкп.1, 15/4, Россия.", "https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F8033%2F00008033%2Fnorm%2Fthumbs%2F00008033.n_1_500x500.png.jpg%3F2023020520&w=640&q=75", "Кофе молотый «Жокей» по-восточному, 100 г", 42.5m, "Условия и сроки хранения - хранить при t не более +20 °C и относительной влажности воздуха не более 75 %", null, 0.10000000000000001 },
                    { 32, 17, 1492894, "чай черный листовой, ароматизатор «клубника, малина, красная смородина», лепестки роз, кусочки клубники, кусочки малины.", "Производитель - ЗАО Компания «Май» 141190, г. Фрязино, Московской обл., ул. Озёрная, д. 1а, Россия.", "https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F2894%2F01492894%2Fnorm%2Fthumbs%2F01492894.n_1_500x500.png.jpg%3F2023020520&w=640&q=75", "Чай черный «Curtis» Very Berry, 18х1.7 г", 81.0m, "Условия и сроки хранения - хранить в сухом прохладном месте. Срок годности и дата изготовления указаны на упаковке", null, 0.029999999999999999 },
                    { 33, 18, 1009755, "сахар, масло какао, сыворотка сухая молочная, молоко цельное сухое, миндаль обжаренный дробленый, стружка кокосовая, жир молочный, эмульгаторы (лецитин соевый, Е476), ароматизатор.", "Производитель - ООО «Мон'дэлис Русь» 601123, Владимирская обл., Петушинский р-н, г. Покров, ул. Франца Штольверка, д. 10, Россия.", "https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F9755%2F01009755%2Fnorm%2Fthumbs%2F01009755.n_1_500x500.png.jpg%3F2023020520&w=640&q=75", "Шоколад «Alpen Gold» белый, миндаль и кокос, 85 г", 34.94m, "Условия и сроки хранения - хранить при температуре от +15°С до +21°С и относительной влажности воздуха не более 75%. Срок годности и дата изготовления указаны на упаковке", null, 0.085000000000000006 },
                    { 34, 18, 227964, "сахар, сухое цельное молоко, масло какао, тертое какао, эмульгатор: лецитины (СОИ), идентичный натуральному ароматизатор: ванилин; общий сухой остаток какао-продуктов: не менее 30 %, сухой обезжиренный остаток какао-продуктов: не менее 2.5 %, сухие вещества молока: не менее 18 %, молочный жир не менее 4.5 %; общее содержание какао-продуктов (какао) в шоколадной массе: 30 %; начинка: сахар, сухое обезжиренное молоко, растительный жир, молочный жир, эмульгатор: лецитины (СОИ), идентичный натуральному ароматизатор: ванилин. Полное содержание молочных ингредиентов - 33 %, полное содержание какао-ингредиентов - 13 %.", "Производитель - ЗАО «Ферреро Руссия» 601211, Владимирская обл., Собинский р-н, с. Ворша, кондитерская фабрика «Ферреро» Россия.", "https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F7964%2F00227964%2Fnorm%2Fthumbs%2F00227964.n_1_500x500.png.jpg%3F2023020520&w=640&q=75", "Шоколад «Kinder» молочный, 100 г", 65.1m, "Условия и сроки хранения - хранить в сухом прохладном месте. Срок годности и дата изготовления указаны на упаковке", null, 0.10000000000000001 },
                    { 35, 19, 561302, "вода питьевая, вафельный сахарный рожок (мука пшеничная в/с, вода питьевая, сахар, масло растительное, эмульгатор лецитин (соевый), соль, ароматизатор Ваниль-карамель), молоко цельное сгущенное с сахаром (нормализованное молоко, сахар (сахароза, лактоза)), наполнитель малиновый (сахар, малина, вода питьевая, загуститель пектины, регулятор кислотности лимонная кислота, концентрат из сока черной моркови, ароматизатор), сахар, глазурь кондитерская (заменитель масла какао (жир растительный (масло пальмовое)), сахарная пудра, какао-порошок, эмульгатор лецитины, ароматизатор Ванильный), масло сливочное, патока, молоко сухое цельное, молоко сухое обезжиренное, стабилизаторы (моно- и диглицериды жирных кислот, камедь рожкового дерева, гуаровая камедь), комплексная пищевая добавка Панна котта (содержит вкусоароматические вещества, антиокислитель кислоту аскорбиновую). Продукт может содержать незначительное количество арахиса, орехов, яичных продуктов. Массовая доля жира в мороженом: 8%.", "Производитель - СП «Санта Бремор» ООО, 224025, г. Брест, ул. Катин Бор, 106, Республика Беларусь.", "https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F1302%2F00561302%2Fnorm%2Fthumbs%2F00561302.n_1_500x500.png.jpg%3F2023020520&w=640&q=75", "Мороженое «Soletto» сладкая малина, 75 г", 23.47m, "Условия и сроки хранения - хранить при t не выше -18 °C. Срок годности 12 месяцев. Дата изготовления указана на упаковке", null, 0.074999999999999997 },
                    { 36, 19, 307031, "вода питьевая; печенье сахарное с какао-порошком (мука пшеничная, сахар, масло пальмовое, какао- порошок, крахмал кукурузный, сыворотка молочная сухая, разрыхлитель сода пищевая, эмульгатор лецитин, соль поваренная, ароматизатор идентичный натуральному Шоколад); масло из коровьего молока, сахар-песок, молоко сухое обезжиренное, патока крахмальная (сироп глюкозный); вкусоароматическая паста Ваниль со стручками ванили (глюкозный сироп, ароматизатор Ваниль; вода, сахар, стручки ванил тертые, эмульгаторы: Е472с, Е472d; стабилизатор камедь рожкового дерева); молоко сухое цельное (частично обезжиренное), сыворотка молочная сухая; эмульгатор моно- и диглицериды жирных кислот; стабилизаторы: камедь рожкового дерева, гуаровая камедь, каррагинан, натрийкарбоксиметилцеллюлоза; ароматизатор идентичный натуральному Ваниль, краситель натуральный, бета-каротин. Продукт может содержать незначительное количество арахиса, орехов, яичных продуктов, муки пшеничной.", "Пломбир с кусочками ванили и ароматом ванили. Производитель - СООО «Морозпродукт» 222810, Минская обл., Пуховичский р-н, г. Марьина Горка, ул. Октябрьская, д. 133, комн. 5, Республика Беларусь.", "https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F7031%2F00307031%2Fnorm%2Fthumbs%2F00307031.n_1_500x500.png.jpg%3F2023021221&w=256&q=75", "Мороженое «Каприз» пломбир ванильный, 95 г", 20.95m, "Условия и сроки хранения - хранить при t не выше -18 °C. Срок годности 12 месяцев. Дата изготовления указана на упаковке", null, 0.095000000000000001 },
                    { 37, 20, 1273918, "картофель, растительные масла*, ароматизатор [сахар, соль, порошок молочной сыворотки, вкусоароматические вещества (содержат термический технологический ароматизатор), усилитель вкуса и аромата (глутамат натрия 1-замещенный), специи (содержат белый перец), краситель (экстракт паприки)].", "Чипсы LAY'S®, каждая пачка которых изготовлена из специально отобранного картофеля, соответствует самым высоким стандартам качества. Хрустящие, легкие на вкус картофельные чипсы созданы вызвать улыбку на лице каждого человека, ими так приятно делиться с лучшими друзьями. Они несомненно скрасят ваш день! Специально для ценителей мы приготовили хрустящие чипсы LAY'S® со вкусом нежного камчатского краба. Отличное сочетание вкуса краба и золотистых картофельных чипсов подарят вихрь удовольствия! Производитель - ООО «Фрито Лей Мануфактуринг» 142900, Московская обл., г. Кашира, ул. Меженинова, 5, Россия.", "https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F3918%2F01273918%2Fnorm%2Fthumbs%2F01273918.n_1_500x500.png.jpg%3F2023020520&w=640&q=75", "Чипсы «Lay's» краб, 81 г", 25.56m, "Условия и сроки хранения - хранить продукт при температуре воздуха не выше +25°C и относительной влажности воздуха не более 75%. После вскрытия упаковки хранить продукт не более суток при температуре воздуха не выше +25°C и относительной влажности воздуха не более 75%", null, 0.081000000000000003 },
                    { 38, 20, 430852, "мука пшеничная, крупа манная, масло рапсовое, ароматизатор [сухая молочная сыворотка, усилители вкуса и аромата (глутамат натрия 1-замещенный, 5’-гуанилат натрия 2-замещенный, 5’-инозинат натрия 2-замещенный), вкусоароматические вещества, томатный порошок, порошок сухого молока, термический технологический ароматизатор, специи, травы, краситель (экстракт паприки)], сахар, агент антислеживающий (карбонат кальция), карамелизованный сахар, экстракт моркови.", "Сухарики ХРУСTEAM Багет Королевский краб — это оригинальные хрустящие снеки с воздушной пористой структурой и пряным вкусом. Из-за своей овальной формы внешне Хрустим похожи на тонко нарезанные ломтики миниатюрного багета. Сухарики Хрусteam приятно хрустят и с легкостью раскусываются. Хрусteam можно употреблять в качестве вкусного и сытного перекуса, легкой закуски к прохладительным напиткам, подавать в качестве гренок к крем-супу, использовать для приготовления знаменитого салата Цезарь. Производитель - ООО «Фрито Лей Мануфактуринг», 142900, Московская обл., г. Кашира, ул. Меженинова, 5, Россия.", "https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F0852%2F00430852%2Fnorm%2Fthumbs%2F00430852.n_1_500x500.png.jpg%3F2023020520&w=640&q=75", "Сухарики «Хрусteam» багет, со вкусом королевского краба, 60 г", 24.83m, "Условия и сроки хранения - хранить продукт при температуре воздуха не выше 25 ?С и относительной влажности воздуха не более 75 %. После вскрытия упаковки хранить продукт не более суток при температуре воздуха не выше 25 ?С и относительной влажности воздуха не более 75 %", null, 0.059999999999999998 },
                    { 39, 21, 516257, null, "Производитель - ООО «Маркет Мастер», 222201, РБ, Минская обл., Смолевичский р-н, г. Смолевичи, ул. Промышленная 3.", "https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F6257%2F00516257%2Fnorm%2Fthumbs%2F00516257.n_1_500x500.png.jpg%3F2023020520&w=640&q=75", "Миндаль «Econuts» жареный, 70 г", 43.86m, "Условия и сроки хранения - хранить в сухом прохладном месте не выше 30 C , защищать от воздействия прямых солнечных . лучей. Дата изготовления указана на упаковке", null, 0.070000000000000007 },
                    { 40, 21, 194514, "семена подсолнечника неочищенные, соль поваренная пищевая йодированная содержит антиокислитель ферроцианид калия.", "Производитель - ПОДО «Онега», 223050, Минская обл., Минский р-н, а/г Колодищи, ул. Промышленная, 8/1, Беларусь.", "https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F4514%2F00194514%2Fnorm%2Fthumbs%2F00194514.n_1_500x500.png.jpg%3F2023020520&w=640&q=75", "Семечки подсолнечника «Рень» с солью, 120 г", 22.92m, "Условия и сроки хранения - хранить при t не выше +23 °С и относительной влажности воздуха не более 80 %. Срок годности 6 месяцев от даты изготовления", null, 0.12 },
                    { 41, 22, 1012577, "сироп инулина (фибрулина), вода, молоко сухое обезжиренной массовой долей жира 1,5%, какао-порошок обезжиренный (жирность не более 1%), подсластитель - эритрит (Е968), ароматизатор «Ваниль» ароматизатор «Шоколад» лимонная кислота (Е330), комплексная пищевая добавка «Тиксогам S» (смола акации, загуститель ксантановая камедь), подсластитель стевиозид (Е960), консервант - сорбат калия (Е202). Содержит подсластитель эритрит.", "Производитель - ООО «Питэко», 606402, Нижегородская обл., Балахнинский р-н, г. Балахна, ул. Энгельса, д. 110, Россия.", "https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F2577%2F01012577%2Fnorm%2Fthumbs%2F01012577.n_1_500x500.png.jpg%3F2023020521&w=640&q=75", "Сироп низкокалорийный «Fit Active» шоколад, 300 г", 36.63m, "Условия и сроки хранения - хранить при температуре не выше +25 °С и относительной влажности воздуха не более 75%. Срок годности 12 месяцев с даты изготовления, указанной на упаковке", null, 0.29999999999999999 },
                    { 42, 22, 890528, "цельные зерна пшеницы, крупа рисовая, продукция соковая (сок черничный концентрированный), патока крахмальная, сушеные измельченные ягоды черники, пищевая добавка сукралоза (подсластитель), ароматизатор пищевая натуральный «Черника»", "Производитель - ИП Харламов В.В., 346880, Ростовская область, г. батайк, ул. Революционная 107, Россия.", "https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F0528%2F00890528%2Fnorm%2Fthumbs%2F00890528.n_1_500x500.png.jpg%3F2023020521&w=640&q=75", "Хлебцы «Doctor Green» хрустящие с черникой, 80 г", 19.88m, "Условия и сроки хранения - хранить при температуре до +25°С и относительной влажности воздуха не более 75%. Срок годности: 12 месяцев", null, 0.080000000000000002 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Code", "Composition", "Description", "MainUrl", "Name", "Price", "ShelfLife", "SideUrl", "Weight" },
                values: new object[,]
                {
                    { 43, 23, 98610, "мука рисовая, витамины (С, Е, РР, пантотеновая кислота, В6, В1, В2, А, фолиевая кислота, D3, биотин, В12), минеральные вещества (железо, цинк, йод). Продукт может содержать следы молока и глютена, т.к. все сухие каши «ФрутоНяня» производятся на одном промышленном оборудовании.", "Для питания детей с 4 месяцев. Производитель - ОАО «Прогресс» 389902, г. Липецк, ул. Ангарская, влад. 2, Россия.", "https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F8610%2F00098610%2Fnorm%2Fthumbs%2F00098610.n_1_500x500.png.jpg%3F2023020522&w=640&q=75", "Каша сухая безмолочная «Фруто Няня» рисовая гипоаллергенная, 200 г", 16.55m, "Условия и сроки хранения - невскрытую упаковку следует хранить в сухом прохладном месте, защищнном от прямых солнечных лучей, при t не более +25 °C и относительной влажности не более 75 %. Открытую упаковку хранить в сухом прохладном месте (но не в холодильнике) не более 20 дней. После каждого использования пакет тщательно закрывать. Срок годности - 12 месяцев", null, 0.20000000000000001 },
                    { 44, 23, 522363, "пюре из яблок. Без добавления сахара. Содержит сахара природного происхождения. Изготовлено из концентрированного пюре.", "Стерилизованное. Гомогенизированное. Для питания детей раннего возраста с 4 месяцев. Производитель - ОАО «Прогресс» 389902, г. Липецк, ул. Ангарская, влад. 2, Россия.", "https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F2363%2F00522363%2Fnorm%2Fthumbs%2F00522363.n_1_500x500.png.jpg%3F2023020522&w=640&q=75", "Пюре фруктовое «Фрутоняня» из яблок, 90 г", 11.0m, "Условия и сроки хранения - хранить при температуре от 0°С до +25°С и относительной влажности воздуха не более 75 %, 12 месяцев. После вскрытия банки содержимое хранить не более суток. Дата изготовления указана на упаковке", null, 0.080000000000000002 },
                    { 45, 24, 931647, "целлюлоза, суперабсорбент (САП), нетканый материал, полиэтилен, клей, нить эластомерная, крем-бальзам. Состав крем-бальзама: вода питьевая очищенная, ПЭГ-6 каприлик/каприк глицериды, цетеариловый спирт, масло вазелиновое, цетеарет-20, глицерилмоностеарт, экстракт алоэ вера, глицерин, отдушка, бензизатиазолинон и метилизотиазолинон.", "Производитель - ООО \"БелЭмса\", 213121, Могилевская обл., Могилевский р-н, Полыковичский с/с, 9, Республика Беларусь.ООО \"БелЭмса\", 213121, Могилевская обл., Могилевский р-н, Полыковичский с/с, 9, Республика Беларусь.", "https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F1647%2F00931647%2Fnorm%2Fthumbs%2F00931647.n_1_500x500.png.jpg%3F2023020522&w=640&q=75", "Подгузники для детей «Happy mum» размер 4, 7-18 кг, 18 шт", 7.33m, "Условия и сроки хранения - невскрытую упаковку следует хранить в сухом прохладном месте, защищнном от прямых солнечных лучей, при t не более +25 °C и относительной влажности не более 75 %. Открытую упаковку хранить в сухом прохладном месте (но не в холодильнике) не более 20 дней. После каждого использования пакет тщательно закрывать. Срок годности - 12 месяцев", null, 0.0 },
                    { 46, 24, 1460063, null, "Производитель - Бюбхен Верк Эвальд Гермес Фармацойтише Фабрик Гмбх, Коестервег 37, 59494 Зоест, Германия.", "https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F0063%2F01460063%2Fnorm%2Fthumbs%2F01460063.n_1_500x500.png.jpg%3F2023020522&w=640&q=75", "Шампунь для младенцев «Bubchen», 200 мл", 8.39m, "Условия и сроки хранения - срок годности и дата изготовления указаны на упаковке", null, 0.0 },
                    { 47, 25, 162714, "aqua, Sodium Lauryl Sulfate, Sodium Laureth Sulfate, Glycol Distearate, Zinc Carbonate, Sodium Chloride, Sodium Xylenesulfonate, Zinc Pyrithione, Cocamidopropyl Betaine, Dimethicone, Parfum, Menthol, Sodium Benzoate, Guar Hydroxypropyltrimonium Chloride, Hydrochloric Acid, Sodium Hydroxide, Magnesium Carbonate Hydroxide, Hexyl Cinnamal, Linalool, Magnesium Nitrate, Sodium Polynaphthalenesulfonate, Methylchloroisothiazolinone, Magnesium Chloride, CI 42090, Methylisothiazolinone, CI 17200.", "Избавьтесь от перхоти с помощью шампуня против перхоти Head & Shoulders с освежающим ментолом. Шампунь Head & Shoulders с формулой тройного действия очищает, защищает и увлажняет (при регулярном использовании) ваши волосы и кожу головы — вы получите до 100%* свободы от перхоти, а ваши волосы будут выглядеть здоровыми и красивыми. Свойства шампуня Head & Shoulders отвечают новым высоким стандартам красоты, а в его состав входит опробованный и протестированный активный ингредиент против перхоти, благодаря чему волосы прекрасно выглядят, а перхоть исчезает (*видимые чешуйки, при регулярном применении). Для нормальных и жирных волос. Производитель - С.К.Детергенти С.A., Стр.Михаи Витеазу, нр.1, Урлати, 106300, Румыния.", "https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F2714%2F00162714%2Fnorm%2Fthumbs%2F00162714.n_1_500x500.png.jpg%3F2023020522&w=640&q=75", "Шампунь для волос «Head&Shoulders» 3 Action Ментол, 400 мл", 17.40m, "Условия и сроки хранения - срок годности 3 года. Дата изготовления указана на упаковке", null, 0.0 },
                    { 48, 25, 1511287, null, "Производитель - ЗАО «Олтекс С.А.» 142700, Московская обл., Ленинский р-н, г. Видное, Белокаменное ш., вл. 18, Россия.", "https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F1287%2F01511287%2Fnorm%2Fthumbs%2F01511287.n_1_500x500.png.jpg%3F2023020522&w=640&q=75", "Прокладки гигиенические «Ola!» 9 шт", 2.06m, "Условия и сроки хранения - срок годности 5 лет. Дата изготовления указана на упаковке", null, 0.0 },
                    { 49, 26, 1408633, null, "Производитель - ООО «Пластком» 197761, г. Санкт-Петербург, г. Кронштадт, Кронштадтское шоссе, д. 9, литер А, пом. 85, Россия.", "https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F8633%2F01408633%2Fnorm%2Fthumbs%2F01408633.n_1_500x500.png.jpg%3F2023020522&w=640&q=75", "Пакеты для мусора «Hit» 60 литров, 20 шт", 1.17m, "Условия и сроки хранения - срок годности 3 года. Дата изготовления указана на упаковке", null, 0.0 },
                    { 50, 26, 1408633, null, "Производитель - ЗАО «Олтекс С.А.» 142700, Московская обл., Ленинский р-н, г. Видное, Белокаменное ш., вл. 18, Россия.", "https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F1287%2F01511287%2Fnorm%2Fthumbs%2F01511287.n_1_500x500.png.jpg%3F2023020522&w=640&q=75", "Прокладки гигиенические «Ola!» 9 шт", 2.06m, "Условия и сроки хранения - срок годности не ограничен", null, 0.0 },
                    { 51, 27, 1253553, "мясо и субпродукты (в том числе говядина и ягненок минимум 4%), злаки, таурин, витамины, минеральные вещества.", "Это сбалансированный рацион, приготовленный именно так, как любит Ваша кошка. Аппетитное рагу с говядиной и ягненком в густом ароматном соусе подарит Вашей любимице настоящее удовольствие. Кроме того, рацион Whiskas® содержит все необходимое, чтобы еда Вашей кошки была не только вкусной, но и полезной. Производитель - ООО \"Марс\" 142800, Московская обл., г.о. Ступино, г. Ступино, ул. Ситенка, д. 12, Россия.", "https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F3553%2F01253553%2Fnorm%2Fthumbs%2F01253553.n_1_500x500.png.jpg%3F2023020523&w=640&q=75", "Корм для кошек «Whiskas» Рагу с говядиной и ягнёнком, 75 г", 1.13m, "Условия и сроки хранения - дата изготовления и срок годности указаны на упаковке", null, 0.0 },
                    { 52, 27, 998843, "мясо и субпродукты (в том числе говядина), пшеничная мука, продукты животного происхождения, минеральные вещества, витамины, свекловичный жом, подсолнечное масло, метионин, натуральный краситель, загуститель, антиоксиданты - незаменимая аминокислота для собак.", "Для взрослых собак содержит все, что нужно питомцам старше года. Наш рацион оптимально сбалансирован и насыщен необходимыми витаминами и минералами. И, конечно же, мясные кусочки в соусе такие вкусные, что нос оближешь! Производитель - ООО «Марс» 142800, Московская обл., г.о. Ступино, г. Ступино, ул. Ситенка, д. 12, Россия.", "https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F8843%2F00998843%2Fnorm%2Fthumbs%2F00998843.n_1_500x500.png.jpg%3F2023020523&w=640&q=75", "Корм для собак «Pedigree» говядина в соусе, 85 г", 1.23m, "Условия и сроки хранения - хранить при температуре от +4 °С до +35 °С и относительной влажности воздуха не более 75%. Срок годности и дата изготовления указаны на упаковк", null, 0.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddedProducts_ProductId",
                table: "AddedProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AddedProducts_ShopCartId",
                table: "AddedProducts",
                column: "ShopCartId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteProducts_ProductId",
                table: "FavouriteProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteProducts_UserId",
                table: "FavouriteProducts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShopCartId",
                table: "Orders",
                column: "ShopCartId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopCarts_UserId",
                table: "ShopCarts",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddedProducts");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "FavouriteProducts");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ShopCarts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
