using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static Diplom.Models.Shopcart;

namespace Diplom.Models
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Notification> Notifications { get; set; } = default!;
        public DbSet<Category> Categories { get; set; } = default!;
        public DbSet<Shopcart> ShopCarts { get; set; } = default!;
        public DbSet<Product> Products { get; set; } = default!;
        public DbSet<FavouriteProduct> FavouriteProducts { get; set; } = default!;
        public DbSet<AddedProduct> AddedProducts { get; set; } = default!;
        public DbSet<Order> Orders { get; set; } = default!;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Order>().HasOne(u => u.User).WithMany(x => x.Orders).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<User>().Property("PaymentMethod").HasDefaultValue("card");
            modelBuilder.Entity<Category>().HasData(new List<Category>()
            {
                new Category { Id = 1,Name="Вы уже заказывали",SideUrl="/categories/zakazivali.webp", MainUrl="https://api.yamigom.by/storage/publicImages/MqDVYYrIrlparST5Gt0Nn3YUG7v0146Z5Spyn7uX.jpg"},
                new Category { Id = 2,Name="Готовая еда",SideUrl="/categories/complete.webp", MainUrl="https://api.yamigom.by/storage/publicImages/WKJXwZoyzrw3qJtXxQarljJtwGcGAs81IZ2oVKkM.jpg"},
                new Category { Id = 3,Name="Молочное и яйца",SideUrl="/categories/milk.webp", MainUrl="https://api.yamigom.by/storage/publicImages/v1Q6YSq0weZcHvefU3fiV1oFfW6pHrnTcFB8tlBT.jpg"},
                new Category { Id = 4,Name="Сыр",SideUrl="/categories/cheese.webp", MainUrl="https://api.yamigom.by/storage/publicImages/bD1WNK2YuMweU2OGi7Mu7cfRA1a5ynIsFBvTCniy.jpg"},
                new Category { Id = 5,Name="Овощи и фрукты",SideUrl="/categories/fruit.webp", MainUrl="https://api.yamigom.by/storage/publicImages/meQLS9NwXWcNBQtFUyY0PclM8sALbAQy6tpaFGgD.jpg"},

                new Category { Id = 6,Name="Хлеб и выпечка",SideUrl="/categories/bread.webp",MainUrl="https://api.yamigom.by/storage/publicImages/ETzCmQCm7cXmgKYaP1tO8M4kBDucCfjpv9WIkX0V.jpg"},
                new Category { Id = 7,Name="Вода и напитки",SideUrl="/categories/water.webp", MainUrl="https://api.yamigom.by/storage/publicImages/kvyuaDIJBpWcedxMmbCYjaMl6rQrJXOJkxmzsW5I.jpg"},
                new Category { Id = 8,Name="Мясо и птица",SideUrl="/categories/meat.webp", MainUrl="https://api.yamigom.by/storage/publicImages/tleOxOl1xlOrgfnOyvr2ykbw6m0unK9bDAx1OOcD.jpg"},
                new Category { Id = 9,Name="Рыба и дары моря",SideUrl="/categories/fish.webp", MainUrl="https://api.yamigom.by/storage/publicImages/ExKV5jIRkkSIGAsVvDY0pDNzc8gAjUWXPUHqt1za.jpg"},
                new Category { Id = 10,Name="Колбасы, сосиски, паштеты",SideUrl="/categories/sosiges.webp", MainUrl="https://api.yamigom.by/storage/publicImages/R9UhKFQcShn2tpocMqir8A3U3c9vwcH0N2aBMknT.jpg"},

                new Category { Id = 11,Name="Морозилка",SideUrl="/categories/moroz.webp",MainUrl="https://api.yamigom.by/storage/publicImages/TibVKrJLYIgbGGshi7ysQ9F3JqFEG9bE38yfT85Q.jpg"},
                new Category { Id = 12,Name="Закатки и консервы",SideUrl="/categories/zakat.webp", MainUrl="https://api.yamigom.by/storage/publicImages/hx6hSQSCGXZCl87LwjvIqxWPqkyFuiSzdYuQAvzV.jpg"},
                new Category { Id = 13,Name="Масло и соусы",SideUrl="/categories/oil.webp", MainUrl="https://api.yamigom.by/storage/publicImages/9WxU31mjSk6gINY9zVDa562ftaJthQL1mk8xBXuk.jpg"},
                new Category { Id = 14,Name="Соль, сахар, специи",SideUrl="/categories/salt.webp", MainUrl="https://api.yamigom.by/storage/publicImages/hdnyuBZigIG0EkYJJGp9LOoBQNdeZeMFA9aJKHaN.jpg"},
                new Category { Id = 15,Name="Макароны, крупа и мука",SideUrl="/categories/flour.webp", MainUrl="https://api.yamigom.by/storage/publicImages/WnVBykuFNwluGI3SNrybOSY5WZag0ole6uobM83k.jpg"},
                new Category { Id = 16,Name="Почти готово",SideUrl="/categories/bitcomplete.webp", MainUrl="https://api.yamigom.by/storage/publicImages/1lcxPoJdeDrtjuFdqikoIpkglF3jcKnLiMqX0Bf3.jpg"},

                new Category { Id = 17,Name="Чай, кофе, какао",SideUrl="/categories/tea.webp", MainUrl="https://api.yamigom.by/storage/publicImages/BVAPW56LCO3phz0PM6qlXab9Mf8XVX5hegUimeUE.jpg"},
                new Category { Id = 18,Name="Сладости",SideUrl="/categories/sweat.webp", MainUrl="https://api.yamigom.by/storage/publicImages/l9nvXokkGKYEsrdjPk0Bkk5GIiCnBGxjUUN8m6VP.jpg"},
                new Category { Id = 19,Name="Мороженое",SideUrl="/categories/ice.webp", MainUrl="https://api.yamigom.by/storage/publicImages/CrHGJPpzhpz4by3gnhaQfuk4HvP76qeUb9CYejZj.jpg"},
                new Category { Id = 20,Name="Чипсы, снэки и сухарики",SideUrl="/categories/snaki.webp", MainUrl="https://api.yamigom.by/storage/publicImages/mPx0lgXPXprTXwN0ShAzgi02gQpFExBjMimHIo2K.jpg"},
                new Category { Id = 21,Name="Орехи и сухофрукты",SideUrl="/categories/oreh.webp", MainUrl="https://api.yamigom.by/storage/publicImages/UrwaTiHXeCAyjps1sS9G4gPxgSf55rF4VEFfqIl7.jpg"},
                new Category { Id = 22,Name="Здоровое питание",SideUrl="/categories/healthy.webp", MainUrl="https://api.yamigom.by/storage/publicImages/mrQyvhsu27cCZFZslPVoY4qEZizIUXrNBPG76fEC.jpg"},

                new Category { Id = 23,Name="Детское питание",SideUrl="/categories/babyfood.webp", MainUrl="https://api.yamigom.by/storage/publicImages/PdTosFSmyZClbO9reHntDI4Ufo53XcuM3eOfDkll.jpg"},
                new Category { Id = 24,Name="Уход за детьми",SideUrl="/categories/baby.webp", MainUrl="https://api.yamigom.by/storage/publicImages/O4IHCrLbM410iNvllnb4IhTHN6HfTE6uRX4saP6r.jpg"},
                new Category { Id = 25,Name="Косметика и личная гигиена",SideUrl="/categories/cosmetic.webp", MainUrl="https://api.yamigom.by/storage/publicImages/FOhJDdguwPLjt2KYI81DjAqbP4LegFZyDo9zWzs5.jpg"},
                new Category { Id = 26,Name="Для дома",SideUrl="/categories/home.webp", MainUrl="https://api.yamigom.by/storage/publicImages/ursVMi4PW9ROF1JtKSQ24kKdYZQe1QYQQKhDtVCb.jpg"},
                new Category { Id = 27,Name="Для животных",SideUrl="/categories/animal.webp", MainUrl="https://api.yamigom.by/storage/publicImages/Vro7QpFoqq8jtmiJbiQ0gg7oZvelL0erwtnuUAaQ.jpg"},
                new Category { Id = 28,Name="Полезные мелочи",SideUrl="/categories/meloch.webp", MainUrl="https://api.yamigom.by/storage/publicImages/1fj3pnXzRlzxodEkYm7XxIX65DkPajGNln2iVWUg.jpg"}
            });
            
            modelBuilder.Entity<Product>().HasData(new List<Product>
            {
                new Product{ 
                    Id = 1,
                    Code=1256381,
                    Composition="цыпленок-бройлер филе замороженное, хлеб пшеничный, свинина шпик замороженный, яйцо куриное, лук репчатый, соль, приправа Селянская (сушеные овощи (чеснок), специи (кориандр), тмин, перец черный, лавровый лист)). Может содержать следовые количества компонентов, используемых в производстве других продуктов (горчица, яйца, злаки, содержащие глютен, молоко (в том числе лактоза) и продукты их переработки.",
                    Description="ФЕРМЕРСКИЙ ПРОДУКТ. Фермерское хозяйство «Вясковыя прысмаки». Кулинарный полуфабрикат из мяса птицы рубленый. Производитель - Крестьянское фермерское хозяйство «Вясковые прысмаки», 220099, г. Минск, ул. Ландера, 22, Республика Беларусь.",
                    Name="Фрикадельки «Фермерские» замороженные, 350г",
                    MainUrl="https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F6381%2F01256381%2Fnorm%2Fthumbs%2F01256381.n_1_500x500.png.jpg%3F2023020517&w=640&q=75",
                    Price=14.91M,
                    ShelfLife="Условия и сроки хранения - срок годности 90 суток при температуре хранения не выше минус 18 °С",
                    Weight=0.35,
                    CategoryId=2                    
                },
                new Product{
                    Id = 2,
                    Code=1727772,
                    Composition="свинина котлетное мясо, цыпленок-бройлер, филе охл, свинина шпик, вода питьевая, пшеничная клетчатка, соль пищевая йодированная (соль поваренная пищевая, йодат калия (м.д. йода 40+-15) мкг/г), чеснок свежий очищенный, приправа кориандр молотый, оболочка искусственная, приправа перец черный молотый, приправа тмин молотый.",
                    Description="Производитель - ЗАО \"Интернет-магазин Евроопт\", Минская обл., Минский р-н, Щомыслицкий с/с, Западный п/у, ТЭЦ-4, каб.229, Республика Беларусь",
                    Name="Полуфабрикат Колбаса «Сочная», замороженный, 600г",
                    MainUrl="https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F7772%2F01727772%2Fnorm%2Fthumbs%2F01727772.n_1_500x500.png.jpg%3F2023020517&w=640&q=75",
                    Price=14.15M,
                    ShelfLife="Условия и сроки хранения - хранить при t не выше - 10 °С. Срок хранения в течение: 720 часов",
                    Weight=0.6,
                    CategoryId=2
                },

                 new Product{
                    Id = 3,
                    Code=1344717,
                    Description="Производитель - ПУП «Птицефабрика Оршанская» 211035, Витебская обл., Оршанский р-н, аг. Бабиничи, Республика Беларусь.",
                    Name="Яйцо куриное цветное, С1, 10 шт, 590г",
                    MainUrl="https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F4717%2F01344717%2Fnorm%2Fthumbs%2F01344717.n_1_500x500.png.jpg%3F2023020517&w=640&q=75",
                    Price=4.69M,
                    ShelfLife="Условия и сроки хранения - срок годности 120 суток при температуре хранения от 0°С до -2°С, 25 суток при температуре хранения не выше +20°С",
                    Weight=0.59,
                    CategoryId=3
                },
                new Product{
                    Id = 4,
                    Code=638603,
                    Composition="молоко нормализованное.",
                    Description="Производитель - ГП «Молочный гостинец» 220075, г. Минск, пр-т. Партизанский 170, Беларусь.",
                    Name="Молоко «Молочный гостинец» ультрапастеризованное, 3.2%, 200 мл",
                    MainUrl="https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F8603%2F00638603%2Fnorm%2Fthumbs%2F00638603.n_1_500x500.png.jpg%3F2023020517&w=640&q=75",
                    Price=3.5M,
                    ShelfLife="Условия и сроки хранения - хранить при t не выше - 10 °С. Срок хранения в течение: 720 часов",
                    Weight=0.2,
                    CategoryId=3
                },

                 new Product{
                    Id = 5,
                    Code=855382,
                    Composition="молоко коровье нормализованное пастеризованное, закваска на основе молочнокислых и термофильных бактерий, соль поваренная пищевая выварочная (содержит агент антислеживающий ферроцианид калия), консервант нитрат натрия, краситель аннато, уплотнитель хлорид кальция, ферментный препарат животного происхождения: пепсин, химозин.",
                    Description="Фасованный. Слайсерная нарезка. Без ГМО. Упакован в газовой среде. Производитель - ОАО «Савушкин продукт», 274028, г. Брест, ул. Янки Купалы, 118, Республика Беларусь.",
                    Name="Сыр полутвёрдый «Брест-Литовск» российский, 50%, 150 г",
                    MainUrl="https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F5382%2F00855382%2Fnorm%2Fthumbs%2F00855382.n_1_500x500.png.jpg%3F2023020517&w=640&q=75",
                    Price=24.4M,
                    ShelfLife="Условия и сроки хранения - хранить при температуре от 0 °C до +10 °C и относительной влажности воздуха 90%. После вскрытия упаковки хранить продукт при температуре от +2 °C до +6 °C. Срок годности и дата изготовления указаны на упаковке",
                    Weight=0.15,
                    CategoryId=4
                },
                new Product{
                    Id = 6,
                    Code=822168,
                    Composition="молоко нормализованное пастеризованное, соль (содержит агент антислеживающий Е536), уплотнитель-хлорид кальция, закваска на основе молочноуислых мезофильных и термофильных микроаорганизмов, молокосвертывающий ферментный препарат микробного происхождения, комплексная пищевая добавка, краситель пищевой (сахар, вода, хлорид, натрия, казеинат кальция, подсолнечное масло, краситель бета-каротин, антиокислитель: токоферолы, эмульгатор; лецитины).",
                    Description="С массовой долей жира в сухом веществе 45%. Упаковано в газовой среде. Производитель - СООО «Белсыр» 247710, Гомельская обл., г. Калинковичи, ул. Советская, д. 7, РБ.",
                    Name="Сыр фасованный «Edam», 180 г",
                    MainUrl="https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F2168%2F00822168%2Fnorm%2Fthumbs%2F00822168.n_1_500x500.png.jpg%3F2023020517&w=640&q=75",
                    Price=21.61M,
                    ShelfLife="Условия и сроки хранения - хранить при t от -4°C до +6°С и относительной влажности воздуха 80-85%. Дата изготовления и срок годности указаны на упаковке",
                    Weight=0.18,
                    CategoryId=4
                },

                new Product{
                    Id = 7,
                    Code=1258394,
                    Description="Производитель - Джининг Греенстреам Фрюитс энд Вегетаблес Ко., Лтд Флоор 10, Блок С, Кюидю бюилдинг, Ренченг Авенюе, Джининг, Шандонг, Китай.",
                    Name="Чеснок, 400 г",
                    MainUrl="https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F8394%2F01258394%2Fnorm%2Fthumbs%2F01258394.n_1_500x500.png.jpg%3F2023020517&w=640&q=75",
                    Price=5.63M,
                    ShelfLife="Условия и сроки хранения - хранить при температуре от +1°С до +3°С и относительной влажности воздуха 85-90%. Срок годности 90 суток. Дата упаковывания указана на стикере",
                    Weight=0.4,
                    CategoryId=5
                },
                new Product{
                    Id = 8,
                    Code=1248939,
                    Description="Производитель - ООО «Овощи ставрополье», 357315, Ставропольский край, Кировский р-н, ст.Марьинская, ул. Садовая, д. 1 «В», Россия.",
                    Name="Томат черри, 250 г",
                    MainUrl="https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F8939%2F01248939%2Fnorm%2Fthumbs%2F01248939.n_1_500x500.png.jpg%3F2023020518&w=640&q=75",
                    Price=28.36M,
                    ShelfLife="Условия и сроки хранения - хранить при t +2°С до +16°С и относительной влажности воздуха от 85% до 90%. Срок годности и дата изготовления указаны на упаковке",
                    Weight=0.25,
                    CategoryId=5
                },

                new Product{
                    Id = 9,
                    Code=1257517,
                    Composition="мука пшеничная в/с, вода питьевая, сахар, масло подсолнечное рафинированное дезодорированное, соль йодированная, дрожжи хлебопекарные прессованные.",
                    Description="Производитель - КУП «Минскхлебпром» 220103, г. Минск, ул. Калиновского, 4, Хлебозавод № 5, Республика Беларусь",
                    Name="Батон «Минский» мини, 250 г",
                    MainUrl="https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F7517%2F01257517%2Fnorm%2Fthumbs%2F01257517.n_1_500x500.png.jpg%3F2023020518&w=640&q=75",
                    Price=2.8M,
                    ShelfLife="Условия и сроки хранения - срок годности 5 суток с даты изготовления при температуре хранения не ниже +6°С и относительной влажности воздуха не более 75%. Дата изготовления указана на упаковке",
                    Weight=0.25,
                    CategoryId=6
                },
                new Product{
                    Id = 10,
                    Code=560208,
                    Composition="мука ржаная хлебопекарная сеяная, мука пшеничная первого сорта, солод ржаной сухой, соль поваренная пищевая йодированная (калий йодноватокислый), смесь сухая хлебопекарная Ржаная новая (мука экструзионная ржаная, солод ржаной неферментированный, ферментный препарат), пюре картофельное сухое (картофель свежий, стабилизатор: моно-и диглицериды жирных кислот), экстракт солодовый ячменный светлый охмеленный, дрожжи прессованные Столичные Люкс, экстракт люцерны, экстракт стевии концентрированный, вода питьева.",
                    Description="Производитель - КУП «Минскхлебпром», 220088, Хлебозавод «Автомат», г. Минск, ул. Слесарная, 41, Республика Беларусь.",
                    Name="Хлеб «Водар» светлый, нарезанный, 430 г",
                    MainUrl="https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F0208%2F00560208%2Fnorm%2Fthumbs%2F00560208.n_1_500x500.png.jpg%3F2023020518&w=640&q=75",
                    Price=2.53M,
                    ShelfLife="Условия и сроки хранения - срок годности 4 суток с даты изготовления при температуре хранения не ниже +6°С и относительной влажности воздуха не более 75%. Дата изготовления указана на упаковке",
                    Weight=0.43,
                    CategoryId=6
                },

                new Product{
                    Id = 11,
                    Code=12103,
                    Composition="вода, сахар, краситель сахарный колер IV, регулятор кислотности ортофосфорная кислота, натуральные ароматизаторы, кофеин.",
                    Description="Coca-Cola – один из самых популярных безалкогольных напитков в истории, а также один из наиболее узнаваемых брендов в мире. Coca-Cola была создана в 1886 году в Атланте доктором Джоном С. Пэмбертоном и продавалась как разливной напиток на основе сиропа Coca-Cola и газированной воды. Сегодня неповторимый вкус Coca-Cola Classic знаком миллионам людей по всему миру. Она освежает и наполняет энергией, оставляя приятное пряное послевкусие. Производитель - Унитарное предприятие «Кока-Кола Бевриджиз Белоруссия». Юридический адрес: 223056, Минский р-н, д. Колядичи, д. 147/2. Адрес производства: 223056, Минский р-н, д. Колядичи, д. 147, Беларусь.",
                    Name="Напиток газированный «Coca-Cola», 330 мл",
                    MainUrl="https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F2103%2F00012103%2Fnorm%2Fthumbs%2F00012103.n_1_500x500.png.jpg%3F2023020518&w=640&q=75",
                    Price=3.82M,
                    ShelfLife="Условия и сроки хранения - хранить при температуре от 0°С до +30°C. Открытую банку хранить в холодильнике, употреблять в течении 6 часов",
                    Weight=0.33,
                    CategoryId=7
                },
                new Product{
                    Id = 12,
                    Code=1273776,
                    Composition="Вода, сахар, комплексная пищевая добавка «Подкисляющий компонент» (краситель Е150d, регулятор кислотности Е338, кофеин), ароматизаторы натуральные (в составе стабилизатор гуммиарабик,) подсластитель сукралоза ( в составе вода, подсластитель сукралоза, консерванты: бензоат натрия и сорбат калия, регуляторы кислотности: Е300 и Е331(iii)), регулятор кислотности Е300, ароматизатор натуральный, подсластитель ацесульфам калия.",
                    Description="Производитель - ОАО «Лидское пиво», 231300, Гродненская область, г. Лида, ул. Мицкевича 32, Республика Беларусь.",
                    Name="Напиток газированный «Pepsi», 330 мл",
                    MainUrl="https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F3776%2F01273776%2Fnorm%2Fthumbs%2F01273776.n_1_500x500.png.jpg%3F2023020518&w=640&q=75",
                    Price=3.63M,
                    ShelfLife="Условия и сроки хранения - хранить при температуре от 0 °С до 22 °С в затемненных, вентилируемых, не имеющих посторонних запахов помещениях. Срок годности и дата изготовления указаны на упаковке",
                    Weight=0.33,
                    CategoryId=7
                },

                 new Product{
                    Id = 13,
                    Code=1256722,
                    Composition="мясная мякоть шейной и/или шейно-подлопаточной частей.",
                    Description="Полуфабрикат мясной натуральный из свинины порционный бескостный. Упаковано под вакуумом. Производитель - ОАО «Брестский мясокомбинат» г. Брест, ул. Писателя Смирнова, 4, Республика Беларусь.",
                    Name="Полуфабрикат «Стейк из шейки» охлажденный, 0.5 кг",
                    MainUrl="https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F6722%2F01256722%2Fnorm%2Fthumbs%2F01256722.n_1_500x500.png.jpg%3F2023020519&w=640&q=75",
                    Price=23.72M,
                    ShelfLife="Условия и сроки хранения - годнен в течение 15 суток с даты изготовления при температуре воздуха от 0°С до плюс 6°С. Дата изготовления указана на упаковке",
                    Weight=0.5,
                    CategoryId=8
                },
                new Product{
                    Id = 14,
                    Code=766755,
                    Description="Производитель - ЗАО «Серволюкс Агро» 213136, Могилевская обл, Могилевский р-н, Дашковский с/с, Межисеткий, ул. Фабричная,14, Республика Беларусь",
                    Name="Голень цыпленка-бройлера «Петруха» охлажденная, 750 г",
                    MainUrl="https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F6755%2F00766755%2Fnorm%2Fthumbs%2F00766755.n_1_500x500.png.jpg%3F2023020519&w=640&q=75",
                    Price=7.16M,
                    ShelfLife="Условия и сроки хранения - срок годности: 9 суток в упакованном виде при температуре хранения от 0°С до +2°С; 48 часов после нарушения целостности упаковки (в пределах общего срока годности) продукт хранить при температуре от 0°С до +2°С",
                    Weight=0.75,
                    CategoryId=8
                },

                 new Product{
                    Id = 15,
                    Code=1647691,
                    Composition="икра русского осетра, комплексно-пищевая добавка Варэкс-11 (пищевая соль, консервант Е200, антиокислитель Е315).",
                    Description="Производитель - ООО РВК \"Раскат\", 414015, г. Астрахань, ул. Дзержинского, 80, РФ.",
                    Name="Икра зернистая «Caviar» осетровая, 56.8г",
                    MainUrl="https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F7691%2F01647691%2Fnorm%2Fthumbs%2F01647691.n_1_500x500.png.jpg%3F2023021218&w=256&q=75",
                    Price=3245.44M,
                    ShelfLife="Условия и сроки хранения - хранить при температуре от -2 до -4°С. Срок хранения и годности не более 12 месяцев с даты изготовления",
                    Weight=0.0568,
                    CategoryId=9
                },
                new Product{
                    Id = 16,
                    Code=429030,
                    Description="Полуфабрикат. Производитель - ООО СП «Санта Бремор», 224025, г. Брест, ул. Катин Бор, 106, Республика Беларусь.",
                    Name="Стейк семги «Санта Бремор» замороженный, 400 г",
                    MainUrl="https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F9030%2F00429030%2Fnorm%2Fthumbs%2F00429030.n_1_500x500.png.jpg%3F2023020519&w=640&q=75",
                    Price=89.6M,
                    ShelfLife="Условия и сроки хранения - хранить при t от -8 °C, 300 суток, от даты изготовления указанной на упаковке",
                    Weight=0.4,
                    CategoryId=9
                },

                new Product{
                    Id = 17,
                    Code=524221,
                    Composition="шпик хребтовый, свинина, говядина, добавка комплексная пищевая для мясной продукции с йодом (соль поваренная пищевая выварочная экстра (содержит агент антислеживающий (ферроцианид калия)), фиксатор окраски (нитрит натрия), йодат калия)), комплексная пищевая добавка (декстроза, специи (чеснок, лук, кориандр), усилитель вкуса и аромата (глутамат натрия 1-замещенный), соль, антиокислитель (аскорбиновая кислота, L-), экстракты специй (паприка, чеснок)), соль поваренная пищевая йодированная (йодат калия, агент антислеживающий (ферроцианид калия)), стартовые культуры (staphylococcus carnosus, lactobacillus curvatus, pediococcus pentosaceus, декстроза).",
                    Description="Колбасное изделие мясное, высшего сорта. Охлажденная, упаковано под вакуумом. Производитель - Филиал «Беламит» ЗАО «Серволюкс Агро» 213320, Могилевская обл., Быховский р-н, г. Быхов, ул. Гвардейская, 2а, Республика Беларусь.",
                    Name="Колбаса сырокопченая салями «Мюнхенская», 100 г",
                    MainUrl="https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F4221%2F00524221%2Fnorm%2Fthumbs%2F00524221.n_1_500x500.png.jpg%3F2023020519&w=640&q=75",
                    Price=30.6M,
                    ShelfLife="Условия и сроки хранения - хранить при t от +2 °С до +6 °С и относительной влажности воздуха (75-78)% не более 25 суток с даты изготовления в целой упаковке, при нарушении целостности упаковки - не хранить. Дата изготовления указана на упаковке",
                    Weight=0.1,
                    CategoryId=10
                },
                new Product{
                    Id = 18,
                    Code=719634,
                    Composition="мясные ингредиенты (филе цыплят-бройлеров, мясо цыплят-бройлеров кусковое бескостное, эмульсия из свиной шкурки, жир-сырец свиной), вода питьевая, масло растительное, комплексные пищевые добавки (стабилизаторы: трифосфат калия, полифосфат калия, загустители: ксантановая камедь, гуаровая камедь, декстроза, желирующий агент, каррагинан и его соли, усилитель вкуса и аромата глутамат натрия, ароматизатор «Мясо» антиокислитель изоаскорбат натрия, пряности (кардамон) и их экстракты (кардамон, перец белый), соль поваренная пищевая (антислеживающий агент ферроцианид калия), фиксатор окраски нитрит натрия, йодат калия, животный белок, экстракты пряностей), соль поваренная пищевая йодированная (антислеживающий агент ферроцианид калия), пищевая добавка (краситель кармин).",
                    Description="Изделие колбасное вареное из мяса птицы. Высшего сорта. Охлажденные. Упаковано в модифицированной газовой среде. Производитель - ЗАО «Дзержинский мясокомбинат» 222750, Минская область, Дзержинский р-н, г. Фаниполь, ул. Заводская, 25, Республика Беларусь.",
                    Name="Сосиски «Родныя мясціны» из куриного филе, 350 г",
                    MainUrl="https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F9634%2F00719634%2Fnorm%2Fthumbs%2F00719634.n_1_500x500.png.jpg%3F2023020519&w=640&q=75",
                    Price=13.34M,
                    ShelfLife="Условия и сроки хранения - срок годности 30 суток с даты изготовления в целой упаковке при t (4±2)°С и относительной влажности воздуха (75±5)%. Дата изготовления указана на упаковке",
                    Weight=0.35,
                    CategoryId=10
                },

                 new Product{
                    Id = 19,
                    Code=732852,
                    Composition="грибы шампиньоны резанные.",
                    Description="Повторное замораживание не допускается. Производитель - ООО «РПК» г. Санкт-Петербург, 196603, г. Пушкин, ул. Саперная, дом 79/1, литер Е, Россия.",
                    Name="Шампиньоны резанные быстрозамороженные «Свой урожай», 300 г",
                    MainUrl="https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F2852%2F00732852%2Fnorm%2Fthumbs%2F00732852.n_1_500x500.png.jpg%3F2023020519&w=640&q=75",
                    Price=8.3M,
                    ShelfLife="Условия и сроки хранения - хранить при температуре не выше -18°C и относительной влажности воздуха не более 95%. Срок годности 24 месяца. Дата изготовления указана на упаковке",
                    Weight=0.3,
                    CategoryId=11
                },
                new Product{
                    Id = 20,
                    Code=1504152,
                    Composition="грибы опята.",
                    Description="Производитель - ООО «Русберри Лайн» 162840, Вологодская обл., Устюженский р-н, г. Устюжна, ул. Володарского, 77, Россия.",
                    Name="Опята Намеко «Rusberry» замороженные, 300 г",
                    MainUrl="https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F4152%2F01504152%2Fnorm%2Fthumbs%2F01504152.n_1_500x500.png.jpg%3F2023020519&w=640&q=75",
                    Price=21.45M,
                    ShelfLife="Условия и сроки хранения - срок годности 18 месяцев с даты изготовления при температуре хранения не выше -18°С Дата изготовления указана на упаковке",
                    Weight=0.3,
                    CategoryId=11
                },

                new Product{
                    Id = 21,
                    Code=625098,
                    Composition="тунец, соль, вода",
                    Description="Стерилизованные. 100% натуральный продукт. Производитель - С.П.А. Интернэшнл Фуд Груп Ко ЛТД, Донтоом, 73150, Нахонпатхом, Таиланд",
                    Name="Консервы рыбные «Morrel» тунец в собственном соку, рубленный, 185 г",
                    MainUrl="https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F5098%2F00625098%2Fnorm%2Fthumbs%2F00625098.n_1_500x500.png.jpg%3F2023020519&w=640&q=75",
                    Price=23.51M,
                    ShelfLife="Условия и сроки хранения - хранить при t от 0°С до +25°С и относительной влажности воздуха не более 75%. После вскрытия хранить при t от 0°С до +4°С не более 24 часов. Срок годности – и дата изготовления указаны на упаковке",
                    Weight=0.185,
                    CategoryId=12
                },
                new Product{
                    Id = 22,
                    Code=373878,
                    Composition="огурцы, маринад (вода питьевая, сахар, соль, регулятор кислотности - уксусная кислота, смесь подсластителей: ацесульфам калия, сукралоза), стебель укропа сушенный, лук репчатый сушенный, чеснок сушенный, перец черный горошек, перец душистый горошек, горчичное семя, хрен-корень сушенный, лавровый лист.",
                    Description="Консервы пастеризованные. Производитель - ООО «Техада» 352040, Краснодарский край, ст. Павловская, ул. Хлебная, д. 4, Россия.",
                    Name="Огурцы консервированные «Green Rey» маринованные, 670 г",
                    MainUrl="https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F3878%2F00373878%2Fnorm%2Fthumbs%2F00373878.n_1_500x500.png.jpg%3F2023020520&w=640&q=75",
                    Price=6.87M,
                    ShelfLife="Условия и сроки хранения - хранить при температуре от 0 °C до +25 °C и относительной влажности воздуха не более 75%. Срок годности 3 года с даты изготовления, указанной на упаковке",
                    Weight=0.67,
                    CategoryId=12
                },

                 new Product{
                    Id = 23,
                    Code=1280492,
                    Composition="вода, паста томатная, уксус натуральный, соль, экстракты специй (содержат сельдерей).",
                    Description="Производитель - ООО «Петропродукт-Отрадное» 187330, Ленинградская обл., Кировский р-н, г. Отрадное, ул. Железнодорожная, д.1, Россия",
                    Name="Кетчуп «Heinz» томатный, 320 г",
                    MainUrl="https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F0492%2F01280492%2Fnorm%2Fthumbs%2F01280492.n_1_500x500.png.jpg%3F2023020520&w=640&q=75",
                    Price=12.97M,
                    ShelfLife="Условия и сроки хранения - срок годности 12 месяцев с даты изготовления при температуре хранения от 0 °С до +25 °С и относительной влажности воздуха не более 75%. Дата изготовления указана на упаковке",
                    Weight=0.32,
                    CategoryId=13
                },
                new Product{
                    Id = 24,
                    Code=202510,
                    Composition="масло подсолнечное, вода, яичный желток, сахар, соль, уксус из пищевого сырья, яйцо перепелиное маринованное, сок лимонный, масло горчичное, пищевая добавка консервант, сорбиновая кислота, провитамин А.",
                    Description="Производитель - ЗАО «Эссен Продакшн АГ», 445130, Россия, Самарская обл., Ставропольский р-н, с. Васильевка, ул. Коллективная, д. 54а.",
                    Name="Майонез «Махеевъ» с перепелиным яйцом, 380 г",
                    MainUrl="https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F2510%2F00202510%2Fnorm%2Fthumbs%2F00202510.n_1_500x500.png.jpg%3F2023020520&w=640&q=75",
                    Price=9.18M,
                    ShelfLife="Условия и сроки хранения - хранить при t от 0 до +14 °C, 180 суток; свыше +14 °C до +20 °C - 90 суток",
                    Weight=0.38,
                    CategoryId=13
                },

                new Product{
                    Id = 25,
                    Code=17355,
                    Description="Производитель - ОАО «Слуцкий сахарорафинадный комбинат» 223610, г. Слуцк, ул. Головащенко, д. 6, Беларусь.",
                    Name="Сахар свекловичный «Слуцкий» ТС2, песок, 1 кг",
                    MainUrl="https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F7355%2F00017355%2Fnorm%2Fthumbs%2F00017355.n_1_500x500.png.jpg%3F2023020520&w=640&q=75",
                    Price=2.61M,
                    ShelfLife="Условия и сроки хранения - хранить при t воздуха не выше +40°C. Дата изготовления и срок годности указаны на упаковке",
                    Weight=1,
                    CategoryId=14
                },
                new Product{
                    Id = 26,
                    Code=141061,
                    Composition="соль поваренная пищевая выварочная экстра Полесье, соль каменная поваренная пищевая, агент антислеживающий Е536",
                    Description="Помол: до 1.0 мм - 70%, свыше 2.5 мм - 5% Производитель - Концерн «Белгоспищепром» ОАО «Мозырьсоль», 247760, Гомельская обл., г. Мозырь, Республика Беларусь.",
                    Name="Соль пищевая «Мозырьсоль» Белорусская, поваренная, 1 кг",
                    MainUrl="https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F1061%2F00141061%2Fnorm%2Fthumbs%2F00141061.n_1_500x500.png.jpg%3F2023020520&w=640&q=75",
                    Price=0.71M,
                    ShelfLife="Условия и сроки хранения - Хранить в упаковке изготовителя в сухом месте 2 года",
                    Weight=1,
                    CategoryId=14
                },

                 new Product{
                    Id = 27,
                    Code=92758,
                    Description="Производитель - ОАО «Барановичский комбинат хлебопродуктов», 225406, г. Барановичи, ул. 50 лет БССР, 21, Республика Беларусь.",
                    Name="Мука пшеничная «Гаспадар» М 54-28, высший сорт, 1 кг",
                    MainUrl="https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F2758%2F00092758%2Fnorm%2Fthumbs%2F00092758.n_1_500x500.png.jpg%3F2023020520&w=640&q=75",
                    Price=1.38M,
                    ShelfLife="Условия и сроки хранения - хранить при t не выше +25 °С и относительной влажности воздуха не более 75 %, срок хранения 12 месяцев",
                    Weight=1,
                    CategoryId=15
                },
                new Product{
                    Id = 28,
                    Code=592267,
                    Composition="мука пшеничная сорт крупка марка МКР-28, вода питьевая.",
                    Description="Группа Б, сорт крупка. Производитель - ОАО «Лидахлебопродукт», 231300, Гродненская обл., г. Лида, ул. Булата, 1, Республика Беларусь.",
                    Name="Макаронные изделия «Ligrano» рожки обыкновенные, 900 г",
                    MainUrl="https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F2267%2F00592267%2Fnorm%2Fthumbs%2F00592267.n_1_500x500.png.jpg%3F2023020520&w=640&q=75",
                    Price=2.14M,
                    ShelfLife="Условия и сроки хранения - срок годности 24 месяца. Дата изготовления указана на упаковке. Хранить при t не более +30°С и относительной влажности воздуха не более 70%",
                    Weight=0.9,
                    CategoryId=15
                },

                new Product{
                    Id = 29,
                    Code=406193,
                    Composition="зерновые продукты (76,1%) (пшеница (содержит глютен) (50,7%), кукуруза (25,4%)), сахар, какао-порошок алкализованный (4,7%), патока, масло подсолнечное, соль, регулятор кислотности (фосфаты натрия), карбонат кальция.",
                    Description="Готовый завтрак Хрутка Шоколадные колечки- это именно то, что вам нужно! Добавьте молоко, йогурт, кефир или сок и ваше утро начнется со вкусного разнообразного завтрака для всех и каждого! В состав готового завтрака Хрутка Медовые хлопья входят цельные злаки, которые помогают обеспечить организм важными питательными веществами сложными углеводами, белками и минеральными веществами. Внешняя оболочка цельных злаков (отруби) содержит пищевые волокна, которые способствуют нормальному пищеварению. Производитель - ООО «Сириал Партнерс Рус», 115054, Россия, г. Москва, Павелецкая пл., д. 2, стр. 1.",
                    Name="Готовый завтрак «Хрутка» шоколадные колечки, 210 г",
                    MainUrl="https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F6193%2F00406193%2Fnorm%2Fthumbs%2F00406193.n_1_500x500.png.jpg%3F2023020520&w=640&q=75",
                    Price=12.33M,
                    ShelfLife="Условия и сроки хранения - срок годности: 360 дней при до 20 C° хранить в сухом, прохладном месте",
                    Weight=0.21,
                    CategoryId=16
                },
                new Product{
                    Id = 30,
                    Code=55540,
                    Composition="сахар, масло подсолнечное рафинированное дезодорированное, крупа рисовая, сухой молочный продукт, мука пшеничная, крахмал кукурузный, крупа овсяная, соль йодированная, эмульгатор (соевый лецитин).",
                    Description="Производитель - КУП «Витебский кондитерский комбинат «Витьба», 210038 г. Витебск, ул. Короткевича, 3",
                    Name="Сухой завтрак «Витьба» Подушечки, с молочной начинкой, 250 г",
                    MainUrl="https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F5540%2F00055540%2Fnorm%2Fthumbs%2F00055540.n_1_500x500.png.jpg%3F2023020520&w=640&q=75",
                    Price=10.64M,
                    ShelfLife="Условия и сроки хранения - годен в течении 9 месяцев. Хранить при t не выше +20 °C и относительной влажности воздуха не более 75 %",
                    Weight=0.25,
                    CategoryId=16
                },

                new Product{
                    Id = 31,
                    Code=8033,
                    Description="Натуральный жареный, молотый. Производитель - ООО «НЕП» 188682, Ленинградская область, Всеволожский р-н, пос. им. Свердлова, мкп.1, 15/4, Россия.",
                    Name="Кофе молотый «Жокей» по-восточному, 100 г",
                    MainUrl="https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F8033%2F00008033%2Fnorm%2Fthumbs%2F00008033.n_1_500x500.png.jpg%3F2023020520&w=640&q=75",
                    Price=42.5M,
                    ShelfLife="Условия и сроки хранения - хранить при t не более +20 °C и относительной влажности воздуха не более 75 %",
                    Weight=0.1,
                    CategoryId=17
                },
                new Product{
                    Id = 32,
                    Code=1492894,
                    Composition="чай черный листовой, ароматизатор «клубника, малина, красная смородина», лепестки роз, кусочки клубники, кусочки малины.",
                    Description="Производитель - ЗАО Компания «Май» 141190, г. Фрязино, Московской обл., ул. Озёрная, д. 1а, Россия.",
                    Name="Чай черный «Curtis» Very Berry, 18х1.7 г",
                    MainUrl="https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F2894%2F01492894%2Fnorm%2Fthumbs%2F01492894.n_1_500x500.png.jpg%3F2023020520&w=640&q=75",
                    Price=81.0M,
                    ShelfLife="Условия и сроки хранения - хранить в сухом прохладном месте. Срок годности и дата изготовления указаны на упаковке",
                    Weight=0.03,
                    CategoryId=17
                },


                new Product{
                    Id = 33,
                    Code=1009755,
                    Composition="сахар, масло какао, сыворотка сухая молочная, молоко цельное сухое, миндаль обжаренный дробленый, стружка кокосовая, жир молочный, эмульгаторы (лецитин соевый, Е476), ароматизатор.",
                    Description="Производитель - ООО «Мон'дэлис Русь» 601123, Владимирская обл., Петушинский р-н, г. Покров, ул. Франца Штольверка, д. 10, Россия.",
                    Name="Шоколад «Alpen Gold» белый, миндаль и кокос, 85 г",
                    MainUrl="https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F9755%2F01009755%2Fnorm%2Fthumbs%2F01009755.n_1_500x500.png.jpg%3F2023020520&w=640&q=75",
                    Price=34.94M,
                    ShelfLife="Условия и сроки хранения - хранить при температуре от +15°С до +21°С и относительной влажности воздуха не более 75%. Срок годности и дата изготовления указаны на упаковке",
                    Weight=0.085,
                    CategoryId=18
                },
                new Product{
                    Id = 34,
                    Code=227964,
                    Composition="сахар, сухое цельное молоко, масло какао, тертое какао, эмульгатор: лецитины (СОИ), идентичный натуральному ароматизатор: ванилин; общий сухой остаток какао-продуктов: не менее 30 %, сухой обезжиренный остаток какао-продуктов: не менее 2.5 %, сухие вещества молока: не менее 18 %, молочный жир не менее 4.5 %; общее содержание какао-продуктов (какао) в шоколадной массе: 30 %; начинка: сахар, сухое обезжиренное молоко, растительный жир, молочный жир, эмульгатор: лецитины (СОИ), идентичный натуральному ароматизатор: ванилин. Полное содержание молочных ингредиентов - 33 %, полное содержание какао-ингредиентов - 13 %.",
                    Description="Производитель - ЗАО «Ферреро Руссия» 601211, Владимирская обл., Собинский р-н, с. Ворша, кондитерская фабрика «Ферреро» Россия.",
                    Name="Шоколад «Kinder» молочный, 100 г",
                    MainUrl="https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F7964%2F00227964%2Fnorm%2Fthumbs%2F00227964.n_1_500x500.png.jpg%3F2023020520&w=640&q=75",
                    Price=65.1M,
                    ShelfLife="Условия и сроки хранения - хранить в сухом прохладном месте. Срок годности и дата изготовления указаны на упаковке",
                    Weight=0.1,
                    CategoryId=18
                },

                 new Product{
                    Id = 35,
                    Code=561302,
                    Composition="вода питьевая, вафельный сахарный рожок (мука пшеничная в/с, вода питьевая, сахар, масло растительное, эмульгатор лецитин (соевый), соль, ароматизатор Ваниль-карамель), молоко цельное сгущенное с сахаром (нормализованное молоко, сахар (сахароза, лактоза)), наполнитель малиновый (сахар, малина, вода питьевая, загуститель пектины, регулятор кислотности лимонная кислота, концентрат из сока черной моркови, ароматизатор), сахар, глазурь кондитерская (заменитель масла какао (жир растительный (масло пальмовое)), сахарная пудра, какао-порошок, эмульгатор лецитины, ароматизатор Ванильный), масло сливочное, патока, молоко сухое цельное, молоко сухое обезжиренное, стабилизаторы (моно- и диглицериды жирных кислот, камедь рожкового дерева, гуаровая камедь), комплексная пищевая добавка Панна котта (содержит вкусоароматические вещества, антиокислитель кислоту аскорбиновую). Продукт может содержать незначительное количество арахиса, орехов, яичных продуктов. Массовая доля жира в мороженом: 8%.",
                    Description="Производитель - СП «Санта Бремор» ООО, 224025, г. Брест, ул. Катин Бор, 106, Республика Беларусь.",
                    Name="Мороженое «Soletto» сладкая малина, 75 г",
                    MainUrl="https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F1302%2F00561302%2Fnorm%2Fthumbs%2F00561302.n_1_500x500.png.jpg%3F2023020520&w=640&q=75",
                    Price=23.47M,
                    ShelfLife="Условия и сроки хранения - хранить при t не выше -18 °C. Срок годности 12 месяцев. Дата изготовления указана на упаковке",
                    Weight=0.075,
                    CategoryId=19
                },
                new Product{
                    Id = 36,
                    Code=307031,
                    Composition="вода питьевая; печенье сахарное с какао-порошком (мука пшеничная, сахар, масло пальмовое, какао- порошок, крахмал кукурузный, сыворотка молочная сухая, разрыхлитель сода пищевая, эмульгатор лецитин, соль поваренная, ароматизатор идентичный натуральному Шоколад); масло из коровьего молока, сахар-песок, молоко сухое обезжиренное, патока крахмальная (сироп глюкозный); вкусоароматическая паста Ваниль со стручками ванили (глюкозный сироп, ароматизатор Ваниль; вода, сахар, стручки ванил тертые, эмульгаторы: Е472с, Е472d; стабилизатор камедь рожкового дерева); молоко сухое цельное (частично обезжиренное), сыворотка молочная сухая; эмульгатор моно- и диглицериды жирных кислот; стабилизаторы: камедь рожкового дерева, гуаровая камедь, каррагинан, натрийкарбоксиметилцеллюлоза; ароматизатор идентичный натуральному Ваниль, краситель натуральный, бета-каротин. Продукт может содержать незначительное количество арахиса, орехов, яичных продуктов, муки пшеничной.",
                    Description="Пломбир с кусочками ванили и ароматом ванили. Производитель - СООО «Морозпродукт» 222810, Минская обл., Пуховичский р-н, г. Марьина Горка, ул. Октябрьская, д. 133, комн. 5, Республика Беларусь.",
                    Name="Мороженое «Каприз» пломбир ванильный, 95 г",
                    MainUrl="https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F7031%2F00307031%2Fnorm%2Fthumbs%2F00307031.n_1_500x500.png.jpg%3F2023021221&w=256&q=75",
                    Price=20.95M,
                    ShelfLife="Условия и сроки хранения - хранить при t не выше -18 °C. Срок годности 12 месяцев. Дата изготовления указана на упаковке",
                    Weight=0.095,
                    CategoryId=19
                },

                 new Product{
                    Id = 37,
                    Code=1273918,
                    Composition="картофель, растительные масла*, ароматизатор [сахар, соль, порошок молочной сыворотки, вкусоароматические вещества (содержат термический технологический ароматизатор), усилитель вкуса и аромата (глутамат натрия 1-замещенный), специи (содержат белый перец), краситель (экстракт паприки)].",
                    Description="Чипсы LAY'S®, каждая пачка которых изготовлена из специально отобранного картофеля, соответствует самым высоким стандартам качества. Хрустящие, легкие на вкус картофельные чипсы созданы вызвать улыбку на лице каждого человека, ими так приятно делиться с лучшими друзьями. Они несомненно скрасят ваш день! Специально для ценителей мы приготовили хрустящие чипсы LAY'S® со вкусом нежного камчатского краба. Отличное сочетание вкуса краба и золотистых картофельных чипсов подарят вихрь удовольствия! Производитель - ООО «Фрито Лей Мануфактуринг» 142900, Московская обл., г. Кашира, ул. Меженинова, 5, Россия.",
                    Name="Чипсы «Lay's» краб, 81 г",
                    MainUrl="https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F3918%2F01273918%2Fnorm%2Fthumbs%2F01273918.n_1_500x500.png.jpg%3F2023020520&w=640&q=75",
                    Price=25.56M,
                    ShelfLife="Условия и сроки хранения - хранить продукт при температуре воздуха не выше +25°C и относительной влажности воздуха не более 75%. После вскрытия упаковки хранить продукт не более суток при температуре воздуха не выше +25°C и относительной влажности воздуха не более 75%",
                    Weight=0.081,
                    CategoryId=20
                },
                new Product{
                    Id = 38,
                    Code=430852,
                    Composition="мука пшеничная, крупа манная, масло рапсовое, ароматизатор [сухая молочная сыворотка, усилители вкуса и аромата (глутамат натрия 1-замещенный, 5’-гуанилат натрия 2-замещенный, 5’-инозинат натрия 2-замещенный), вкусоароматические вещества, томатный порошок, порошок сухого молока, термический технологический ароматизатор, специи, травы, краситель (экстракт паприки)], сахар, агент антислеживающий (карбонат кальция), карамелизованный сахар, экстракт моркови.",
                    Description="Сухарики ХРУСTEAM Багет Королевский краб — это оригинальные хрустящие снеки с воздушной пористой структурой и пряным вкусом. Из-за своей овальной формы внешне Хрустим похожи на тонко нарезанные ломтики миниатюрного багета. Сухарики Хрусteam приятно хрустят и с легкостью раскусываются. Хрусteam можно употреблять в качестве вкусного и сытного перекуса, легкой закуски к прохладительным напиткам, подавать в качестве гренок к крем-супу, использовать для приготовления знаменитого салата Цезарь. Производитель - ООО «Фрито Лей Мануфактуринг», 142900, Московская обл., г. Кашира, ул. Меженинова, 5, Россия.",
                    Name="Сухарики «Хрусteam» багет, со вкусом королевского краба, 60 г",
                    MainUrl="https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F0852%2F00430852%2Fnorm%2Fthumbs%2F00430852.n_1_500x500.png.jpg%3F2023020520&w=640&q=75",
                    Price=24.83M,
                    ShelfLife="Условия и сроки хранения - хранить продукт при температуре воздуха не выше 25 ?С и относительной влажности воздуха не более 75 %. После вскрытия упаковки хранить продукт не более суток при температуре воздуха не выше 25 ?С и относительной влажности воздуха не более 75 %",
                    Weight=0.06,
                    CategoryId=20
                },

                 new Product{
                    Id = 39,
                    Code=516257,                
                    Description="Производитель - ООО «Маркет Мастер», 222201, РБ, Минская обл., Смолевичский р-н, г. Смолевичи, ул. Промышленная 3.",
                    Name="Миндаль «Econuts» жареный, 70 г",
                    MainUrl="https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F6257%2F00516257%2Fnorm%2Fthumbs%2F00516257.n_1_500x500.png.jpg%3F2023020520&w=640&q=75",
                    Price=43.86M,
                    ShelfLife="Условия и сроки хранения - хранить в сухом прохладном месте не выше 30 C , защищать от воздействия прямых солнечных . лучей. Дата изготовления указана на упаковке",
                    Weight=0.07,
                    CategoryId=21
                },
                new Product{
                    Id = 40,
                    Code=194514,
                    Composition="семена подсолнечника неочищенные, соль поваренная пищевая йодированная содержит антиокислитель ферроцианид калия.",
                    Description="Производитель - ПОДО «Онега», 223050, Минская обл., Минский р-н, а/г Колодищи, ул. Промышленная, 8/1, Беларусь.",
                    Name="Семечки подсолнечника «Рень» с солью, 120 г",
                    MainUrl="https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F4514%2F00194514%2Fnorm%2Fthumbs%2F00194514.n_1_500x500.png.jpg%3F2023020520&w=640&q=75",
                    Price=22.92M,
                    ShelfLife="Условия и сроки хранения - хранить при t не выше +23 °С и относительной влажности воздуха не более 80 %. Срок годности 6 месяцев от даты изготовления",
                    Weight=0.12,
                    CategoryId=21
                },

                 new Product{
                    Id = 41,
                    Code=1012577,
                    Composition="сироп инулина (фибрулина), вода, молоко сухое обезжиренной массовой долей жира 1,5%, какао-порошок обезжиренный (жирность не более 1%), подсластитель - эритрит (Е968), ароматизатор «Ваниль» ароматизатор «Шоколад» лимонная кислота (Е330), комплексная пищевая добавка «Тиксогам S» (смола акации, загуститель ксантановая камедь), подсластитель стевиозид (Е960), консервант - сорбат калия (Е202). Содержит подсластитель эритрит.",
                    Description="Производитель - ООО «Питэко», 606402, Нижегородская обл., Балахнинский р-н, г. Балахна, ул. Энгельса, д. 110, Россия.",
                    Name="Сироп низкокалорийный «Fit Active» шоколад, 300 г",
                    MainUrl="https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F2577%2F01012577%2Fnorm%2Fthumbs%2F01012577.n_1_500x500.png.jpg%3F2023020521&w=640&q=75",
                    Price=36.63M,
                    ShelfLife="Условия и сроки хранения - хранить при температуре не выше +25 °С и относительной влажности воздуха не более 75%. Срок годности 12 месяцев с даты изготовления, указанной на упаковке",
                    Weight=0.3,
                    CategoryId=22
                },
                new Product{
                    Id = 42,
                    Code=890528,
                    Composition="цельные зерна пшеницы, крупа рисовая, продукция соковая (сок черничный концентрированный), патока крахмальная, сушеные измельченные ягоды черники, пищевая добавка сукралоза (подсластитель), ароматизатор пищевая натуральный «Черника»",
                    Description="Производитель - ИП Харламов В.В., 346880, Ростовская область, г. батайк, ул. Революционная 107, Россия.",
                    Name="Хлебцы «Doctor Green» хрустящие с черникой, 80 г",
                    MainUrl="https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F0528%2F00890528%2Fnorm%2Fthumbs%2F00890528.n_1_500x500.png.jpg%3F2023020521&w=640&q=75",
                    Price=19.88M,
                    ShelfLife="Условия и сроки хранения - хранить при температуре до +25°С и относительной влажности воздуха не более 75%. Срок годности: 12 месяцев",
                    Weight=0.08,
                    CategoryId=22
                },

                 new Product{
                    Id = 43,
                    Code=98610,
                    Composition="мука рисовая, витамины (С, Е, РР, пантотеновая кислота, В6, В1, В2, А, фолиевая кислота, D3, биотин, В12), минеральные вещества (железо, цинк, йод). Продукт может содержать следы молока и глютена, т.к. все сухие каши «ФрутоНяня» производятся на одном промышленном оборудовании.",
                    Description="Для питания детей с 4 месяцев. Производитель - ОАО «Прогресс» 389902, г. Липецк, ул. Ангарская, влад. 2, Россия.",
                    Name="Каша сухая безмолочная «Фруто Няня» рисовая гипоаллергенная, 200 г",
                    MainUrl="https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F8610%2F00098610%2Fnorm%2Fthumbs%2F00098610.n_1_500x500.png.jpg%3F2023020522&w=640&q=75",
                    Price=16.55M,
                    ShelfLife="Условия и сроки хранения - невскрытую упаковку следует хранить в сухом прохладном месте, защищнном от прямых солнечных лучей, при t не более +25 °C и относительной влажности не более 75 %. Открытую упаковку хранить в сухом прохладном месте (но не в холодильнике) не более 20 дней. После каждого использования пакет тщательно закрывать. Срок годности - 12 месяцев",
                    Weight=0.2,
                    CategoryId=23
                },
                new Product{
                    Id = 44,
                    Code=522363,
                    Composition="пюре из яблок. Без добавления сахара. Содержит сахара природного происхождения. Изготовлено из концентрированного пюре.",
                    Description="Стерилизованное. Гомогенизированное. Для питания детей раннего возраста с 4 месяцев. Производитель - ОАО «Прогресс» 389902, г. Липецк, ул. Ангарская, влад. 2, Россия.",
                    Name="Пюре фруктовое «Фрутоняня» из яблок, 90 г",
                    MainUrl="https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F2363%2F00522363%2Fnorm%2Fthumbs%2F00522363.n_1_500x500.png.jpg%3F2023020522&w=640&q=75",
                    Price=11.0M,
                    ShelfLife="Условия и сроки хранения - хранить при температуре от 0°С до +25°С и относительной влажности воздуха не более 75 %, 12 месяцев. После вскрытия банки содержимое хранить не более суток. Дата изготовления указана на упаковке",
                    Weight=0.08,
                    CategoryId=23
                },

                new Product{
                    Id = 45,
                    Code=931647,
                    Composition="целлюлоза, суперабсорбент (САП), нетканый материал, полиэтилен, клей, нить эластомерная, крем-бальзам. Состав крем-бальзама: вода питьевая очищенная, ПЭГ-6 каприлик/каприк глицериды, цетеариловый спирт, масло вазелиновое, цетеарет-20, глицерилмоностеарт, экстракт алоэ вера, глицерин, отдушка, бензизатиазолинон и метилизотиазолинон.",
                    Description="Производитель - ООО \"БелЭмса\", 213121, Могилевская обл., Могилевский р-н, Полыковичский с/с, 9, Республика Беларусь.ООО \"БелЭмса\", 213121, Могилевская обл., Могилевский р-н, Полыковичский с/с, 9, Республика Беларусь.",
                    Name="Подгузники для детей «Happy mum» размер 4, 7-18 кг, 18 шт",
                    MainUrl="https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F1647%2F00931647%2Fnorm%2Fthumbs%2F00931647.n_1_500x500.png.jpg%3F2023020522&w=640&q=75",
                    Price=7.33M,
                    ShelfLife="Условия и сроки хранения - невскрытую упаковку следует хранить в сухом прохладном месте, защищнном от прямых солнечных лучей, при t не более +25 °C и относительной влажности не более 75 %. Открытую упаковку хранить в сухом прохладном месте (но не в холодильнике) не более 20 дней. После каждого использования пакет тщательно закрывать. Срок годности - 12 месяцев",
                    Weight=0,
                    CategoryId=24
                },
                new Product{
                    Id = 46,
                    Code=1460063,                 
                    Description="Производитель - Бюбхен Верк Эвальд Гермес Фармацойтише Фабрик Гмбх, Коестервег 37, 59494 Зоест, Германия.",
                    Name="Шампунь для младенцев «Bubchen», 200 мл",
                    MainUrl="https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F0063%2F01460063%2Fnorm%2Fthumbs%2F01460063.n_1_500x500.png.jpg%3F2023020522&w=640&q=75",
                    Price=8.39M,
                    ShelfLife="Условия и сроки хранения - срок годности и дата изготовления указаны на упаковке",
                    Weight=0,
                    CategoryId=24
                },

                new Product{
                    Id = 47,
                    Code=162714,
                    Composition="aqua, Sodium Lauryl Sulfate, Sodium Laureth Sulfate, Glycol Distearate, Zinc Carbonate, Sodium Chloride, Sodium Xylenesulfonate, Zinc Pyrithione, Cocamidopropyl Betaine, Dimethicone, Parfum, Menthol, Sodium Benzoate, Guar Hydroxypropyltrimonium Chloride, Hydrochloric Acid, Sodium Hydroxide, Magnesium Carbonate Hydroxide, Hexyl Cinnamal, Linalool, Magnesium Nitrate, Sodium Polynaphthalenesulfonate, Methylchloroisothiazolinone, Magnesium Chloride, CI 42090, Methylisothiazolinone, CI 17200.",
                    Description="Избавьтесь от перхоти с помощью шампуня против перхоти Head & Shoulders с освежающим ментолом. Шампунь Head & Shoulders с формулой тройного действия очищает, защищает и увлажняет (при регулярном использовании) ваши волосы и кожу головы — вы получите до 100%* свободы от перхоти, а ваши волосы будут выглядеть здоровыми и красивыми. Свойства шампуня Head & Shoulders отвечают новым высоким стандартам красоты, а в его состав входит опробованный и протестированный активный ингредиент против перхоти, благодаря чему волосы прекрасно выглядят, а перхоть исчезает (*видимые чешуйки, при регулярном применении). Для нормальных и жирных волос. Производитель - С.К.Детергенти С.A., Стр.Михаи Витеазу, нр.1, Урлати, 106300, Румыния.",
                    Name="Шампунь для волос «Head&Shoulders» 3 Action Ментол, 400 мл",
                    MainUrl="https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F2714%2F00162714%2Fnorm%2Fthumbs%2F00162714.n_1_500x500.png.jpg%3F2023020522&w=640&q=75",
                    Price=17.40M,
                    ShelfLife="Условия и сроки хранения - срок годности 3 года. Дата изготовления указана на упаковке",
                    Weight=0,
                    CategoryId=25
                },
                new Product{
                    Id = 48,
                    Code=1511287,
                    Description="Производитель - ЗАО «Олтекс С.А.» 142700, Московская обл., Ленинский р-н, г. Видное, Белокаменное ш., вл. 18, Россия.",
                    Name="Прокладки гигиенические «Ola!» 9 шт",
                    MainUrl="https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F1287%2F01511287%2Fnorm%2Fthumbs%2F01511287.n_1_500x500.png.jpg%3F2023020522&w=640&q=75",
                    Price=2.06M,
                    ShelfLife="Условия и сроки хранения - срок годности 5 лет. Дата изготовления указана на упаковке",
                    Weight=0,
                    CategoryId=25
                },

                 new Product{
                    Id = 49,
                    Code=1408633,
                    Description="Производитель - ООО «Пластком» 197761, г. Санкт-Петербург, г. Кронштадт, Кронштадтское шоссе, д. 9, литер А, пом. 85, Россия.",
                    Name="Пакеты для мусора «Hit» 60 литров, 20 шт",
                    MainUrl="https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F8633%2F01408633%2Fnorm%2Fthumbs%2F01408633.n_1_500x500.png.jpg%3F2023020522&w=640&q=75",
                    Price=1.17M,
                    ShelfLife="Условия и сроки хранения - срок годности 3 года. Дата изготовления указана на упаковке",
                    Weight=0,
                    CategoryId=26
                },
                new Product{
                    Id = 50,
                    Code=1408633,
                    Description="Производитель - ЗАО «Олтекс С.А.» 142700, Московская обл., Ленинский р-н, г. Видное, Белокаменное ш., вл. 18, Россия.",
                    Name="Прокладки гигиенические «Ola!» 9 шт",
                    MainUrl="https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F1287%2F01511287%2Fnorm%2Fthumbs%2F01511287.n_1_500x500.png.jpg%3F2023020522&w=640&q=75",
                    Price=2.06M,
                    ShelfLife="Условия и сроки хранения - срок годности не ограничен",
                    Weight=0,
                    CategoryId=26
                },

                 new Product{
                    Id = 51,
                    Code=1253553,
                    Composition="мясо и субпродукты (в том числе говядина и ягненок минимум 4%), злаки, таурин, витамины, минеральные вещества.",
                    Description="Это сбалансированный рацион, приготовленный именно так, как любит Ваша кошка. Аппетитное рагу с говядиной и ягненком в густом ароматном соусе подарит Вашей любимице настоящее удовольствие. Кроме того, рацион Whiskas® содержит все необходимое, чтобы еда Вашей кошки была не только вкусной, но и полезной. Производитель - ООО \"Марс\" 142800, Московская обл., г.о. Ступино, г. Ступино, ул. Ситенка, д. 12, Россия.",
                    Name="Корм для кошек «Whiskas» Рагу с говядиной и ягнёнком, 75 г",
                    MainUrl="https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F3553%2F01253553%2Fnorm%2Fthumbs%2F01253553.n_1_500x500.png.jpg%3F2023020523&w=640&q=75",
                    Price=1.13M,
                    ShelfLife="Условия и сроки хранения - дата изготовления и срок годности указаны на упаковке",
                    Weight=0,
                    CategoryId=27
                },
                new Product{
                    Id = 52,
                    Code=998843,
                    Composition="мясо и субпродукты (в том числе говядина), пшеничная мука, продукты животного происхождения, минеральные вещества, витамины, свекловичный жом, подсолнечное масло, метионин, натуральный краситель, загуститель, антиоксиданты - незаменимая аминокислота для собак.",
                    Description="Для взрослых собак содержит все, что нужно питомцам старше года. Наш рацион оптимально сбалансирован и насыщен необходимыми витаминами и минералами. И, конечно же, мясные кусочки в соусе такие вкусные, что нос оближешь! Производитель - ООО «Марс» 142800, Московская обл., г.о. Ступино, г. Ступино, ул. Ситенка, д. 12, Россия.",
                    Name="Корм для собак «Pedigree» говядина в соусе, 85 г",
                    MainUrl="https://yamigom-store.by/_next/image?url=https%3A%2F%2Fimg.e-dostavka.by%2FUserFiles%2Fimages%2Fcatalog%2FGoods%2F8843%2F00998843%2Fnorm%2Fthumbs%2F00998843.n_1_500x500.png.jpg%3F2023020523&w=640&q=75",
                    Price=1.23M,
                    ShelfLife="Условия и сроки хранения - хранить при температуре от +4 °С до +35 °С и относительной влажности воздуха не более 75%. Срок годности и дата изготовления указаны на упаковк",
                    Weight=0,
                    CategoryId=27
                }
            });
        }
    }
}