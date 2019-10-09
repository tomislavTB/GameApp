using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using GameApp.Models.Attributes;
using GameApp.Models;

namespace GameApp.Api.Responses
{
    public class GameResponse
    {
        public long Id { get; set; }

        public string GameName { get; set; }

        public string Extension { get; set; }

    }
}
