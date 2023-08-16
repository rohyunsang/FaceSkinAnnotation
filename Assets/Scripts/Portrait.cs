using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Portrait : MonoBehaviour
{
    public GameObject JsonParsingManagerObj;
    public GameObject checkingImage;

    public void PortraitClick()
    {
        JsonParsingManagerObj = GameObject.Find("JsonParsingManager");

        string currentId = transform.name; // ���⼭ transform.name�� �ش� ��Ʈ����Ʈ�� id ���� ��ġ�Ѵٰ� �����մϴ�.

        int idx = GetIndexById(currentId);

        if (idx != -1)  // ��ȿ�� �ε����� ���
        {
            Debug.Log(idx);
            JsonParsingManagerObj.GetComponent<JsonParsing>().QueueManager(idx);
        }
    }

    private int GetIndexById(string id)
    {
        List<Info> parsedInfo = JsonParsingManagerObj.GetComponent<JsonParsing>().parsedInfo;

        for (int i = 0; i < parsedInfo.Count; i++)
        {
            if (parsedInfo[i].id == id)
            {
                return i;  // �ε����� ��ȯ
            }
        }

        return -1;  // id�� ã�� ���� ���
    }
}