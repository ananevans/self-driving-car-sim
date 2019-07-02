using System;

namespace UnityStandardAssets.Vehicles.Car
{
    [Serializable]
    public class Config
    {
        public int forwardCarsCount = 12;
        public int reverseCarsCount = 6;
        public float d_min = -2;
        public float d_max = 14;
        public int zero_speed_interval = 60;
        public float dist_without_incident = 6952.366f;
        public float dist_max = 8046.72f;
    }
}