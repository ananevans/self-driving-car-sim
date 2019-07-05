using System;
using System.Collections.Generic;

namespace OracleInterface
{
    [Serializable]
    public class UpdateMessage
    {
        private Vehicle ego_vehicle;

        private List<Vehicle> traffic;

        public UpdateMessage(Vehicle vehicle, List<Vehicle> traffic)
        {
            this.ego_vehicle = vehicle;
            this.traffic = traffic;
        }
    }
}
