﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherSdk.Models.JsonModels
{
    public class JsonSummaryCollection
    {
        public List<ShortSummary> SummaryCollection { get; set; }
        public int Count { get; set; }
    }
}