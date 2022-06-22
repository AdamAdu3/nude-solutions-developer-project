using System;
using System.Collections.Generic;
using System.Linq;
using InsuranceManager.Models;

namespace InsuranceManager.Data
{
    /// <summary>
    /// The repository class for a high value item.
    /// </summary>
    public class HighValueItemRepository : IHighValueItemRepository
    {
        #region Variables
        //Holds a reference to the database context class.
        private readonly DatabaseContext _context;
        //Flag to indicate if the repository has been disposed.
        private bool _disposed;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="HighValueItemRepository"/> class.
        /// </summary>
        /// <param name="context">The database context class.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="context"/> is null.</exception>
        public HighValueItemRepository(DatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        #endregion

        #region Methods

        /// <summary>
        /// Function to return the list of high value items.
        /// </summary>
        /// <returns>The list of high value items.</returns>
        public IEnumerable<HighValueItem> GetHighValueItems()
        {
            if (_context.HighValueItemSet == null)
            {
                return new List<HighValueItem>();
            }

            return _context.HighValueItemSet.ToList();
        }

        /// <summary>
        /// Function to get a <see cref="HighValueItem"/> based on the provided <paramref name="id"/>
        /// </summary>
        /// <param name="id">The id of the high value item to fetch.</param>
        /// <returns>The found <see cref="HighValueItem"/> if found; otherwise, returns <c>null</c></returns>
        public HighValueItem? GetHighValueItemById(int id)
        {
            if (_context.HighValueItemSet == null)
            {
                return null;
            }

            //Attempt to find the high value item based on its id.
            return _context.HighValueItemSet.SingleOrDefault(item => item.Id == id);
        }

        /// <summary>
        /// Function to insert a high value item into the database.
        /// </summary>
        /// <param name="highValueItem">The high value item to inter.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="highValueItem"/> is <c>null</c></exception>
        public void InsertHighValueItem(HighValueItem highValueItem)
        {
            if (highValueItem == null)
            {
                throw new ArgumentNullException(nameof(highValueItem));
            }

            if (_context.HighValueItemSet == null)
            {
                return;
            }

            _context.HighValueItemSet.Add(highValueItem);
        }

        /// <summary>
        /// Function to delete a high value item based on its id
        /// </summary>
        /// <param name="id">The id of the high value item to be deleted.</param>
        public void DeleteHighValueItem(int id)
        {
            HighValueItem? highValueItem = GetHighValueItemById(id);
            if ((highValueItem != null) && (_context.HighValueItemSet != null))
            {
                _context.HighValueItemSet.Remove(highValueItem);
            }
        }

        /// <summary>
        /// Function to save all pending changes of the database context.
        /// </summary>
        public void Save()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// Function to dispose the high value item repository.
        /// </summary>
        /// <param name="disposing">The flag to indicate if the repository is currently disposing.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        /// <summary>
        /// Function to dispose the high value item repository.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion Methods
    }
}
