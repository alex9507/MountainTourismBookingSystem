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

        public string location_coordinates { get; set; }

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

        [Required]
        public int? beds { get; set; }
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

INSERT INTO Chalet
(
	dt
	, mountain_type
	, region_type
	, chalet_type
	, name
	, information
	, picture
	, location_info
	, location_coordinated
	, location_map
	, altitude
	, starting_point
	, owner
	, gsm
	, contacts
	, routes
    , beds
)
VALUES
(
	GETDATE()
	, N'015'
	, N'025'
	, N'003'
	, N'Аида'
	, N'Намира се в рида Мечковец, в подножието на едноименния връх на 760 м. надморска височина. Представлява масивна, двуетажна сграда с капацитет 45 места в стаи с по 2, 3, 5, 7 и повече легла, с външни санитарни възли и вътрешни умивални и бани. Сградата е водоснабдена и електрифицирана, отоплението е с печки на ток и твърдо гориво.<BR> Разполага с ресторант, бюфет, туристическа кухня и столова, телевизор, забавни игри. Районът е подходящ за къмпиране, пътят до хижата е асфалтиран, има паркинг.<BR> Възможност за да конна езда, туристически пътеки с маркирани маршрути.<BR>'
	, N'Aida.jpg'
	, N'Намира се в Източните Родопи, Хасковска хълмиста област, рид Мечковец в подножието на едноименния връх (до 1942 г.: Аида, 860 метра надморска височина) <BR>'
	, N'+41° 54'' 16.03", +25° 17'' 55.47"<BR> N41.904453, E25.298743<BR>'
	, N'https://www.google.com/maps/d/embed?mid=1p5Leuz2jEKqv9M42kTPadckgj_mEHvBa&ll=41.90481411448309%2C25.299535318164885&amp%3Bspn=0.102213%2C0.188484&z=17'
	, N'760 метра'
	, N'От село Хасковски минерални бани - 9 км асфалтово шосе, 2 часа  пеш по маркирана пътека.<BR> Селото отстои на 19 км от град Хасково, с който има редовна автобусна връзка.<BR> От село Паничково - 6,00 часа. <BR>'
	, N'ТД "Аида" - гр. Хасково, 6300, ул. "Средна гора" № 2, ПК 89<BR>'
	, N'GSM: 038 / 62 25 90'
	, N'GSM: 0898 519 815, 0896 766 171'
	, N'връх Мечковец /Аида/ - 0,30 часа <BR> скалният феномен Айкас - 1 км. <BR> местност Шарапаните (с най-добре запазените "шарапани" - винарни от тракийско време - І хил. пр. н. е.) - 1 час <BR> хижа Буково - 3,00 часа <BR> хижа Сини връх - 9,00 часа <BR> хижа Книжовник - 9,00 часа <BR> Традиционният маршрут е до хижа "Сини връх" през село Паничково. За тренирани туристи се изминава за един ден, при тръгване рано сутрин през зимата. Можете да планирате преспиване в село Паничково или в околностите му с палатка.<BR>'
    , 45
)
 */
