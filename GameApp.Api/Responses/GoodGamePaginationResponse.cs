using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using GameApp.Models.Attributes;

namespace GameApp.Api.Responses
{
    public class GoodGameResponse
    {
        public long Id { get; set; }
        public string PlayerId { get; set; }
        public string GameId { get; set; }
        public string DatePlayed { get; set; }


    }
}