﻿using BasketUnit.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Services
{
    public interface ITeamScheduleActivityService
    {
        void AddWorkout(AddWorkoutScheduleVM model);
    }
}
