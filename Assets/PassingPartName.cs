using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassingPartName : MonoBehaviour  // ���� ���� �̸� json�� ���� �� status �ٿ�¿� 
{
    private GameObject JsonManagerObj; // in csharp can not define variable in function
    private GameObject ShowBtnsManagerObj;

    public void ButtonNamePass() //prefab���� ���� 
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
