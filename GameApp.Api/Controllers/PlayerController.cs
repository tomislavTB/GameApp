using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameApp.Api.Services.Contracts;
using GameApp.Api.Requests;
using GameApp.Api.Responses;
using GameApp.Shared.Pagination;
using GameApp.Api.Controllers;

namespace StudentiProject.Controllers
{
    [Route("api/players")]
    [ApiController]
    public class PlayerController : BaseController
    {
        private readonly IPlayerService Players;

        public PlayerController(IPlayerService players)
        {
            Players = players;
        }

        [HttpGet]
        public async Task<IActionResult> GetPage([FromQuery] PlayerPaginationRequest request = null)
        {
            PagedResult<PlayerResponse> pagedResult = await Players.GetPageAsync(request);
            return ApiOk(pagedResult);
        }



        // GET
        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetPlayerItem(int id)
        {
            var PlayerItem = await Players.FindAsync(id);

            if (PlayerItem == null)
            {
                return NotFound();
            }

            return PlayerItem;
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> Postplayeritem(Player item)
        {
            return ApiOk(await Players.PostPlayer(item));
        }

        //PUT

        [HttpPut("{Id}")]
        public async Task<int> PutPlayerItem(int Id, [FromBody] Player item)
        {
            item.Id = Id;
            return await Players.PutPlayer(item);
        }

        // DELETE

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int success = await Players.DeleteByIdAsync(id);
            return ApiOk(success);
        }

    }
}