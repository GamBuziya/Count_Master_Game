using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    
    [SerializeField] private TextMeshProUGUI _counter;
    [SerializeField] private GameObject _stickman;
    [Range(0f, 1f)] [SerializeField] private float _distanceFactor, _radius;

    private int _numberOfStickmans;
    private Transform _player;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _player = transform;
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
    
    private void MakeStickman(int number)
    {
        for (int i = 0; i < number; i++)
        {
            Instantiate(_stickman, transform.position, quaternion.identity, transform);
        }

        FormatStickMan();
        UpdateUI();
    }

    private void FormatStickMan()
    {
        for (int i = 0; i < transform.childCount - 1; i++)
        {
            if(_player.GetChild(i).CompareTag("Canvas")) continue;
            
            var x = _distanceFactor * Mathf.Sqrt(i) * Mathf.Cos(i * _radius);
            var z = _distanceFactor * Mathf.Sqrt(i) * Mathf.Sin(i * _radius);

            var newPosition = new Vector3(x, 0, z);

            _player.GetChild(i).DOLocalMove(newPosition, 1f).SetEase(Ease.OutBack);
        }
    }

    public int GetNumberOfStickmans()
    {
        return _numberOfStickmans;
    }
}
