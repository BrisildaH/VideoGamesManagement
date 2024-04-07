﻿using System.ComponentModel.DataAnnotations;

namespace VideogamesManagement.DataLayer.Entitites
{
    public class VideoGame
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public int Size { get; set; }
        [Required]
        public string Studio { get; set; }
    }
}
