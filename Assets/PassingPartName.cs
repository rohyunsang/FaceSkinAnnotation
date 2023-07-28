using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassingPartName : MonoBehaviour  // 현재 영역 이름 json에 전달 후 status 뛰우는용 
{
    private GameObject JsonManagerObj; // in csharp can not define variable in function
    private GameObject ShowBtnsManagerObj;

    public void ButtonNamePass() //prefab에서 참조 
    {
        string objName = transform.name;
        JsonManagerObj = GameObject.Find("JsonManager");
        JsonManagerObj.GetComponent<Json>().FacePartictionName(objName);

    }

    public void OffBtns()
    {
        ShowBtnsManagerObj = GameObject.Find("ShowBtnManager");
        ShowBtnsManagerObj.GetComponent<ShowButtons>().OffNumPad();
    }
}
