using System;
namespace OracleInterface
{
    [Serializable]
    public class JerkMessage
    {

        public float magnitude;

        public float delta_t;

        public JerkMessage()
        {
        }

        public JerkMessage(float magnitude, float delta_t)
        {
            this.magnitude = magnitude;
            this.delta_t = delta_t;
        }
    }
}
