using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnManager : MonoBehaviour  // button 클릭 넘버랑 번호 
{
    public GameObject[] btns;
    public int buttonValue;
    public string statusName = "";
    public string facePartictionStatusName = "";

    void Start()
    {
        for (int i = 0; i < btns.Length; i++)
        {
            int buttonIndex = i; // 이것은 클로저 문제를 피하기 위한 것입니다.
            btns[i].GetComponent<Button>().onClick.AddListener(() => ButtonClick(buttonIndex));
        }
    }

    void ButtonClick(int buttonIndex)
    {
        buttonValue = buttonIndex;
        Debug.Log("Button " + buttonIndex + " clicked. Button value is now: " + buttonValue);
    }
    public void SetStatusName(string facePartictionStatusName)
    {
        this.facePartictionStatusName = facePartictionStatusName;
        Debug.Log(facePartictionStatusName);
    }
    public void SetFacePartictionStatusName(string statusName)
    {
        this.statusName = statusName;
        Debug.Log(statusName);
    }
}
