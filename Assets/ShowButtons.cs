using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShowButtons : MonoBehaviour
{
    public GameObject[] Btns;

    
    // ���ڸ� Ŭ���ϸ� numpad�� �߰�, �θ� ������Ʈ�� �̸��� �����ؾ��Ѵ�. 
    // �ϳ��� �����Ҽ�����? 
    

    public void OnNumPad()
    {
        foreach(GameObject Btn in Btns)
        {
            gameObject.SetActive(true);
        }
    }
}
