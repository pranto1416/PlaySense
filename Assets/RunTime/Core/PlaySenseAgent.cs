using UnityEngine;

namespace PlaySense.Core
{
    public class PlaySenseAgent : MonoBehaviour
    {
        public bool IsMoving { get; private set; }

        private Vector3 _lastPosition;

        private void Awake()
        {
            _lastPosition = transform.position;
        }

        private void Update()
        {
            float distance =
                Vector3.Distance(transform.position, _lastPosition);

            IsMoving = distance > 0.001f;

            _lastPosition = transform.position;
        }
    }
}