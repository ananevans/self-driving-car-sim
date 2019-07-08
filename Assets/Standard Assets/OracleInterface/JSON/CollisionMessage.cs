using System;
namespace OracleInterface
{
    [Serializable]
    public class CollisionMessage
    {
        public const int VEHICLE = 1;

        public const int STATIC_SCENERY = 2;

        public const int PEDESTRIAN = 3;

        public const int BICYCLE = 4;

        public int collisionType;

        public string info;

        public CollisionMessage( int collisionType, string info )
        {
            this.collisionType = collisionType;
            this.info = info;
        }
    }
}
