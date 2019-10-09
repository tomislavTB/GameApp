using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentiProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameApp.Shared.Pagination;
using GameApp.Api.Requests;
using GameApp.Api.Responses;
using GameApp.Api.Services.Contracts;

namespace GameApp.Api.Controllers
{
    [Route("api/games")]
    [ApiController]

    public class GameController : AppAuthorizedController
    {
        private readonly IGameService Cities;

        public GameController(IGameService games)
        {
            Games = games;
        }

        [HttpGet]
        public async Task<IActionResult> GetPage([FromQuery] CityPaginationRequest request = null)
        {
            PagedResult<CityResponse> pagedResult = await Games.GetPageAsync(request);
            return ApiOk(pagedResult);
        }



        // GET
        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGameItem(int id)
        {
            var GameItem = await Cities.FindAsync(id);

            if (GameItem == null)
            {
                return NotFound();
            }

            return GameItem;
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> Postgameitem(Game item)
        {

            return ApiOk(await Games.PostGame(item));
        }


        [HttpPut("{Id}")]
        public async Task<int> PutGameItem(int Id, [FromBody] Game item)
        {
            item.Id = Id;
            return await Games.PutGame(item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int success = await Games.DeleteByIdAsync(id);
            return ApiOk(success);
        }
    }
}