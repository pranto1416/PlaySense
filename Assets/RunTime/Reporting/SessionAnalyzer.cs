using UnityEngine;
using PlaySense.Data.Models;

namespace PlaySense.Reporting
{
    public class SessionAnalyzer
    {
        public SessionMetrics Analyze(SessionData session)
        {
            SessionMetrics metrics = new();

            metrics.FrameCount = session.Frames.Count;

            metrics.Duration = session.Duration;

            float distance = 0f;

            for (int i = 1; i < session.Frames.Count; i++)
            {
                distance += Vector3.Distance(
                    session.Frames[i - 1].Position,
                    session.Frames[i].Position);
            }

            metrics.TotalDistance = distance;

            metrics.AverageSpeed =
                session.Duration > 0
                ? distance / session.Duration
                : 0f;

            return metrics;
        }
    }
}