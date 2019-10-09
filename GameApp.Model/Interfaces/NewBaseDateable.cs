using GameApp.Models.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace GameApp.Models.Interfaces
{
    public interface NewBaseDateable
    {
        [DataType(DataType.DateTime)]
        [CustomRequired]
        [CustomDateRange]
        DateTime CreatedAt { get; set; }

        [DataType(DataType.DateTime)]
        [CustomDateRange]
        DateTime? LastModifiedAt { get; set; }
    }
}

