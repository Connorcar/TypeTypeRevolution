using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwipeController : MonoBehaviour, IEndDragHandler
{

    [SerializeField] private int maxPage;

    private int currPage;
    private Vector3 targetPos;
    private float dragThreshold;
    public bool isControllingSkins;
    [SerializeField]  public AchievementManager am;
    public GameObject skinLock;
    public Options options;


    [SerializeField] private Vector3 pageStep;

    [SerializeField] private RectTransform pagesRect;
    [SerializeField] private float tweenTime;
    [SerializeField] private LeanTweenType tweenType;

    private void Awake()
    {
        currPage = 1;
        targetPos = pagesRect.localPosition;
        dragThreshold = Screen.width / 15;
        if(isControllingSkins){
            if(am.getNumSkinsUnlocked() < 1){
                skinLock.SetActive(true);
            }else{
                skinLock.SetActive(false);
            }
        }
    }

    public void Next()
    {
        if (currPage < maxPage)
        {
            //cannot go past certain skin if it has not been unlocked yet
            if(isControllingSkins){
                if(currPage >= am.getNumSkinsUnlocked()){
                    skinLock.SetActive(true);
                }else{
                    skinLock.SetActive(false);
                }
            }
            
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
            if(isControllingSkins){
                skinLock.SetActive(false);
            }
            
        }
    }

    void MovePage()
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

    public void ResetPage()
    {
        targetPos -= pageStep * (currPage-1);
        MovePage();
        currPage = 1;
        if(isControllingSkins){
            if(am.getNumSkinsUnlocked() < 1){
                skinLock.SetActive(true);
            }else{
                skinLock.SetActive(false);
            }
            options.leftSkinArrow.enabled = false;
        }
    }
}
