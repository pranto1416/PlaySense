using System;

namespace PlaySense.Data.Models
{
    [Serializable]
    public class SessionMetrics
    {
        public int FrameCount;

        public float Duration;

        public float TotalDistance;

        public float AverageSpeed;
    }
}