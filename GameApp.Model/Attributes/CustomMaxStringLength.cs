﻿
using System.ComponentModel.DataAnnotations;

namespace GameApp.Models.Attributes
{
    public class CustomMaxStringLength : StringLengthAttribute
    {
        public CustomMaxStringLength(int maximumLength) : base(maximumLength)
        { }

        public override string FormatErrorMessage(string name)
        {
            return $"\"{name}\" je ograničen na {MaximumLength} znakova!";
        }
    }
}

