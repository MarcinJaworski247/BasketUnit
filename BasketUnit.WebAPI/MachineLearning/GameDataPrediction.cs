using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI
{
    public class GameDataPrediction
    {
        [ColumnName("Score")]
        public float Result { get; set; }
    }
}
