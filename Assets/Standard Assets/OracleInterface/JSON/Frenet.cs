using System;
namespace OracleInterface
{
    [Serializable]
    public class Frenet
    {
        private float s, d;
        public Frenet(float s, float d)
        {
            this.s = s;
            this.d = d;
        }
    }
}
