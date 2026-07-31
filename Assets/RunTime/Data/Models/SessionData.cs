using System;
using System.Collections.Generic;

namespace PlaySense.Data.Models
{
    [Serializable]
    public class SessionData
    {
        public string SessionId;

        public string SceneName;

        public float Duration;

        public List<FrameData> Frames = new();

        public List<GameEventData> Events = new();
    }
}