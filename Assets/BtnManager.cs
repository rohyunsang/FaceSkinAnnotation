using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnManager : MonoBehaviour  // button 클릭 넘버랑 번호 
{
    public GameObject JsonManager;
    public GameObject[] btns;
    public int buttonValue;
    public string statusName = "";
    void Start()
    {
        JsonManager.GetComponent<Json>();
        for (int i = 0; i < btns.Length; i++)
        {
            int buttonIndex = i; // 이것은 클로저 문제를 피하기 위한 것입니다.
            btns[i].GetComponent<Button>().onClick.AddListener(() => ButtonClick(buttonIndex));
        }
    }

    public void SetStatusName(string statusName)
    {
        this.statusName = statusName;
        Debug.Log("SetStatusName called with: " + statusName);
    }

    void ButtonClick(int buttonIndex)
    {
        Debug.Log("In ButtonClick, statusName is: " + this.statusName);
        buttonValue = buttonIndex;
        Debug.Log(this.statusName + " : " + buttonIndex.ToString());
        JsonManager.GetComponent<Json>().FaceScore(this.statusName + " : " + buttonIndex.ToString());
    }

}
