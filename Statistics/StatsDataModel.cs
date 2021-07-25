using System;
using System.Collections.Generic;

namespace Statistics
{
    public class Stats
    {
        public double average {get; set;}
        public double max {get; set;}
        public double min {get; set;}

        public Stats(double _average, double _max, double _min){
            this.average = _average;
            this.max = _max;
            this.min = _min;
        } 
    }
}