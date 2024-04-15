using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class BasicLevelLoader : MonoBehaviour
    {
        [SerializeField] protected Animator _transition;
        [SerializeField] protected float _transitionTime = 1f;
        
        
        public void LoadNextLevel()
        {
            var index = SceneManager.GetActiveScene().buildIndex + 1;
            StartCoroutine(LoadLevel(index));
        }

        IEnumerator LoadLevel(int index)
        {
            _transition.SetTrigger("Start");
            yield return new WaitForSeconds(_transitionTime);
             
            SceneManager.LoadScene(index);
        }
    }
}