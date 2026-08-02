using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlaySense.Data.Models
{
    [Serializable]
    public class GameEventData
    {
        public string Category;

        public string Action;

        public string Target;

        public float Timestamp;

        public float Duration;

        public Vector3 Position;

        public List<EventParameter> Metadata = new();
    }
}