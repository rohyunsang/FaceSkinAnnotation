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
        // 주의 false 된거는 못찾으니까 그 자식 오브젝트에서 찾아야한다. 이미지 그룹을해야한다. 위에 Status는 empty object 안에 담은 다음 찾고
        // setActive true; 를 해줘야한다. 

        // 상위 오브젝트로 가서 이름 확인 후 이름을 저장
        string objName = transform.name;
        StatusManagerObject = GameObject.Find("StatusManager");
        StatusManagerObject.GetComponent<ShowStatus>().SelectStatus(objName);
    }
}
