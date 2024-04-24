using System;
using TMPro;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class LevelUI : MonoBehaviour
    {
        [SerializeField] private Image _killZoneMarker;
        [SerializeField] private Image _enemiesMarker;
        [SerializeField] private TextMeshProUGUI _recordText;

        private Level _levelData;

        private void Start()
        {
            _levelData = GetComponent<Level>();
            _enemiesMarker.gameObject.SetActive(_levelData._levelSo.HasEnemies);
            _killZoneMarker.gameObject.SetActive(_levelData._levelSo.HasTraps);
        }
    }
}