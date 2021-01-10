using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI
{
    public class GameData
    {
        [LoadColumn(0)]
        public int OpponentId { get; set; }
        [LoadColumn(1)]
        public bool IsHome { get; set; }
        [LoadColumn(2)]
        public bool IsDayAfterDay { get; set; }
        [LoadColumn(3)]
        public float Result { get; set; }
    }
}
