using UnityEngine;
using PlaySense.Data.Models;

namespace PlaySense.Reporting
{
    public class SessionAnalyzer
    {
        public SessionMetrics Analyze(SessionData session)
        {
            SessionMetrics metrics = new();

            metrics.RecordedFrames = session.Frames.Count;

            if (session.Frames.Count < 2)
                return metrics;

            float totalDistance = 0f;

            for (int i = 1; i < session.Frames.Count; i++)
            {
                totalDistance += Vector3.Distance(
                    session.Frames[i - 1].Position,
                    session.Frames[i].Position);
            }

            metrics.DistanceTravelled = totalDistance;

            metrics.Duration =
                session.Frames[^1].Timestamp -
                session.Frames[0].Timestamp;

            if (metrics.Duration > 0f)
            {
                metrics.AverageSpeed =
                    totalDistance / metrics.Duration;
            }

            return metrics;
        }
    }
}