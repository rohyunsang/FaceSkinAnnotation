using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShowButtons : MonoBehaviour
{
    public GameObject[] Btns;

    
    // 숫자를 클릭하면 numpad가 뜨고, 부모 오브젝트의 이름을 전달해야한다. 
    // 하나로 통합할수없나? 
    

    public void OnNumPad()
    {
        foreach(GameObject Btn in Btns)
        {
            gameObject.SetActive(true);
        }
    }
}
