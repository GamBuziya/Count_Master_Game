using UnityEngine;

namespace DefaultNamespace.ScriptableObjects
{
    [CreateAssetMenu()]
    public class AudioClipRefSO : ScriptableObject
    {
        public AudioClip Button;
        public AudioClip Run;
        public AudioClip GateMove;
        public AudioClip Fail;
        public AudioClip Finish;
        public AudioClip Jump;
        public AudioClip ChangeUI;
        public AudioClip[] KillZone;
        public AudioClip[] Fight;
    }
}