using Shop.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shop.DB
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {
            if (!content.Category.Any())
                content.Category.AddRange(Categories.Select(c => c.Value));

            if (!content.Veg.Any())
            {
                content.AttachRange(

                    new Veg
                    {
                        id = 1,
                        name = "Маленькая корзина",
                        shortDesc = "Недорогой набор",
                        longDesc = "Небольшой набор за низкую цену",
                        img = "/img/small.jpg",
                        price = "690 руб.",
                        isFavourite = true,
                        available = true,
                        Category = Categories["Дешёвые"]
                    },
                    new Veg
                    {
                        id = 2,
                        name = "Средняя корзина",
                        shortDesc = "Чуть побольше",
                        longDesc = "Оптимальный набор с нашими лучшими овощами",
                        img = "/img/medium.jpg",
                        price = "1390 руб.",
                        isFavourite = false,
                        available = true,
                        Category = Categories["Дешёвые"]
                    },
                    new Veg
                    {
                        id = 3,
                        name = "Большая корзина",
                        shortDesc = "Вместительный набор",
                        longDesc = "Стандартная корзина со всеми овощами",
                        img = "/img/big.jpg",
                        price = "1990 руб.",
                        isFavourite = false,
                        available = true,
                        Category = Categories["Дешёвые"]
                    },
                    new Veg
                    {
                        id = 4,
                        name = "Огромная корзина",
                        shortDesc = "Корзина на нескольких человек",
                        longDesc = "Большой набор для потребления в кругу друзей",
                        img = "/img/huge.jpg",
                        price = "3490 руб.",
                        isFavourite = true,
                        available = true,
                        Category = Categories["Дорогие"]
                    },
                    new Veg
                    {
                        id = 5,
                        name = "Гигантская корзина",
                        shortDesc = "Корзина с разнообразными овощами",
                        longDesc = "Огромный набор на большую компанию",
                        img = "/img/gigantic.jpg",
                        price = "5990 руб.",
                        isFavourite = true,
                        available = true,
                        Category = Categories["Дорогие"]
                    },
                    new Veg
                    {
                        id = 6,
                        name = "Королевская корзина",
                        shortDesc = "Самый большой набор",
                        longDesc = "Огромный запас овощей",
                        img = "/img/king.jpg",
                        price = "7990 руб.",
                        isFavourite = true,
                        available = true,
                        Category = Categories["Дорогие"]
                    }

                    );
            }

            content.SaveChanges();

        }

        

        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]
                    {
                         new Category{categoryName = "Дешёвые", desc = "Оптимальные и недорогие варианты"},
                         new Category {categoryName = "Дорогие", desc = "Премиум наборы с разнообразными овощами"}
                    };

                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                        category.Add(el.categoryName, el);
                }
                return category;
            }
        }
    }
}