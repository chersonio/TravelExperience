﻿using System;
using System.Collections.Generic;
using System.Linq;
using TravelExperience.DataAccess.Core.Entities;

namespace TravelExperience.DataAccess.Core.Interfaces
{
    public interface IExperienceRepository : IDisposable
    {
        IEnumerable<Experience> GetAll();
        IQueryable<Experience> Get();
        Booking GetById(int? id);
        void Create(Experience experience);
        void Update(Experience experience);
        void Delete(int? id);
    }
}