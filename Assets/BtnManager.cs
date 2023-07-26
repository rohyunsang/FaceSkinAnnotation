using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnManager : MonoBehaviour  // button Ŭ�� �ѹ��� ��ȣ 
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
            int buttonIndex = i; // �̰��� Ŭ���� ������ ���ϱ� ���� ���Դϴ�.
            btns[i].GetComponent<Button>().onClick.AddListener(() => ButtonClick(buttonIndex));
        }
    }

    void ButtonClick(int buttonIndex)
    {
        buttonValue = buttonIndex;
        Debug.Log(this.statusName + " : " + buttonIndex.ToString());

    }
    public void SetStatusName(string statusName)
    {
        this.statusName = statusName;
        Debug.Log(statusName);
    }
    
}
