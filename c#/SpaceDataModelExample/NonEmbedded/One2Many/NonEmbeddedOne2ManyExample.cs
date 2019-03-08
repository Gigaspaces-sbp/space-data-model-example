using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GigaSpaces.Core;

namespace SpaceDataModelExample.NonEmbedded.One2Many
{
    public class NonEmbeddedOne2ManyExample : IExamplePattern
    {
        public void Fill(ISpaceProxy spaceProxy)
        {
            var author = new Author();
            author.Id = 2;
            author.LastName = "AuthorX";
            author.BookIds = new List<int> {1, 2, 3};
            spaceProxy.Write(author);

            var book1 = new Book();
            book1.AuthorId = 2;
            book1.Title = "BookX";
            book1.Id = 1;
            spaceProxy.Write(book1);

            var book2 = new Book();
            book2.AuthorId = 2;
            book2.Title = "BookY";
            book2.Id = 2;
            spaceProxy.Write(book2);

            var book3 = new Book();
            book3.AuthorId = 2;
            book3.Title = "BookZ";
            book3.Id = 3;
            spaceProxy.Write(book3);
        }

        public void QuerySpace(ISpaceProxy spaceProxy)
        {
            Console.WriteLine("Non-embedded one-to-one Example");
            Console.WriteLine("---------------------------");
            Console.WriteLine("Query for all books by the author \"AuthorX\":");

            foreach (var book in QueryForBooksByAuthor(spaceProxy))
            {
                Console.WriteLine(book.Title);
            }

            Console.WriteLine();
            Console.WriteLine("Query for author using specific book title and author name.");

            foreach (var author in QueryForAuthorByBookTitle(spaceProxy))
            {
                Console.WriteLine(author.LastName);
            }
        }

        private IEnumerable<Author> QueryForAuthorByBookTitle(ISpaceProxy spaceProxy)
        {
            var bookQuery = new SqlQuery<Book>("Title=?");
            bookQuery.SetParameter(1, "BookX");
            var books = spaceProxy.ReadMultiple<Book>(bookQuery);

            var authorIds = new StringBuilder();

            foreach (var book in books)
            {
                authorIds.AppendFormat(",{0}", book.AuthorId);
            }

            var authorQueryCriteria = authorIds.ToString().TrimStart(',');
            var authorQuery = new SqlQuery<Author>(string.Format("LastName=? AND Id in ({0})", authorQueryCriteria));
            authorQuery.SetParameter(1, "AuthorX");

            var authors = spaceProxy.ReadMultiple<Author>(authorQuery);

            return authors;
        }

        private IEnumerable<Book> QueryForBooksByAuthor(ISpaceProxy spaceProxy)
        {
            var authorQuery = new SqlQuery<Author>("LastName=?");
            authorQuery.SetParameter(1, "AuthorX");
            var authors = spaceProxy.ReadMultiple<Author>(authorQuery);

            var books = new List<Book>();

            foreach (var author in authors)
            {
                books.AddRange(spaceProxy.ReadByIds<Book>(author.BookIds.Cast<object>().ToArray()));
            }


            return books;
        }
    }
}