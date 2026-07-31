using UnityEngine;
using PlaySense.Data.Models;

namespace PlaySense.Recording
{
    public class SessionRecorder
    {
        private readonly SessionData _session = new();

        public SessionData CurrentSession => _session;

        public void StartRecording()
        {
            _session.Frames.Clear();
            _session.Events.Clear();
        }

        public void RecordFrame(
            string objectName,
            float timestamp,
            Vector3 position,
            Quaternion rotation)
        {
            _session.Frames.Add(new PlaySense.Data.Models.FrameData
            {
                ObjectName = objectName,
                Timestamp = timestamp,
                Position = position,
                Rotation = rotation
            });
        }
    }
}