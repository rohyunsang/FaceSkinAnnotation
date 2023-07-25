using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassingPartName : MonoBehaviour
{
    private GameObject JsonManagerObj; // in csharp can not define variable in function


    public void ButtonNamePass()
    {
        string objName = transform.name;
        JsonManagerObj = GameObject.Find("JsonManager");
        JsonManagerObj.GetComponent<Json>().FacePartictionName(objName);

    }
}
