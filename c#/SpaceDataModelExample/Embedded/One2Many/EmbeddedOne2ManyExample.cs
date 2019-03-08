using System;
using System.Collections.Generic;
using GigaSpaces.Core;

namespace SpaceDataModelExample.Embedded.One2Many
{
    internal class EmbeddedOne2ManyExample : IExamplePattern
    {
        public void Fill(ISpaceProxy spaceProxy)
        {
            var author = new Author();
            author.LastName = "AuthorX";
            author.Books = new List<Book> {new Book {Title = "BookY"}};

            spaceProxy.Write(author);
        }

        public void QuerySpace(ISpaceProxy spaceProxy)
        {
            Console.WriteLine("Embedded one-to-many Example");
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
            var authorQuery = new SqlQuery<Author>("LastName=? AND Books[*].Title=?");
            authorQuery.SetParameter(1, "AuthorX");
            authorQuery.SetParameter(2, "BookY");
            var authors = spaceProxy.ReadMultiple<Author>(authorQuery);

            return authors;
        }

        private IEnumerable<Book> QueryForBooksByAuthor(ISpaceProxy spaceProxy)
        {
            var books = new List<Book>();

            var authorQuery = new SqlQuery<Author>("LastName=?");
            authorQuery.SetParameter(1, "AuthorX");
            var authors = spaceProxy.ReadMultiple<Author>(authorQuery);

            foreach (var author in authors)
            {
                books.AddRange(author.Books);
            }

            return books;
        }
    }
}