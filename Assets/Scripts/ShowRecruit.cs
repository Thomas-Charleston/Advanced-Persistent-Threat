using System;
using System.Collections;
using UnityEngine;

public class ShowRecruit : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup analystGroup;
    [SerializeField]
    private CanvasGroup engineerGroup;
    [SerializeField]
    private CanvasGroup adminGroup;
    [SerializeField]
    private CanvasGroup teacherGroup;
    [SerializeField]
    private CanvasGroup redTeamerGroup;
    [SerializeField]
    private CanvasGroup responderGroup;

    void Start()
    {
        StartCoroutine(ClosePreviousGroup());
        analystGroup.alpha = 1;
        analystGroup.interactable = true;
        analystGroup.blocksRaycasts = true;
    }
    
    IEnumerator ClosePreviousGroup()
    {
        analystGroup.alpha = 0;
        analystGroup.interactable = false;
        analystGroup.blocksRaycasts = false;
        engineerGroup.alpha = 0;
        engineerGroup.interactable = false;
        engineerGroup.blocksRaycasts = false;
        adminGroup.alpha = 0;
        adminGroup.interactable = false;
        adminGroup.blocksRaycasts = false;
        teacherGroup.alpha = 0;
        teacherGroup.interactable = false;
        teacherGroup.blocksRaycasts = false;
        redTeamerGroup.alpha = 0;
        redTeamerGroup.interactable = false;
        redTeamerGroup.blocksRaycasts = false;
        responderGroup.alpha = 0;
        responderGroup.interactable = false;
        responderGroup.blocksRaycasts = false;
        yield return true;
    }

    public void OpenAnalyst()
    {
        StartCoroutine(ClosePreviousGroup());
        analystGroup.alpha = 1;
        analystGroup.interactable = true;
        analystGroup.blocksRaycasts = true;
    }

    public void OpenEngineer()
    {
        StartCoroutine(ClosePreviousGroup());
        engineerGroup.alpha = 1;
        engineerGroup.interactable = true;
        engineerGroup.blocksRaycasts = true;
    }

    public void OpenAdmin()
    {
        StartCoroutine(ClosePreviousGroup());
        adminGroup.alpha = 1;
        adminGroup.interactable = true;
        adminGroup.blocksRaycasts = true;
    }

    public void OpenTeacher()
    {
        StartCoroutine(ClosePreviousGroup());
        teacherGroup.alpha = 1;
        teacherGroup.interactable = true;
        teacherGroup.blocksRaycasts = true;
    }

    public void OpenRedTeamer()
    {
        StartCoroutine(ClosePreviousGroup());
        redTeamerGroup.alpha = 1;
        redTeamerGroup.interactable = true;
        redTeamerGroup.blocksRaycasts = true;
    }

    public void OpenResponder()
    {
        StartCoroutine(ClosePreviousGroup());
        responderGroup.alpha = 1;
        responderGroup.interactable = true;
        responderGroup.blocksRaycasts = true;
    }
}
