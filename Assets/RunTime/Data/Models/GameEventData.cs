using System;
using System.Collections.Generic;

namespace PlaySense.Data.Models
{
    [Serializable]
    public class GameEventData
    {
        public string Type;

        public float Timestamp;

        public List<EventParameter> Parameters = new();
    }

    [Serializable]
    public class EventParameter
    {
        public string Key;
        public string Value;
        
    }
}