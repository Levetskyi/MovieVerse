﻿using MovieVerse.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace MovieVerse.Models
{
    public class Cinema : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Logo { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Movie>? Movies { get; set; }
    }
}