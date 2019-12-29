using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MountainTourismBookingSystem.Models
{
    public class RoleModel
    {
        [Required]
        public string role_name { get; set; }
    }
}
