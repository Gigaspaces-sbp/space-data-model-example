using System;
using System.Collections.Generic;
using System.Text;
using GigaSpaces.Core;

namespace SpaceDataModelExample.NonEmbedded.One2One
{
    public class NonEmbeddedOne2OneExample : IExamplePattern
    {
        public void Fill(ISpaceProxy spaceProxy)
        {
            spaceProxy.Write(new Author {Id = 1, LastName = "AuthorX", BookId = 3});
            spaceProxy.Write(new Book {Id = 3, AuthorId = 1, Title = "BookX"});
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
            var authorIds = new StringBuilder();

            var bookQuery = new SqlQuery<Book>("Title=?");
            bookQuery.SetParameter(1, "BookX");

            var books = spaceProxy.ReadMultiple<Book>(bookQuery);

            foreach (var book in books)
            {
                authorIds.AppendFormat(",{0}", book.AuthorId);
            }

            var inCriteria = authorIds.ToString().TrimStart(',');
            var authorQuery = new SqlQuery<Author>(string.Format("LastName=? AND Id IN ({0})", inCriteria));
            authorQuery.SetParameter(1, "AuthorX");

            var authors = spaceProxy.ReadMultiple<Author>(authorQuery);
            return authors;
        }

        private IEnumerable<Book> QueryForBooksByAuthor(ISpaceProxy spaceProxy)
        {
            var books = new HashSet<Book>();

            var query = new SqlQuery<Author>("LastName=?");
            query.SetParameter(1, "AuthorX");

            Author[] authors = spaceProxy.ReadMultiple<Author>(query);

            foreach (Author author in authors)
            {
               books.Add(spaceProxy.ReadById<Book>(author.BookId));
            }

            return books;
        }
    }
}