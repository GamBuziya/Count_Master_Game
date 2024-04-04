using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GateManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _gateNO;

    public int Number;
    public bool Multiply;
    void Start()
    {
        if (Multiply)
        {
            Number = Random.Range(1, 3);
            _gateNO.text = "X" + Number.ToString();
        }
        else
        {
            Number = Random.Range(10, 50);

            if (Number % 2 != 0) Number++;
            
            _gateNO.text = "+" + Number.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}