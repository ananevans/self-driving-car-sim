using System;

namespace UnityStandardAssets.Vehicles.Car
{
    [Serializable]
    public class Config
    {
        public int forwardCarsCount = 12;
        public int reverseCarsCount = 6;
        //public float d_min = -2;
        //public float d_max = 14;
        public float d_min = -20;
        public float d_max = 25;
        public int zero_speed_interval = 30;
        //public float dist_without_incident = 6952.366f;
        //public float dist_max = 8046.72f;
        public float dist_without_incident = 0.0f;
        public float dist_max = 0.0f;
        public float timeout = 2*60.0f;
    }
}