using System;
using System.Collections.Generic;


namespace Statistics
{
    public interface IAlerter
    {
        bool SendAlert();
    }

    public class EmailAlert :  IAlerter
    {
        static bool emailSent;
        public bool SendAlert()
        {
            emailSent = true;
            return emailSent;           
        }       
        

    }

     public class LEDAlert :  IAlerter
    {
        public bool ledGlows;
        public bool SendAlert()
        {
            ledGlows = true;
            return ledGlows;
            
        }

    }

}