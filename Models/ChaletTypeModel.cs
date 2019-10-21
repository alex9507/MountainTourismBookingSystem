using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MountainTourismBookingSystem.Models
{
    public class ChaletTypeModel
    {
        [Key]
        [Required]
        [MaxLength(3)]
        public string code { get; set; }

        [Required]
        [MaxLength(250)]
        public string description { get; set; }
    }
}

/*
OLD:
CREATE TABLE nm_chalet_type
(
	code CHAR(3) NOT NULL,
	description NVARCHAR(250) NOT NULL
)
GO

With Migration:
INSERT INTO ChaletType (code, description)
VALUES
  ('001', N'Заслон')
, ('002', N'Туристическа спалня')
, ('003', N'Хижа')
GO
 */
