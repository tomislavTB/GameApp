using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using GameApp.Models.Attributes;

namespace GameApp.Api.Responses
{
    public class PlayerResponse
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Wins { get; set; }

        public string Loses { get; set; }


    }
}
