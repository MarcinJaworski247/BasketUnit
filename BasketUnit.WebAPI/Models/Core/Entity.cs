﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Models
{
    public abstract class Entity
    {
        public int Id { get; set; }
    }
    public abstract class Entity<T> where T : class
    {
        public T Id { get; set; }
    }
}
