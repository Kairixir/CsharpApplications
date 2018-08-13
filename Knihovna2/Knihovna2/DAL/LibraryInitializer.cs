using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Knihovna2.Models;

namespace Knihovna2.DAL
{
    public class LibraryInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<LibraryContext>
    {
        protected override void Seed(LibraryContext context)
        {
            var readers = new List<Reader>
            {
            new Reader{LastName="Alexander",FirstMidName="Carson",Registration=DateTime.Parse("2005-09-01"),MembershipFee=true},
            new Reader{LastName="Alonso",FirstMidName="Meredith",Registration=DateTime.Parse("2002-09-01"),MembershipFee=true},
            new Reader{LastName="Anand",FirstMidName="Arturo",Registration=DateTime.Parse("2003-09-01"),MembershipFee=true},
            new Reader{LastName="Barzdukas",FirstMidName="Gytis",Registration=DateTime.Parse("2002-09-01"),MembershipFee=true},
            new Reader{LastName="Li",FirstMidName="Yan",Registration=DateTime.Parse("2002-09-01"),MembershipFee=true},
            new Reader{LastName="Justice",FirstMidName="Peggy",Registration=DateTime.Parse("2001-09-01"),MembershipFee=true},
            new Reader{LastName="Norman",FirstMidName="Laura",Registration=DateTime.Parse("2003-09-01"),MembershipFee=true},
            new Reader{LastName="Olivetto",FirstMidName="Nino",Registration=DateTime.Parse("2005-09-01"),MembershipFee=true}
            };

            readers.ForEach(s => context.Readers.Add(s));
            context.SaveChanges();
            var books = new List<Book>
            {
            new Book{Title="Společenstvo Prstenu", Author="John Ronald Reuel Tolkien", Genre="Dobrodružné"},
            new Book{Title="Dvě věže", Author="John Ronald Reuel Tolkien", Genre="Dobrodružné"},
            new Book{Title="Návrat krále", Author="John Ronald Reuel Tolkien", Genre="Dobrodružné"},
            new Book{Title="Hra o trůny", Author="George Raymond Richard Martin", Genre="Román"},
            new Book{Title="Střet králů", Author="George Raymond Richard Martin", Genre="Román"},
            new Book{Title="Bouře mečů", Author="George Raymond Richard Martin", Genre="Román"},
             };
            books.ForEach(s => context.Books.Add(s));
            context.SaveChanges();
            var borrows = new List<Borrow>
            {
            new Borrow{ BookID=3, ReaderID=4, BorrowedSince=DateTime.Parse("2018-01-01"), BorrowedTo=DateTime.Parse("2018-04-01")},
            new Borrow{ BookID=1, ReaderID=3, BorrowedSince=DateTime.Parse("2017-09-05"),BorrowedTo=DateTime.Parse("2017-12-05")},
            new Borrow{ BookID=5, ReaderID=1, BorrowedSince=DateTime.Parse("2017-11-16"),BorrowedTo=DateTime.Parse("2017-02-16")},
            };
            borrows.ForEach(s => context.Borrows.Add(s));
            context.SaveChanges();
        }
    }
}