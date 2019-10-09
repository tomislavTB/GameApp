using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using GameApp.Models.Attributes;

namespace GameApp.Models
{
    public class GoodGame : BaseModel
    {

        [CustomRequired]
        public string DatePlayed { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }

        public int PlayerId { get; set; }
        public Player Player { get; set; }

    }
}
