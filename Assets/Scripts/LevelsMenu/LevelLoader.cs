using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Animator _transition;
    [SerializeField] private float _transitionTime = 1f;
    [SerializeField] private string _nextScene;
    
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(_nextScene));
    }

    IEnumerator LoadLevel(string name)
    {
        _transition.SetTrigger("Start");

        yield return new WaitForSeconds(_transitionTime);
        
        Scene scene = SceneManager.GetSceneByName(name);
        if (scene.IsValid())
        {
            SceneManager.LoadScene(name);
        }
        else
        {
            Debug.LogError("Scene with name " + name + " does not exist.");
        }
    }


    public void ChangeNextScene(string name)
    {
        _nextScene = name;
    }

}
