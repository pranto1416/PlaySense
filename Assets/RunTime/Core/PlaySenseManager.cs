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
        private PlaySenseTrackable[] _trackables;

        private float _timer;

        private void Awake()
        {
            Debug.Log("PlaySense Awake");

            _recorder = new SessionRecorder();

            _trackables = FindObjectsByType<PlaySenseTrackable>(
                FindObjectsSortMode.None);

            Debug.Log($"Found {_trackables.Length} trackables.");
        }

        private void Start()
        {
            Debug.Log("Starting PlaySense...");

            _recorder.StartRecording();

            Debug.Log("Recording Started!");
        }

        private void Update()
        {
            _timer += Time.deltaTime;

            if (_timer < 1f / sampleRate)
                return;

            _timer = 0f;

            foreach (var trackable in _trackables)
            {
                _recorder.RecordTrackable(trackable);
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