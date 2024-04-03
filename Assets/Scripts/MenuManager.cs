using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("Active UI")]
    [SerializeField] private TextMeshProUGUI _tapToPlayText;
    [SerializeField] private Ease _motionType;
    [SerializeField] private Image _hand;
    void Start()
    {
        _tapToPlayText.transform.DOScale(1.2f, 0.5f).SetLoops(1000, LoopType.Yoyo).SetEase(_motionType);
        _hand.transform.DOMoveX(260, 1f).SetLoops(1000, LoopType.Yoyo).SetEase(_motionType);
    }
}
