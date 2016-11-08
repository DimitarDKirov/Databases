
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Models
{
    public class Image
    {
        public int Id { get; set; }

        [Required]
        public string Url { get; set; }

        [MaxLength(4, ErrorMessage = "File extension length")]
        [Required]
        public string FileExtension { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
