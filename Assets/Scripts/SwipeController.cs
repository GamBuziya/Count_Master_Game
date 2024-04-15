using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeController : MonoBehaviour, IEndDragHandler
{
    [SerializeField] private int maxPage;
    [SerializeField] private Vector3 _pageStep;
    [SerializeField] private RectTransform _levelPagesRect;
    [SerializeField] private float _tweenTime;
    [SerializeField] private Ease _tweenType;

    private int _currentPage;
    private Vector3 _targetPos;
    private float dragThreshuld;

    private void Awake()
    {
        _currentPage = 1;
        _targetPos = _levelPagesRect.localPosition;
        dragThreshuld = Screen.width / 10;
    }

    public void Next()
    {
        if (_currentPage < maxPage)
        {
            _currentPage++;
            _targetPos += _pageStep;
            MovePage();
        }
    }

    public void Previous()
    {
        if (_currentPage > 1)
        {
            _currentPage--;
            _targetPos -= _pageStep;
            MovePage();
        }
    }

    void MovePage()
    {
        _levelPagesRect.DOLocalMove(_targetPos, _tweenTime).SetEase(_tweenType);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (MathF.Abs(eventData.position.x - eventData.pressPosition.x) > dragThreshuld)
        {
            if(eventData.position.x > eventData.pressPosition.x) Previous();
            else Next();
        }
        else
        {
            MovePage();
        }
    }
}
