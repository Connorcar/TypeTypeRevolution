using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeController : MonoBehaviour, IEndDragHandler
{
    [SerializeField] private int maxPage;

    public int currPage = 1;
    private Vector3 targetPos;
    private float dragThreshold;

    [SerializeField] private Vector3 pageStep;

    [SerializeField] private RectTransform pagesRect;
    [SerializeField] private float tweenTime;
    [SerializeField] private LeanTweenType tweenType;

    private void Awake()
    {
        targetPos = pagesRect.localPosition;
        dragThreshold = Screen.width / 15;
    }

    public void Next()
    {
        if (currPage < maxPage)
        {
            currPage++;
            targetPos += pageStep;
            MovePage();
        }
    }

    public void Prev()
    {
        if (currPage > 1)
        {
            currPage--;
            targetPos -= pageStep;
            MovePage();
        }
    }

    public void MovePage()
    {
        pagesRect.LeanMoveLocal(targetPos, tweenTime).setEase(tweenType);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (Mathf.Abs(eventData.position.x - eventData.pressPosition.x) > dragThreshold)
        {
            if (eventData.position.x > eventData.pressPosition.x)
            {
                Prev();
            }
            else
            {
                Next();
            }
        }
        else
        {
            MovePage();
        }
    }
}
