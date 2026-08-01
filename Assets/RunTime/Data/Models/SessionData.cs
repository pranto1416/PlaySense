using System;
using System.Collections.Generic;

namespace PlaySense.Data.Models
{
    [Serializable]
    public class SessionData
    {
        public string Version = "0.1.0";

        public string SessionId;

        public string SceneName;

        public string StartTime;

        public string EndTime;

        public float Duration;

        public SessionMetrics Metrics = new();

        public List<FrameData> Frames = new();

        public List<GameEventData> Events = new();
    }
}