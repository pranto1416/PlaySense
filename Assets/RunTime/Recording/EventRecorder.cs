using PlaySense.Data.Models;

namespace PlaySense.Recording
{
    public static class EventRecorder
    {
        public static void Record(
            SessionData session,
            GameEventData gameEvent)
        {
            session.Events.Add(gameEvent);
        }
    }
}