using PlaySense.Data.Models;
using UnityEngine;

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

        public void RecordTrackable(PlaySenseTrackable trackable)
        {
            Transform t = trackable.CachedTransform;

            _session.Frames.Add(new FrameData
            {
                ObjectName = trackable.name,
                Timestamp = Time.time,
                Position = t.position,
                Rotation = t.rotation
            });
        }
    }
}