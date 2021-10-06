using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyTestApp.ViewModels
{
    public class UserRegistrationModel
    {
        [Required]
        [StringLength(255, ErrorMessage = "The ThumbnailPhotoFileName value cannot exceed 255 characters. ")]
        public string Name { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "The ThumbnailPhotoFileName value cannot exceed 255 characters. ")]
        public string Login { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "The ThumbnailPhotoFileName value cannot exceed 255 characters. ")]
        public string Password { get; set; }
        
        [Required]
        [StringLength(255, ErrorMessage = "The ThumbnailPhotoFileName value cannot exceed 255 characters. ")]
        public string PasswordConfirmation { get; set; }
    }
}
