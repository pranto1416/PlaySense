using UnityEngine;
using PlaySense.Data.Models;
using PlaySense.Recording;
using PlaySense.Export;

namespace PlaySense.Core
{
    public class PlaySenseManager : MonoBehaviour
    {
        [SerializeField]
        private float sampleRate = 20f;

        private SessionRecorder _recorder;
        private PlaySenseAgent[] _agents;

        private float _timer;

        private void Awake()
        {
            Debug.Log("PlaySense Awake");

            _recorder = new SessionRecorder();
            _agents = FindObjectsByType<PlaySenseAgent>(
                FindObjectsSortMode.None);

            Debug.Log($"Found {_agents.Length} agents.");
        }

        private void Start()
        {
            Debug.Log("Starting PlaySense...");

            _recorder.StartRecording();

            Debug.Log("Recording Started!");
        }

        public void RecordEvent(GameEventData gameEvent){
            _recorder.RecordEvent(gameEvent);
        }

        private void Update()
        {
            _timer += Time.deltaTime;

            if (_timer < 1f / sampleRate)
                return;

            _timer = 0f;

            foreach (var agent in _agents)
            {
                _recorder.RecordTrackable(agent);
            }
        }

        private void OnDestroy()
        {
            SessionData session = _recorder.StopRecording();

            if (session == null || session.Frames.Count == 0)
                return;

            SessionStorage.Save(session);

            Debug.Log("====== PLAYSENSE ======");
            Debug.Log($"Frames: {session.Metrics.FrameCount}");
            Debug.Log($"Duration: {session.Metrics.Duration:F2}s");
            Debug.Log($"Distance: {session.Metrics.TotalDistance:F2}m");
            Debug.Log($"Average Speed: {session.Metrics.AverageSpeed:F2}m/s");
        }
    }
}