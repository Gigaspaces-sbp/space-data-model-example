using System.Collections;
using System.Collections.Generic;
using GigaSpaces.Core.Metadata;

namespace SpaceDataModelExample.NonEmbedded.One2Many
{
    [SpaceClass]
    public class Author
    {
        [SpaceID(AutoGenerate= false)]
        public int Id { get; set; }

        [SpaceIndex]
        public string LastName { get; set; }

        public IList<int> BookIds { get; set; }
    }
}