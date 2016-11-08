using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Models
{
    public class User
    {
        private ICollection<Image> images;

        public User()
        {
            this.images = new HashSet<Image>();
        }
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Username length")]
        public string Username { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "Firstname length")]
        public string Firstname { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "Lastname length")]
        public string LastName { get; set; }

        public DateTime RegistrationDate { get; set; }

        public ICollection<Image> Images
        {
            get { return images; }
            set { images = value; }
        }

    }
}
