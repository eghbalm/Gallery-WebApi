using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PicoSystem_Gallery.Models
{
    public class tbl_Photo
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(200)]
        public string PhotoPath { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        public DateTime tarikhUpload { get; set; }
    }
}