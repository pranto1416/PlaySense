using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using PlaySense.Data.Models;
using PlaySense.Reporting;

namespace PlaySense.Recording
{
    public class SessionRecorder
    {
        private SessionData _session;

        private float _startTime;

        public void StartRecording()
        {
            _session = new SessionData();

            _session.SessionId = Guid.NewGuid().ToString();

            _startTime = Time.time;
        }

        public void RecordTrackable(PlaySenseTrackable trackable)
        {
            _session.Frames.Add(new FrameData
            {
                ObjectName = trackable.name,
                Timestamp = Time.time,
                Position = trackable.transform.position,
                Rotation = trackable.transform.rotation
            });
        }

        public void RecordEvent(GameEventData gameEvent)
        {
            _session.Events.Add(gameEvent);
        }

        public SessionData StopRecording()
        {
            _session.Duration = Time.time - _startTime;

            _session.SceneName =
                SceneManager.GetActiveScene().name;

            SessionAnalyzer analyzer = new();

            _session.Metrics =
                analyzer.Analyze(_session);

            return _session;
        }
    }
}