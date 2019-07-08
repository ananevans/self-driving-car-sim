using System;
using System.Collections.Generic;

namespace OracleInterface
{
    [Serializable]
    public class UpdateMessage
    {
        public Vehicle ego_vehicle;

        public List<Vehicle> traffic;

        public float delta_t;

        public UpdateMessage(Vehicle vehicle, List<Vehicle> traffic, float delta_t)
        {
            this.ego_vehicle = vehicle;
            this.traffic = traffic;
            this.delta_t = delta_t;
        }
    }
}
