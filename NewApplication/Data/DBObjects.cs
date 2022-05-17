using Shop.Data.Models;
using System.Collections.Generic;
using System.Linq;
namespace Shop.DB
{
    public class DbObjects
    {
        public static void Initial(AppDbContent content)
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
                        Name = "Маленькая корзина",
                        ShortDesc = "Небольшой набор за низкую цену. Самый дешёвый вариант, подойдёт вам, " +
                        "если вы хотите порадовать себя вкусными овощами, но не хотите тратиться.",
                        LongDesc = "Небольшой набор за низкую цену. Самый дешёвый вариант, подойдёт вам, " +
                        "если вы хотите порадовать себя вкусными овощами, но не хотите тратиться.",
                        Img = "/img/small.jpg",
                        Price = 690,
                        IsFavourite = true,
                        Available = true,
                        Category = Categories["Дешёвые"]
                    },
                    new Veg
                    {
                        Name = "Средняя корзина",
                        ShortDesc = "Оптимальный набор с нашими лучшими овощами. Отличное соотношение цена-качество, " +
                        "один из самых популярных выборов наших клиентов.",
                        LongDesc = "Оптимальный набор с нашими лучшими овощами. Отличное соотношение цена-качество, " +
                        "один из самых популярных выборов наших клиентов.",
                        Img = "/img/medium.jpg",
                        Price = 1390,
                        IsFavourite = false,
                        Available = false,
                        Category = Categories["Дешёвые"]
                    },
                    new Veg
                    {
                        Name = "Большая корзина",
                        ShortDesc = "Стандартная корзина со всеми овощами. В ней представлено всё разнообразие" +
                        "наших самых вкусных и качественных овощей. Отлично подойдёт как вариант оригинального подарка.",
                        LongDesc = "Стандартная корзина со всеми овощами. В ней представлено всё разнообразие" +
                        "наших самых вкусных и качественных овощей. Отлично подойдёт как вариант оригинального подарка.",
                        Img = "/img/big.jpg",
                        Price = 1990,
                        IsFavourite = false,
                        Available = true,
                        Category = Categories["Дешёвые"]
                    },
                    new Veg
                    {
                        Name = "Огромная корзина",
                        ShortDesc = "Большой набор для потребления в кругу друзей. Хватит на всех, так как в ней " +
                        "лучшие овощи, оправдывающие своим вкусом и качеством цену.",
                        LongDesc = "Большой набор для потребления в кругу друзей. Хватит на всех, так как в ней " +
                        "лучшие овощи, оправдывающие своим вкусом и качеством цену.",
                        Img = "/img/huge.jpg",
                        Price = 3490,
                        IsFavourite = true,
                        Available = true,
                        Category = Categories["Дорогие"]
                    },
                    new Veg
                    {
                        Name = "Гигантская корзина",
                        ShortDesc = "Огромный набор на большую компанию. Овощей здесь настолько много, что" +
                        " набор можно использовать как полноценный ужин для всей семьи (до 10 человек)",
                        LongDesc = "Огромный набор на большую компанию. Овощей здесь настолько много, что" +
                        " набор можно использовать как полноценный ужин для всей семьи (до 10 человек)",
                        Img = "/img/gigantic.jpg",
                        Price = 5990,
                        IsFavourite = true,
                        Available = false,
                        Category = Categories["Дорогие"]
                    },
                    new Veg
                    {
                        Name = "Королевская корзина",
                        ShortDesc = "Огромный запас овощей, хватит на всю зиму. Буквально пестрящая самыми" +
                        "разными вкусными продуктами, корзина позволяет накрывать целый стол на небольшую вечеринку только" +
                        "с её помощью.",
                        LongDesc = "Огромный запас овощей, хватит на всю зиму. Буквально пестрящая самыми" +
                        " разными вкусными продуктами, корзина позволяет накрывать целый стол на небольшую вечеринку только" +
                        " с её помощью.",
                        Img = "/img/king.jpg",
                        Price = 7990,
                        IsFavourite = true,
                        Available = true,
                        Category = Categories["Дорогие"]
                    }

                    );

            }
            content.SaveChanges();

        }



        private static Dictionary<string, Category> _category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (_category != null) return _category;
                var list = new Category[]
                {
                    new() { CategoryName = "Дешёвые", Desc = "Оптимальные и недорогие варианты"},
                    new() { CategoryName = "Дорогие", Desc = "Дорогие наборы с разнообразными овощами"}
                };

                _category = new Dictionary<string, Category>();
                foreach (var el in list)
                    _category.Add(el.CategoryName, el);
                return _category; 
            }
        }
    }
}