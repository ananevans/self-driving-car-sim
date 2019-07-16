using System;
namespace OracleInterface
{
    [Serializable]
    public class AccelerationMessage
    {
        public float tangential;

        public float normal;

        public float magnitude;

        public float delta_t;

        public AccelerationMessage()
        {
        }

        public AccelerationMessage(float tangential, float normal, float magnitude, float delta_t)
        {
            this.tangential = tangential;
            this.normal = normal;
            this.magnitude = magnitude;
            this.delta_t = delta_t;
        }
    }
}
