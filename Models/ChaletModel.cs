using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace MountainTourismBookingSystem.Models
{
    public class ChaletModel
    {
        [Key]
        [Required]
        public long? challet_id { get; set; }

        [Required]
        public DateTime dt { get; set; }

        [Required]
        [MaxLength(3)]
        public string mountain_type { get; set; }

        [Required]
        [MaxLength(3)]
        public string region_type { get; set; }

        [Required]
        [MaxLength(3)]
        public string chalet_type { get; set; }

        [MaxLength(250)]
        public string name { get; set; }

        public string information { get; set; }

        public string picture { get; set; }

        public string location_info { get; set; }

        public string location_coordinated { get; set; }

        public string location_map { get; set; }

        [MaxLength(10)]
        public string altitude { get; set; }

        [MaxLength(250)]
        public string starting_point { get; set; }

        [MaxLength(200)]
        public string owner { get; set; }

        [MaxLength(50)]
        public string gsm { get; set; }

        [MaxLength(200)]
        public string contacts { get; set; }

        public string routes { get; set; }
    }
}

/* 
OLD:
CREATE TABLE chalet
(
	id BIGINT IDENTITY(1,1) NOT NULL,
	dt DATETIME NOT NULL,
	mountain_type CHAR(3) NOT NULL,
	region_type CHAR(3) NOT NULL,
	chalet_type CHAR(3) NOT NULL,
	name NVARCHAR(250) NOT NULL,
	information NVARCHAR(MAX) NULL,
	picture VARCHAR(100) NULL,
	location_info NVARCHAR(MAX) NULL,
	location_coordinated NVARCHAR(MAX) NULL,
	location_map NVARCHAR(MAX) NULL,
	altitude VARCHAR(10) NULL,
	starting_point NVARCHAR(100) NULL,
	owner NVARCHAR(200) NULL,
	gsm VARCHAR(50) NULL,
	contacts NVARCHAR(200) NULL,
	routes NVARCHAR(MAX) NULL,
)
GO
 */
