using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnManager : MonoBehaviour  // button Ŭ�� �ѹ��� ��ȣ 
{
    public GameObject[] btns;
    public int buttonValue;
    public string statusName = "";
    public string facePartictionStatusName = "";

    void Start()
    {
        for (int i = 0; i < btns.Length; i++)
        {
            int buttonIndex = i; // �̰��� Ŭ���� ������ ���ϱ� ���� ���Դϴ�.
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
