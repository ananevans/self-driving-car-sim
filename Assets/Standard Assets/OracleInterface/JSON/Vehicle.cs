using System;
namespace OracleInterface
{
    [Serializable]
    public class Vehicle
    {
        public int id;

        public Position position;

        public Frenet frenet;

        public Velocity velocity;

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
