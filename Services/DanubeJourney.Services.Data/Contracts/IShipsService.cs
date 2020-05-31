﻿namespace DanubeJourney.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DanubeJourney.Web.InputModels.Ships;
    using DanubeJourney.Web.ViewModels.Ships;

    public interface IShipsService
    {
        Task<int> Create(ShipInputModel model);

        ShipViewModel Details(string id);

        ICollection<T> GetModels<T>();

        T GetModel<T>(string id);

        Task<string> Edit(ShipViewModel model);

        Task<int> Delete(string id);
    }
}
