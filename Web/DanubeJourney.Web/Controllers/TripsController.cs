﻿namespace DanubeJourney.Web.Controllers
{
    using DanubeJourney.Services.Data.Contracts;
    using DanubeJourney.Web.InputModels.Trips;
    using DanubeJourney.Web.ViewModels.Trips;
    using Microsoft.AspNetCore.Mvc;

    public class TripsController : BaseController
    {
        private readonly ITripsService _tripsService;

        public TripsController(ITripsService tripsService)
        {
            this._tripsService = tripsService;
        }

        public IActionResult Index()
        {
            var model = this._tripsService.Index();
            return this.View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(TripInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            this.TempData["id"] = this._tripsService.Create(model);

            return this.RedirectToAction("Details");
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Edit(TripViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var result = this._tripsService.Edit(model);
            return this.RedirectToAction("Details");
        }


        public IActionResult Details(string id)
        {
            var model = this._tripsService.Details(id);
            return this.View(model);
        }

        
        [HttpGet]
        public IActionResult Delete()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Delete(TripViewModel model)
        {
           return this.View(model);
        }
    }
}
