using GigaSpaces.Core.Metadata;

namespace SpaceDataModelExample.NonEmbedded.One2One
{
    [SpaceClass]
    public class Book
    {
        [SpaceID(AutoGenerate = false)]
        public int Id { get; set; }

        [SpaceIndex]
        public string Title { get; set; }

        public int AuthorId { get; set; }
    }
}