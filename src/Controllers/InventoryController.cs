using Microsoft.AspNetCore.Mvc;
using sda_onsite_2_csharp_backend_teamwork.src.Abstractions;
using sda_onsite_2_csharp_backend_teamwork.src.DTOs;
using sda_onsite_2_csharp_backend_teamwork.src.Entities;

namespace sda_onsite_2_csharp_backend_teamwork.src.Controllers
{
    public class InventoryController : CustomBaseController
    {
        private IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet]
        public IEnumerable<InventoryReadDto> FindAll()
        {
            return _inventoryService.FindAll();
        }
        [HttpGet("{inventoryId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<InventoryReadDto?> FindOne(Guid inventoryId)
        {
            InventoryReadDto? inventory = _inventoryService.FindOne(inventoryId);
            if (inventory == null) return NotFound();

            return Ok(inventory);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<InventoryReadDto?> CreateOne([FromBody] InventoryCreateDto newInventory)
        {
            if (newInventory == null) return BadRequest();

            InventoryReadDto? createInventory = _inventoryService.CreateOne(newInventory);
            return CreatedAtAction(nameof(CreateOne), createInventory);
        }

        [HttpDelete("{inventoryId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult DeleteOne(Guid inventoryId)
        {
            InventoryReadDto? deleteInventory = _inventoryService.FindOne(inventoryId);
            if (deleteInventory == null) return NotFound();
            _inventoryService.DeleteOne(inventoryId);
            return NoContent();
        }

        [HttpPatch("{inventoryId}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<InventoryReadDto?> UpdateOne(Guid inventoryId, [FromBody] InventoryUpdateDto updateInventory)
        {
            InventoryReadDto? findInventory = _inventoryService.FindOne(inventoryId);
            if (findInventory == null) return NotFound();
            return Accepted(_inventoryService.UpdateOne(inventoryId, updateInventory));
        }
    }
}