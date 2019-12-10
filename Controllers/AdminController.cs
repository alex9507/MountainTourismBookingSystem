﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MountainTourismBookingSystem.Data;
using MountainTourismBookingSystem.Models;
using Newtonsoft.Json;

namespace MountainTourismBookingSystem.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public AdminController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Management()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetData()
        {
            var data = (from c in _dbContext.Chalet
                           join t in _dbContext.ChaletType on c.chalet_type equals t.code
                           join r in _dbContext.Region on c.region_type equals r.code
                           join m in _dbContext.Mountain on c.mountain_type equals m.code
                           select new
                           {
                               c_name = c.name,
                               c_chalet_type = t.description,
                               c_region_type = r.description,
                               c_mountain_type = m.description,
                               c_beds = c.beds,
                               c_id = c.unique_id
                           }).ToList();

            return Json(data);
        }

        [HttpPost]
        public JsonResult GetChaletInfoById(Guid id)
        {
            var data = _dbContext.Chalet.Where(x => x.unique_id == id).FirstOrDefault();

            return Json(data);
        }

        [HttpPost]
        public JsonResult SaveEditChaletData(ChaletModel data)
        {
            if (data.unique_id != Guid.Empty)
            {
                var vData = _dbContext.Chalet.Where(x => x.unique_id == data.unique_id).FirstOrDefault();
                if (vData != null)
                {
                    vData.unique_id =               data.unique_id;
                    vData.dt =                      DateTime.Now;
                    vData.information =             data.information;
                    vData.picture =                 data.picture;
                    vData.location_info =           data.location_info;
                    vData.location_coordinates =    data.location_coordinates;
                    vData.location_map =            data.location_map;
                    vData.altitude =                data.altitude;
                    vData.starting_point =          data.starting_point;
                    vData.owner =                   data.owner;
                    vData.gsm =                     data.gsm;
                    vData.contacts =                data.contacts;
                    vData.routes =                  data.routes;
                    vData.beds =                    data.beds;
                    vData.price =                   data.price;
                    vData.chalet_type =             data.chalet_type;
                    vData.region_type =             data.region_type;
                    vData.mountain_type =           data.mountain_type;
                }
            }
            else
            {
                data.dt = DateTime.Now;
                _dbContext.Chalet.Add(data);
            }

            return Json(data);
        }
    }
}