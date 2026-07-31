using UnityEngine;
using PlaySense.Recording;

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
            _recorder.StartRecording();
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

            Debug.Log($"Frames: {_recorder.CurrentSession.Frames.Count}");
        }

        private void OnDestroy()
        {
              Debug.Log($"Frames Recorded: {_recorder.CurrentSession.Frames.Count}");

              if (_recorder.CurrentSession.Frames.Count == 0)
                    return;

              var first = _recorder.CurrentSession.Frames[0];
              var last = _recorder.CurrentSession.Frames[^1];

              Debug.Log($"FIRST FRAME");
              Debug.Log($"Object: {first.ObjectName}");
              Debug.Log($"Position: {first.Position}");
              Debug.Log($"Time: {first.Timestamp}");

              Debug.Log("----------------");

              Debug.Log($"LAST FRAME");
              Debug.Log($"Object: {last.ObjectName}");
              Debug.Log($"Position: {last.Position}");
              Debug.Log($"Time: {last.Timestamp}");
        }
    }
}