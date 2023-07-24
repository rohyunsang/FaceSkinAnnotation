using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonNamePassing : MonoBehaviour
{
    private GameObject StatusManagerObject; // in csharp can not define variable in function


    public void ButtonNamePass()
    {
        // find object name = StatusManager GetComponent ShowStatus
        // ���� false �ȰŴ� ��ã���ϱ� �� �ڽ� ������Ʈ���� ã�ƾ��Ѵ�. �̹��� �׷����ؾ��Ѵ�. ���� Status�� empty object �ȿ� ���� ���� ã��
        // setActive true; �� ������Ѵ�. 

        // ���� ������Ʈ�� ���� �̸� Ȯ�� �� �̸��� ����
        string objName = transform.name;
        StatusManagerObject = GameObject.Find("StatusManager");
        StatusManagerObject.GetComponent<ShowStatus>().SelectStatus(objName);
    }
}
