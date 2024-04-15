using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwipeController : MonoBehaviour, IEndDragHandler
{ 
    [SerializeField] private Vector3 _pageStep;
    [SerializeField] private RectTransform _levelPagesRect;
    [SerializeField] private float _tweenTime;
    [SerializeField] private Ease _tweenType;

    [Header("Buttons")] 
    [SerializeField] private Button _nextButton;
    [SerializeField] private Button _previousButton;
    
    private Vector3 _targetPos;
    private float dragThreshuld;
    private LevelsManager _levelsManager;
    private int _maxPage;

    private void Start()
    {
        _levelsManager = GetComponentInChildren<LevelsManager>();
        _targetPos = _levelPagesRect.localPosition;
        dragThreshuld = Screen.width / 10;
        UpdateArrowButton();
        _maxPage = _levelsManager.GetLevelsCount();
    }
    

    public void Next()
    {
        if (_levelsManager.GetCurrentPage() < _maxPage)
        {
            var currentPage = _levelsManager.GetCurrentPage() + 1;
            _levelsManager.SetCurrentPage(currentPage);
            _targetPos += _pageStep;
            MovePage();
        }
    }

    public void Previous()
    {
        if (_levelsManager.GetCurrentPage() > 1)
        {
            var currentPage = _levelsManager.GetCurrentPage() - 1;
            _levelsManager.SetCurrentPage(currentPage);
            _targetPos -= _pageStep;
            MovePage();
        }
    }

    void MovePage()
    {
        _levelPagesRect.DOLocalMove(_targetPos, _tweenTime).SetEase(_tweenType);
        UpdateArrowButton();
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

    private void UpdateArrowButton()
    {
        _nextButton.interactable = true;
        _previousButton.interactable = true;
        
        
        if (_levelsManager.GetCurrentPage() == 1) _previousButton.interactable = false;
        else if(_levelsManager.GetCurrentPage() == _maxPage) _nextButton.interactable = false;
        
    }
}
