using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace xCubeApplication.Models
{
    public class UserDetails
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        [Required]
        [StringLength(10)]
        public string? Age { get; set; }

        [Required]
        public string? DateOfBirth { get; set; }

        [Required]
        [Phone]
        [StringLength(10)]
        public string? ContactNumber { get; set; }

        public string? ProfileImagePath { get; set; }

    }
}
