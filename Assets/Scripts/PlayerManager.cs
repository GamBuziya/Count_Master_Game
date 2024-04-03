using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counter;
    [SerializeField] private GameObject _stickman;

    private int _numberOfStickmans;
    private Transform _player;

    private void Start()
    {
        _player = transform;
        UpdateUI();
    }

    private void MakeStickman(int number)
    {
        for (int i = 0; i < number; i++)
        {
            Instantiate(_stickman, transform.position, quaternion.identity, transform);
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        _numberOfStickmans = transform.childCount - 1;

        _counter.text = _numberOfStickmans.ToString();
    }

    private void UpdateNumber(bool multiply, int number)
    {
        if (multiply)
        {
            MakeStickman(_numberOfStickmans *= number);
        }
        else
        {
            MakeStickman(_numberOfStickmans += number);
        }

        UpdateUI();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gate"))
        {
            UpdateNumber(other.GetComponent<GateManager>().Multiply, other.GetComponent<GateManager>().Number);
        }   
    }
}
