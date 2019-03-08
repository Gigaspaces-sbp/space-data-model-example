using System;
using System.Collections.Generic;
using GigaSpaces.Core;

namespace SpaceDataModelExample.Embedded.One2One
{
    public class EmbeddedOne2OneExample : IExamplePattern
    {
        public void Fill(ISpaceProxy spaceProxy)
        {
            spaceProxy.Write(new Author {LastName = "AuthorX", Book = new Book() {Title = "BookX"}});
        }

        public void QuerySpace(ISpaceProxy spaceProxy)
        {
            Console.WriteLine("Embedded one-to-one Example");
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
            var query = new SqlQuery<Author>("LastName=? and Book.Title=?");
            query.SetParameter(1, "AuthorX");
            query.SetParameter(2, "BookX");

            Author[] authors = spaceProxy.ReadMultiple<Author>(query);
            return authors;
        }

        private  IEnumerable<Book> QueryForBooksByAuthor(ISpaceProxy spaceProxy)
        {
            var books = new HashSet<Book>();

            var query = new SqlQuery<Author>("LastName=?");
            query.SetParameter(1, "AuthorX");

            var authors = spaceProxy.ReadMultiple<Author>(query);

            foreach (var author in authors)
            {
                books.Add(author.Book);
            }

            return books;
        }
    }
}