using GigaSpaces.Core;

namespace SpaceDataModelExample
{
    public interface IExamplePattern
    {
        /// <summary>
        /// Writes sample data to the space for use later in the query examples.
        /// </summary>
        /// <param name="spaceProxy">An instance of the space proxy.</param>
        void Fill(ISpaceProxy spaceProxy);

        /// <summary>
        /// Peforms the queries in the example.
        /// </summary>
        /// <param name="spaceProxy">An instance of the space proxy.</param>
        void QuerySpace(ISpaceProxy spaceProxy);
    }
}