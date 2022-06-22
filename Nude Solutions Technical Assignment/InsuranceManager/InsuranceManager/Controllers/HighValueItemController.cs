using InsuranceManager.Data;
using InsuranceManager.Models;
using InsuranceManager.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsuranceManager.Controllers
{
    /// <summary>
    /// The high value item controller.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class HighValueItemController : Controller
    {
        #region Variables
        //Holds a reference to the high value item repository.
        private readonly IHighValueItemRepository _itemRepository;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="HighValueItemController"/> class.
        /// </summary>
        /// <param name="context">The database context class.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="context"/> is <c>null</c></exception>
        public HighValueItemController(DatabaseContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            _itemRepository = new HighValueItemRepository(context);
        }
        #endregion

        #region Methods
        /// <summary>
        /// HTTPGET function to return the currently added high value items.
        /// </summary>
        /// <returns>
        /// If success 
        /// return <seealso cref="Dictionary{HighValueItemCategory, List{HighValueItem}}"/>
        /// ; otherwise,
        /// return <seealso cref="BadRequestResult"/> if fetching the items failed.
        /// </returns>
        [HttpGet("GetHighValueItems")]
        public ActionResult<IDictionary<HighValueItemCategory, IEnumerable<HighValueItem>>> GetHighValueItems()
        {
            return Ok(_itemRepository.GetHighValueItems().GroupBy(x => x.ItemCategory).ToDictionary(x => x.Key, x => x.ToList()));
        }

        /// <summary>
        /// HTTPGET function to return the available categories for a high value item.
        /// </summary>
        /// <returns>
        /// A <seealso cref="Dictionary{int, string}"/> where Key is the category index and Value is description
        /// </returns>
        [HttpGet("GetHighValueCategories")]
        public ActionResult<IDictionary<int, string>> GetHighValueCategories()
        {
            var dict = new Dictionary<int, string>();
            foreach (var name in Enum.GetNames(typeof(HighValueItemCategory)))
            {
                dict.Add((int)Enum.Parse(typeof(HighValueItemCategory), name), name);
            }
            return Ok(dict);
        }

        /// <summary>
        /// HTTPPOST function to create a new high value item.
        /// </summary>
        /// <returns>
        /// If success 
        /// return <seealso cref="OkResult"/>
        /// ; otherwise,
        /// returns <seealso cref="BadRequestResult"/> if creation of the new item fails.
        /// This function also returns a string description of the fail or success
        /// </returns>
        [HttpPost("CreateHighValueItem")]
        public ActionResult<string> CreateHighValueItem([Bind("name, value, itemCategory")] HighValueItem highValueItem)
        {
            if (highValueItem == null)
            {
                return BadRequest("Cannot add null value.");
            }

            try
            {
                if (ModelState.IsValid)
                {
                    _itemRepository.InsertHighValueItem(highValueItem);
                    _itemRepository.Save();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Caught exception in create high value item", ex);
                return BadRequest("Could not create new high value item.");
            }
          
            return Ok("Item create successfully");
        }

        /// <summary>
        /// HTTPDELETE function to delete a high value item based on its Id
        /// </summary>
        /// <returns>
        /// If deletion was a success 
        /// return <seealso cref="OkResult"/>
        /// ; otherwise,
        /// return <seealso cref="BadRequestResult"/> if deletion failed, or a high value item with the provided Id was not found.
        /// This function also returns a string description of the fail or success
        /// </returns>
        [HttpDelete("DeleteHighValueItem/{id:int}")]
        public IActionResult DeleteHighValueItem(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _itemRepository.DeleteHighValueItem(id);
                    _itemRepository.Save();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Caught exception in delete high value item", ex);
                return BadRequest("Could not delete high value item.");
            }

            return Ok("Item deleted successfully");    
        }
        #endregion
    }
}
