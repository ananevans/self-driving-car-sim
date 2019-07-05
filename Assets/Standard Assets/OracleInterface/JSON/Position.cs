using System;
namespace OracleInterface
{
    [Serializable]
    public class Position
    {
        private float x, y, z;

        public Position(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}
