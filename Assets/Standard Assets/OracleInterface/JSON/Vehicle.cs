using System;
namespace OracleInterface
{
    [Serializable]
    public class Vehicle
    {
        private int id;

        private Position position;

        private Frenet frenet;

        private Velocity velocity;

        public Vehicle( int id, Position position, Frenet frenet, 
            Velocity velocity )
        {
            this.id = id;
            this.position = position;
            this.frenet = frenet;
            this.velocity = velocity;
        }
    }
}
