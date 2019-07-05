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

        private int collisionType;

        private int objectID;

        public CollisionMessage( int collisionType, int id )
        {
            this.collisionType = collisionType;
            this.objectID = id;
        }
    }
}
