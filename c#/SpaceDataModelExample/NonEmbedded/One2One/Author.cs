using GigaSpaces.Core.Metadata;

namespace SpaceDataModelExample.NonEmbedded.One2One
{
    [SpaceClass]
    public class Author
    {
        [SpaceID(AutoGenerate = false)]
        public int Id { get; set; }

        [SpaceIndex]
        public string LastName { get; set; }

        public int BookId { get; set; }
    }
}