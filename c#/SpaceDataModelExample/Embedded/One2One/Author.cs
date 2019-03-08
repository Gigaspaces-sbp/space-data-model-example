using GigaSpaces.Core.Metadata;

namespace SpaceDataModelExample.Embedded.One2One
{
    [SpaceClass]
    public class Author
    {
        [SpaceID]
        public int Id { get; set; }

        [SpaceIndex]
        public string LastName { get; set; }

        [SpaceIndex(Path = "Title")]
        [SpaceProperty(StorageType = StorageType.Document)]
        public Book Book { get; set; }
    }
}