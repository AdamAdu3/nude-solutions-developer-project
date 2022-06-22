using InsuranceManager.Models;

namespace InsuranceManager.Data
{
    /// <summary>
    /// The schema class for the high value item repository.
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public interface IHighValueItemRepository : IDisposable
    {
        /// <summary>
        /// Function to return the list of high value items.
        /// </summary>
        /// <returns>The list of high value items.</returns>
        IEnumerable<HighValueItem> GetHighValueItems();

        /// <summary>
        /// Function to get a <see cref="HighValueItem"/> based on the provided <paramref name="id"/>
        /// </summary>
        /// <param name="id">The id of the high value item to fetch.</param>
        /// <returns>The found <see cref="HighValueItem"/> if found; otherwise, returns <c>null</c></returns>
        HighValueItem? GetHighValueItemById(int id);

        /// <summary>
        /// Function to insert a high value item into the database.
        /// </summary>
        /// <param name="highValueItem">The high value item to inter.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="highValueItem"/> is <c>null</c></exception>
        void InsertHighValueItem(HighValueItem highValueItem);

        /// <summary>
        /// Function to delete a high value item based on its id
        /// </summary>
        /// <param name="id">The id of the high value item to be deleted.</param>
        void DeleteHighValueItem(int id);

        /// <summary>
        /// Function to save all pending changes of the database context.
        /// </summary>
        void Save();
    }
}
