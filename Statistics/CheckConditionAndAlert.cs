using System;
using System.Collections.Generic;

namespace Statistics
{
    public class StatsAlerter
    {
        double maxThreshold;
        IAlerter[] alert;

        public StatsAlerter(double _maxThreshold, IAlerter[] _alert)
        {
            this.maxThreshold = _maxThreshold;
            this.alert = _alert;
            
        }
        public void checkAndAlert(List<double> numbers)
        {
            int index = 0;
            for(int i=0; i< numbers.Count; i++){
                if(numbers[i]>maxThreshold){
                    alert[index++].SendAlert();
                }
            }
        }
        
    }
    
}