using System;
namespace OracleInterface
{
    [Serializable]
    public class Frenet
    {
        public float s, d;

        public Frenet(float s, float d)
        {
            this.s = s;
            this.d = d;
        }
    }
}
