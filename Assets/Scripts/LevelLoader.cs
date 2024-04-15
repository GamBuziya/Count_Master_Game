using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Animator _transition;

    [SerializeField] private float _transitionTime = 1f;
    

    private void Start()
    {
        if (_startButton != null)
        {
            _startButton.onClick.AddListener(LoadNextLevel);
        }
        
    }

    private void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        _transition.SetTrigger("Start");

        yield return new WaitForSeconds(_transitionTime);
        
        SceneManager.LoadScene(levelIndex);
    }
}
