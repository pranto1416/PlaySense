using UnityEngine;

namespace PlaySense.Recording{


    public class PlaySenseTrackable : MonoBehaviour{
        public Transform CachedTransform{ get; private set; }

        private void Awake(){
            CachedTransform = transform;
            
        }
    }
}
