using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using GameApp.Models.Attributes;

namespace GameApp.Models
{
    public class Game:BaseModel
    {

        [CustomRequired]
        public string GameName { get; set; }

        [CustomRequired]
        public string Expansion { get; set; }

    }
}
