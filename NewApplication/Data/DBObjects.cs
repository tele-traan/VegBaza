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
            {
                content.Category.AddRange(Categories.Select(c => c.Value));
            }
            if (!content.Veg.Any())
            {
                content.AttachRange(

                    new Veg
                    {
                        name = "Маленькая корзина",
                        shortDesc = "Небольшой набор за низкую цену. Самый дешёвый вариант, подойдёт вам, " +
                        "если вы хотите порадовать себя вкусными овощами, но не хотите тратиться.",
                        longDesc = "Небольшой набор за низкую цену. Самый дешёвый вариант, подойдёт вам, " +
                        "если вы хотите порадовать себя вкусными овощами, но не хотите тратиться.",
                        img = "/img/small.jpg",
                        price = 690,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Дешёвые"]
                    },
                    new Veg
                    {
                        name = "Средняя корзина",
                        shortDesc = "Оптимальный набор с нашими лучшими овощами. Отличное соотношение цена-качество, " +
                        "один из самых популярных выборов наших клиентов.",
                        longDesc = "Оптимальный набор с нашими лучшими овощами. Отличное соотношение цена-качество, " +
                        "один из самых популярных выборов наших клиентов.",
                        img = "/img/medium.jpg",
                        price = 1390,
                        isFavourite = false,
                        available = false,
                        Category = Categories["Дешёвые"]
                    },
                    new Veg
                    {
                      //  id = 3,
                        name = "Большая корзина",
                        shortDesc = "Стандартная корзина со всеми овощами. В ней представлено всё разнообразие" +
                        "наших самых вкусных и качественных овощей. Отлично подойдёт как вариант оригинального подарка.",
                        longDesc = "Стандартная корзина со всеми овощами. В ней представлено всё разнообразие" +
                        "наших самых вкусных и качественных овощей. Отлично подойдёт как вариант оригинального подарка.",
                        img = "/img/big.jpg",
                        price = 1990,
                        isFavourite = false,
                        available = true,
                        Category = Categories["Дешёвые"]
                    },
                    new Veg
                    {
                        //id = 4,
                        name = "Огромная корзина",
                        shortDesc = "Большой набор для потребления в кругу друзей. Хватит на всех, так как в ней " +
                        "лучшие овощи, оправдывающие своим вкусом и качеством цену.",
                        longDesc = "Большой набор для потребления в кругу друзей. Хватит на всех, так как в ней " +
                        "лучшие овощи, оправдывающие своим вкусом и качеством цену.",
                        img = "/img/huge.jpg",
                        price = 3490,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Дорогие"]
                    },
                    new Veg
                    {
                       // id = 5,
                        name = "Гигантская корзина",
                        shortDesc = "Огромный набор на большую компанию. Овощей здесь настолько много, что" +
                        " набор можно использовать как полноценный ужин для всей семьи (до 10 человек)",
                        longDesc = "Огромный набор на большую компанию. Овощей здесь настолько много, что" +
                        " набор можно использовать как полноценный ужин для всей семьи (до 10 человек)",
                        img = "/img/gigantic.jpg",
                        price = 5990,
                        isFavourite = true,
                        available = false,
                        Category = Categories["Дорогие"]
                    },
                    new Veg
                    {
                       // id = 6,
                        name = "Королевская корзина",
                        shortDesc = "Огромный запас овощей, хватит на всю зиму. Буквально пестрящая самыми" +
                        "разными вкусными продуктами, корзина позволяет накрывать целый стол на небольшую вечеринку только" +
                        "с её помощью.",
                        longDesc = "Огромный запас овощей, хватит на всю зиму. Буквально пестрящая самыми" +
                        " разными вкусными продуктами, корзина позволяет накрывать целый стол на небольшую вечеринку только" +
                        " с её помощью.",
                        img = "/img/king.jpg",
                        price = 7990,
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
                         new Category {categoryName = "Дорогие", desc = "Дорогие наборы с разнообразными овощами"}
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