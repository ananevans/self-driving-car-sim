using System;
namespace OracleInterface
{
    [Serializable]
    public class Velocity
    {
        private float vx, vy, vz;

        public Velocity(float vx, float vy, float vz)
        {
            this.vx = vx;
            this.vy = vy;
            this.vz = vz;
        }
    }
}
