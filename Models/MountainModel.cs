using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MountainTourismBookingSystem.Models
{
    public class MountainModel
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
CREATE TABLE nm_mountain
(
    code CHAR(3) NOT NULL,
    description NVARCHAR(250) NOT NULL
)
GO

With Migration:
INSERT INTO Mountain(code, description)
VALUES
  ('001', N'Беласица')
, ('002', N'Витоша')
, ('003', N'Влахина')
, ('004', N'Голо бърдо')
, ('005', N'Конявска планина')
, ('006', N'Люлин')
, ('007', N'Осоговска планина')
, ('008', N'Пирин')
, ('009', N'Плана')
, ('010', N'Предбалкан - западен')
, ('011', N'Предбалкан - среден')
, ('012', N'Предбалкан - източен')
, ('013', N'Рила')
, ('014', N'Родопи - западни')
, ('015', N'Родопи - западни')
, ('016', N'Рудини')
, ('017', N'Руй')
, ('018', N'Славянка')
, ('019', N'Средна гора - ихтимаснка')
, ('020', N'Средна гора - същинска')
, ('021', N'Средна гора - сърнена')
, ('022', N'Стара планина - западна')
, ('023', N'Стара планина - средна')
, ('024', N'Стара планина - източна')
, ('025', N'Странджа')
, ('026', N'Северна България - в равнините')
, ('027', N'Южна България - в равнините')
, ('028', N'Край р. Дунав')
, ('029', N'Край морето')
GO
*/