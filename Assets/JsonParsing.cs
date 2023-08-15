using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class RectangleEntryFile
{
    public string name;
    public List<int> points;
}

[System.Serializable]
public class ImageDataFile
{
    public string imageName;
    public List<RectangleEntry> rectangleEntries;
}

[System.Serializable]
public class RootObject
{
    public List<ImageData> imageDataList;
}

[System.Serializable]
public class Info  //structure
{
    public string id;  // needs int to string 
    public string[] region_name;
    public List<int> point;
}

[System.Serializable]
public class GameObjectList
{
    public List<GameObject> gameObjects = new List<GameObject>();
}

public class JsonParsing : MonoBehaviour
{
    public GameObject PanelManagerObj;
    public GameObject ObjInstantGameObject; // using call ObjInstantManager Class Function
    public RawImage faceImage;

    public GameObject WorkEndImage;

    [SerializeField]
    public List<GameObjectList> jsonSquares = new List<GameObjectList>();
    public List<Texture2D> imageDatas = new List<Texture2D>();
    public List<string> squareCoordinate = new List<string>();
    public List<Info> parsedInfo = new List<Info>();



    public int idx = 0;

    public GameObject portraitPrefab;
    public Transform scrollView;
    public Transform scrollViewInitPanel;

    public GameObject failWindow;
    public Text SquareText;

    private bool isCoroutineRunning = false;

    public void MakeJsonArray(string jsonData)
    {
        ParseJSONData(jsonData);
    }
    public void MakeImageStringArray(byte[] bytes)
    {
        // Create a Texture2D from the image bytes
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(bytes);
        imageDatas.Add(texture);
    }
    public void CheckingFileCount()
    {
        if (jsonSquares.Count == imageDatas.Count && jsonSquares.Count != 0)
        {
            InitPortrait();
        }
        else
        {
            failWindow.SetActive(true);
            Invoke("FailWindowSetActiveFalse", 3f);
            ClearObjs();
        }
    }

    public void ClearObjs()
    {
        jsonSquares.Clear();
        imageDatas.Clear();
        parsedInfo.Clear();
        foreach (Transform child in faceImage.transform)
        {
            Destroy(child.gameObject);
        }
        isCoroutineRunning = false;
    }

    private void FailWindowSetActiveFalse()
    {
        failWindow.SetActive(false);
    }
    public void Portrait()
    {
        for (int i = 0; i < imageDatas.Count; i++)
        {
            GameObject portraitInstanceA = Instantiate(portraitPrefab, scrollView.transform);
            portraitInstanceA.name = parsedInfo[i].id;
            portraitInstanceA.GetComponent<Image>().sprite = Sprite.Create(imageDatas[i], new Rect(0, 0, imageDatas[i].width, imageDatas[i].height), Vector2.one * 0.5f);
        }
    }
    public void InitPortrait()
    {
        Debug.Log("InitPortrait");
        for (int i = 0; i < imageDatas.Count; i++)
        {
            GameObject portraitInstanceB = Instantiate(portraitPrefab, scrollViewInitPanel.transform);
            portraitInstanceB.name = i.ToString();
            portraitInstanceB.GetComponent<Image>().sprite = Sprite.Create(imageDatas[i], new Rect(0, 0, imageDatas[i].width, imageDatas[i].height), Vector2.one * 0.5f);
            Destroy(portraitInstanceB.GetComponent<Button>());
        }
    }


    public void RectanglesSetActiveFalse()
    {
        foreach (GameObjectList gameObjectList in jsonSquares)
        {
            for (int i = 0; i < gameObjectList.gameObjects.Count; i++)
            {
                gameObjectList.gameObjects.ForEach(square => square.SetActive(false));
            }
        }
    }
    public void QueueManager(int idx) // using btn;
    {
        jsonSquares[this.idx].gameObjects.ForEach(square => square.SetActive(false));
        // 1. ������ Ŭ���ϸ� idx�� �������� jsonSquare�� �̹����� �ٿ��. 
        this.idx = idx;
        jsonSquares[this.idx].gameObjects.ForEach(square => square.SetActive(true));
        faceImage.texture = imageDatas[this.idx];
        if (!isCoroutineRunning)
        {
            StartCoroutine(SetRaycastTargetTrueEveryTwoSecond());
        }
    }

    private IEnumerator SetRaycastTargetTrueEveryTwoSecond()
    {
        isCoroutineRunning = true;
        while (true)
        {
            foreach (GameObjectList list in jsonSquares)
            {
                foreach (GameObject obj in list.gameObjects)
                {
                    // Image ������Ʈ�� ���� ó��
                    Image img = obj.GetComponent<Image>();
                    if (img != null)
                    {
                        img.raycastTarget = true;
                    }

                    // RawImage ������Ʈ�� ���� ó��
                    RawImage rawImg = obj.GetComponent<RawImage>();
                    if (rawImg != null)
                    {
                        rawImg.raycastTarget = true;
                    }
                }
            }

            yield return new WaitForSeconds(2f);
        }
    }

    public void ParseJSONData(string jsonData)
    {
        var rootObject = JsonConvert.DeserializeObject<RootObject>(jsonData);

        // rootObject���� �����Ϳ� �׼���
        foreach (var imageData in rootObject.imageDataList)
        {
            Info imageInfo = new Info();
            imageInfo.id = imageData.imageName;
            imageInfo.region_name = new string[imageData.rectangleEntries.Count];
            imageInfo.point = new List<int>();

            int i = 0;  // region_name �迭 �ε����� ���� ����

            // �� rectangleEntry�� ó���ϰ� imageInfo ��ü�� ������ �߰�
            foreach (var rectangleEntry in imageData.rectangleEntries)
            {
                imageInfo.region_name[i] = rectangleEntry.name;
                imageInfo.point.AddRange(rectangleEntry.points);
                i++;
            }

            parsedInfo.Add(imageInfo); // ������ ������ ��Ͽ� �߰�

        }

        // ���� ����: ������ Ȯ��
        //Debug
        /*
         foreach (var info in parsedInfo)
        {
            Debug.Log($"ID: {info.id}");
            foreach (var name in info.region_name)
            {
                Debug.Log($"Region Name: {name}");
            }
            foreach (var point in info.point)
            {
                Debug.Log($"Point: {point}");
            }
        }
         */

        ObjInstantGameObject.GetComponent<ObjInstantManager>().ObjInstant(parsedInfo);
    }
}
