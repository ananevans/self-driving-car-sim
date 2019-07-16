using System;
namespace OracleInterface
{
    [Serializable]
    public class Message
    {
        public const int update = 1;

        public const int collision = 2;

        public const int termination = 3;

        public const int acceleration = 4;

        public const int jerk = 5;

        public int type;

        public string data;

        public Message()
        {
        }

        public Message(int type, string data)
        {
            this.type = type;
            this.data = data;
        }

    }
}
