using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GateManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _gateNO;

    public int Number;
    void Start()
    {
        Number = Random.Range(10, 60);
            _gateNO.text = "+" + Number.ToString();
    }
    
}
