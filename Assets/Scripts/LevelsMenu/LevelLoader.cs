using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private TransitionManager _transitionManager;
    [SerializeField] private float _transitionTime = 1f;
    
    private string _nextScene;
    
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(_nextScene));
    }

    IEnumerator LoadLevel(string name)
    {
        _transitionManager.StartTransAnimation();
        yield return new WaitForSeconds(_transitionTime);
        
        
        SceneManager.LoadScene(name);
    }


    public void ChangeNextScene(string name)
    {
        _nextScene = name;
    }

}
