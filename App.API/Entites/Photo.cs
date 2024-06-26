﻿
using System.ComponentModel.DataAnnotations.Schema;

namespace App.API.Entites
{
    [Table("Photos")]
    public class Photo
    {

        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsMine { get; set; }
        public string? PublicId { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
