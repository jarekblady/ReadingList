using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReadingList.Repository.Context;
using ReadingList.Repository.Entities;

namespace ReadingList.Repository
{
    public class DbInitializer
    {
        public static void Initialize(BookDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Categories.Any())
            {
                return;  
            }

            var categories = new Category[]
            {
            new Category{Name="Fantasy"},
            new Category{Name="Science Fiction"}
            };
            foreach (Category c in categories)
            {
                context.Categories.Add(c);
            }
            context.SaveChanges();


            var books = new Book[]
            {
            new Book{Title="Lord of the Rings", Author="J.R.R. Tolkien", IsRead=false, OrderList=1, CategoryId=1},
            new Book{Title="Diuna", Author="Frank Herbert", IsRead=false, OrderList=2, CategoryId=2},
            new Book{Title="Jurassic Park", Author="Michael Crichton", IsRead=false, OrderList=3, CategoryId=1},
            new Book{Title="The Witcher", Author="Andrzej Sapkowski", IsRead=false, OrderList=4, CategoryId=1},
            new Book{Title="Player One", Author="Ernest Cline", IsRead=false, OrderList=5, CategoryId=2}

            };
            foreach (Book b in books)
            {
                context.Books.Add(b);
            }
            context.SaveChanges();
        }
    }
}
