using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Level : MonoBehaviour
    {
        public LevelSO _levelSo;

        private void Start()
        {
            if (_levelSo == null || _levelSo.SceneName == "")
            {
                Debug.Log("Problem with LevelSO:" + name);
            }
        }
    }
}