using Dev4Side_sheshan.Models;
using Dev4Side_sheshan.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dev4Side_sheshan.Controllers
{
    [Route("lists")]
    [ApiController]
    [Authorize]
    public class ListsController : ControllerBase
    {
        private readonly IListService _listService;
        private int GetUserId() => int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new Exception("User not found !"));
        public ListsController(IListService listService)
        {
            _listService = listService;
        }


        [HttpGet]
        public async Task<IActionResult> GetLists() {
            var userId = GetUserId();
            var lists = await _listService.GetListsAsync(userId);
            return Ok(lists);
        }

        [HttpPost]
        public async Task<IActionResult> CreateList([FromBody] ListEntity listEntity)
        {
            var userId = GetUserId();
            var createdList = await _listService.CreateList(listEntity, userId);
            return Ok(createdList);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteList(int id)
        {
            var userId = GetUserId();
            await _listService.DeleteList(userId, id);
            return NoContent();
        }
    }
}
