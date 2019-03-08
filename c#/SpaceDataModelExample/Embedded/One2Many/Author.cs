using System.Collections;
using System.Collections.Generic;
using GigaSpaces.Core.Metadata;

namespace SpaceDataModelExample.Embedded.One2Many
{
    [SpaceClass]
    public class Author
    {
        [SpaceID]
        public int Id { get; set; }

        [SpaceIndex]
        public string LastName { get; set; }

        [SpaceIndex(Path="[*].Title")]
        [SpaceProperty(StorageType = StorageType.Document)]
        public IList<Book> Books { get; set; }
    }
}