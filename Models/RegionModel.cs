using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MountainTourismBookingSystem.Models
{
    public class RegionModel
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
CREATE TABLE nm_region
(
	code CHAR(3) NOT NULL,
	description NVARCHAR(250) NOT NULL
)
GO

With Migration:
INSERT INTO Region (code, description)
VALUES
  ('001', N'Благоевград')
, ('002', N'Бургас')
, ('003', N'Варна')
, ('004', N'Велико Търново')
, ('005', N'Видин')
, ('006', N'Враца')
, ('007', N'Габрово')
, ('008', N'Кърджали')
, ('009', N'Кюстендил')
, ('010', N'Ловеч')
, ('011', N'Монтана')
, ('012', N'Пазарджик')
, ('013', N'Перник')
, ('014', N'Плевен')
, ('015', N'Пловдив')
, ('016', N'Разград')
, ('017', N'Русе')
, ('018', N'Силистра')
, ('019', N'Сливен')
, ('020', N'Смолян')
, ('021', N'София - област')
, ('022', N'София - град')
, ('023', N'Стара Загора')
, ('024', N'Търговище')
, ('025', N'Хасково')
, ('026', N'Шумен')
, ('027', N'Ямбол')
GO
 */
