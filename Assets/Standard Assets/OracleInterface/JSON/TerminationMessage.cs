using System;
namespace OracleInterface
{
    [Serializable]
    public class TerminationMessage
    {
        public const int STOPPED = 1;

        public const int DISTANCE_WITHOUT_INCIDENT = 2;

        public const int MAX_DISTANCE = 3;

        public const int OFF_ROAD = 4;

        public int type;

        public float data;

        public TerminationMessage(int type, float data)
        {
            this.type = type;
            this.data = data;
        }
    }
}
