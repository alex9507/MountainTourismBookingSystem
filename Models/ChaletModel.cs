﻿using System;
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
        public long? chalet_id { get; set; }

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

        [Required]
        public double? price { get; set; }

        [Required]
        public Guid unique_id { get; set; }
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
	, location_coordinates
	, location_map
	, altitude
	, starting_point
	, owner
	, gsm
	, contacts
	, routes
    , beds
    , price
    , unique_id

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
    , 10
    , '0143aad9-6630-472a-ac2e-100b051410dc'
)

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
	, location_coordinates
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
	, N'023'
	, N'010'
	, N'003'
	, N'Амбарица'
	, N'Хижа Амбарица се намира на 1520м надморска височина, североизточно от връх Момина могила в Троянската планина, дял на Средна Стара планина. Състои се от две двуетажни сгради – стара (построена 1935 – 1936 г) и нова (построена 1953 – 1960 г). Към момента старата сграда е необитаема. Капацитетът на хижата е 58 места в стаи с по 4, 8 и 12 легла. Хижата посреща гости целогодишно. Препоръчително е когато планувате посещение на Амбарица да се свържете с хижарите за актуална информация по един от следните начини: GSM - 0887 895 662, телефон - 02/ 491 00 05, Viber – 0887 895 662 ( към 05.11.2018).<BR> Туристите могат да се възползват от удобствата на вътрешни тоалетни, баня с бойлер на дърва, столова с туристическа кухня, богата библиотека, безжичен интернет (Free Wi-Fi) и разнообразни настолни игри.<BR>Хижата има осигурено непрекъснато снабдяване с чиста, изворна вода от подножието на вр.Голям Купен. Електроенергия е осигурена от фотоволтаични панели и не е достатъчна за ползване на електроуреди с висока мощност като сешоари, бързовари и т.н. Отоплението е с печки на твърдо гориво, локално във всяко помещение.<BR><BR>Районът предоставя отлични условия за отдих както през лятото, така и през зимата. В сърцето на Национален парк „Централен Балкан”, от хижа Амбарица се открива величествена панорама към централното било на Стара планина и връх Ботев. Красиви и предизвикателни са маршрутите до трите обекта в района – връх Голям Купен, връх Амбарица и скален мост Маркова дупка. В миналото Амбарица е била популярна дестинация за зимни ски лагери с 3 ски влека, но днес тази инфраструктура не функционира.<BR>През последните години името на хижата се свързва с Фестивала на боровинките, Боровинковите нощи, които са традиционно събитие през последните почивни дни на месец юли.<BR> До хижата се стига единствено след преход пеш, път за автомобили няма. Всички доставки на хранителни стоки и материали се осъществяват с коня Борко или на гръб.<BR>'
	, N'Ambaritza.jpg'
	, N'Намира се в северните склонове на Стара планина в местността Дълги дял, източно от връх Момина могила <BR>'
	, N'+42° 45'' 18.65", +24° 46'' 42.33"<BR> N42.755180 , E24.778425<BR>'
	, N'https://www.google.com/maps/d/embed?mid=1p5Leuz2jEKqv9M42kTPadckgj_mEHvBa&ll=42.75560197777286%2C24.777106690945175&amp%3Bspn=0.102213%2C0.188484&z=17'
	, N'1503 метра'
	, N'Местността Смесите - 3,00 часа. Местността отстои от гр. Троян на 17 км по асфалтово шосе <BR>  град Карлово - 6,00 часа /през хижа Хубавец/. Градът има ж. п. гара по линията София - Бургас. На нея спират всички влакове. Отстои от гр. София на 149 км, от гр. Пловдив - на 67 км, от град Бургас - на 269 км. <BR> град Сопот - 4,10 часа /със седалковата въжена линия и през хижа Добрила/.<BR>'
	, N'Сдружение Планинска школа Амбарица, председател Емилия Гатева<BR>'
	, N'GSM: 0887 895 662'
	, N'GSM: 0887 895 662, 02/ 491 00 05'
	, N'връх Левски /Амбарица - 2166 м/ - 2,30 часа <BR> връх Голям Купен /2169 м/ - 3,00 часа <BR> Марковата дупка - 3,00 часа <BR> хижа  Добрила - 3,00 часа <BR>хижа  Дерменка - 5,30 часа <BR>  хижа Васил Левски- 4,30 часа <BR>  хижа Хубавец - 4,00 часа <BR> хижа  Плевен - 6,00 часа /през връх Костенурката/ <BR> хижа Яворова лъка - 2,00 часа <BR>'
    , 58
    , 12
    , '4a5f56e3-8f13-4e1c-82ba-ec7deea81653'
)



 */
