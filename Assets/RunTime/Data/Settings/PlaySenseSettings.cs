using UnityEngine;

namespace PlaySense.Settings
{
    [CreateAssetMenu(
        fileName = "PlaySenseSettings",
        menuName = "PlaySense/Settings",
        order = 0
    )]

    public class PlaySenseSettings : ScriptableObject{

        [Header("Recording")]

        [Tooltip("How many times per second the recorder samples player data.")]
        [Range(1, 120)]
        public int samplingRate = 20;

        [Tooltip("Maximum recording duration in minutes")]
        [Min(1)]
        public int maxRecordingMinutes = 30;

        [Header("Replay")]

        [Tooltip("Playback speed multiplier")]
        [Min(0.1f)]
        public float replaySpeed = 1f;

        [Header("Export")]

        [Tooltip("Automatically export session when recording stops.")]
        public bool autoExport = true; 

    }
}
