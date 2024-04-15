using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : BasicLevelLoader
{
    private string _nextScene;
    
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(_nextScene));
    }

    IEnumerator LoadLevel(string name)
    {
        _transition.SetTrigger("Start");

        yield return new WaitForSeconds(_transitionTime);
        
        
        SceneManager.LoadScene(name);
    }


    public void ChangeNextScene(string name)
    {
        _nextScene = name;
    }

}
