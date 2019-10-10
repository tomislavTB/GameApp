using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameApp.Api.DB;
using GameApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameApp.Api.Controllers;
using GameApp.Api.Services.Contracts;
using GameApp.Api.Requests;
using GameApp.Api.Responses;
using GameApp.Shared.Pagination;

namespace GameApp.Api.Controllers
{

    [Route("api/GoodGame")]
    [ApiController]
    public class GoodGameController : BaseController
    {
        private readonly IGoodGameService GoodGames;

        public GoodGameController(IGoodGameService goodGames)
        {
            GoodGames = goodGames;
        }

        [HttpGet]
        public async Task<IActionResult> GetPage([FromQuery] GoodGamePaginationRequest request = null)
        {
            PagedResult<GoodGameResponse> pagedResult = await GoodGames.GetPageAsync(request);
            return ApiOk(pagedResult);
        }



        // GET
        [HttpGet("{id}")]
        public async Task<ActionResult<GoodGame>> GetGoodGameItem(int id)
        {
            var GoodGameItem = await GoodGames.FindAsync(id);

            if (GoodGameItem == null)
            {
                return NotFound();
            }

            return GoodGameItem;
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> Postcountryitem(GoodGame item)
        {
            return ApiOk(await GoodGames.PostGoodGame(item));
        }

        [HttpPut("{Id}")]
        public async Task<int> PutGoodGameItem(int Id, [FromBody] GoodGame item)
        {
            item.Id = Id;
            return await GoodGames.PutGoodGame(item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int success = await GoodGames.DeleteByIdAsync(id);
            return ApiOk(success);
        }
    }
}