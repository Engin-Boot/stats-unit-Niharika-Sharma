﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Statistics
{
    public class StatsComputer
    {
        //In further modifications we can make this more reusable 
        //By using something like: IEnumerable<T> numbers
        //Rather than restriction the function to accept list of double data type
        public Stats CalculateStatistics(List<double> numbers) 
        {
            if(numbers.Count == 0)
            {
                return new Stats(Double.NaN,Double.NaN,Double.NaN);
            }
            
            double average = Queryable.Average(numbers.AsQueryable());;
            double min = Enumerable.Min(numbers);
            double max = Enumerable.Max(numbers);

            
            return new Stats(average,max,min);    
        }

        
    }
}