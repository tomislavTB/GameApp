using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using GameApp.Models.Attributes;

namespace GameApp.Models
{
    public class Player : BaseModel
    {

        [CustomRequired]
        public string FirstName { get; set; }

        [CustomRequired]
        public string LastName { get; set; }

        public string Wins { get; set; }

        public string Loses { get; set; }


        public ICollection<Game> Games { get; set; }
    }
}