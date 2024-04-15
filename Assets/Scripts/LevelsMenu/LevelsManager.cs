using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class LevelsManager : MonoBehaviour
{
    private Level[] _levels;
    private int _currentPage;
    private LevelLoader _levelLoader;

    private void Awake()
    {
        _levels = GetComponentsInChildren<Level>();
        _currentPage = 1;
    }

    private void Start()
    {
        _levelLoader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
        _levelLoader.ChangeNextScene(_levels[_currentPage - 1]._levelSo.SceneName);
    }


    public void SetCurrentPage(int number)
    {
        _currentPage = number;
        _levelLoader.ChangeNextScene(_levels[_currentPage - 1]._levelSo.SceneName);
    }

    public int GetCurrentPage()
    {
        return _currentPage;
    }

    public int GetLevelsCount()
    {
        return _levels.Length;
    }
}
