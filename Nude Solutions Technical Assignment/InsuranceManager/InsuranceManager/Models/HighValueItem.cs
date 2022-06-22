using InsuranceManager.Models.Enums;

namespace InsuranceManager.Models
{
    /// <summary>
    /// Represents a high value item model.
    /// </summary>
    public class HighValueItem
    {
        /// <summary>
        /// Property to set or return the ID of the item.
        /// </summary>
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Property to set or return the Name of the item.
        /// </summary>
        public string Name
        {
            get;
            set;
        } = string.Empty;

        /// <summary>
        /// Property to set or return the value of the item.
        /// </summary>
        public decimal Value
        {
            get;
            set;
        }

        /// <summary>
        /// Property to set or return the category of this item.
        /// </summary>
        public HighValueItemCategory ItemCategory
        {
            get;
            set;
        }
    }
}
