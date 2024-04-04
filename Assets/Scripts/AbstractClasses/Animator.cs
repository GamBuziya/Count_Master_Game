using UnityEngine;

namespace AbstractClasses
{
    public class Animator : MonoBehaviour
    {
        public enum Animations
        {
            Run
        }
        
        protected void ActivateAnimation()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).CompareTag("OtherObj")) continue;

                var tempAnimator = transform.GetChild(i).GetComponent<UnityEngine.Animator>();
            
                tempAnimator.SetBool(Animations.Run.ToString(), true);
            }
        }
    }
}