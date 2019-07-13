using System;
namespace OracleInterface
{
    [Serializable]
    public class Velocity
    {
        public float vx, vy, vz, magnitude;

        public Velocity(float vx, float vy, float vz, float magnitude)
        {
            this.vx = vx;
            this.vy = vy;
            this.vz = vz;
            this.magnitude = magnitude;
        }
    }
}
