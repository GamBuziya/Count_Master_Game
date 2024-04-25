using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinishManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    void Start()
    {
        EventManager.Instance.OnFinish += EventManager_OnFinish;
    }

    private void EventManager_OnFinish()
    {
        _scoreText.text = "You score: " + PlayerManager.Instance.GetNumberOfStickmans();
    }
}
