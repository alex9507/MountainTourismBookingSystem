using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace MountainTourismBookingSystem.Models
{
    public class ReservationDataHelperModel
    {
        [Key]
        [Required]
        public long? reservation_helper_id { get; set; }

        [Required]
        public Guid unique_id { get; set; }

        [Required]
        public long? chalet_id { get; set; }

        [Required]
        public DateTime dt_from { get; set; }

        public DateTime dt_to { get; set; }

        public bool is_full_day { get; set; }

        [Required]
        public double? amount { get; set; }

        [MaxLength(3)]
        public string currency { get; set; }

        [Required]
        public int people_count { get; set; }

        [MaxLength(50)]
        public string color { get; set; }
    }
}
