using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CropFaceImage : MonoBehaviour
{
    public GameObject jsonParsingManagerObj;
    public List<Info> parsedInfo = new List<Info>();
    public List<Texture2D> imageDatas = new List<Texture2D>();

    public GameObject foreheadSpawn;
    public GameObject glabellusSpawn;
    public GameObject lPeriocularSpawn;
    public GameObject rPeriocularSpawn;
    public GameObject lCheekSpawn;
    public GameObject rCheekSpawn;
    public GameObject lipSpawn;
    public GameObject chinSpawn;

    public GameObject mainPanel;

    public void CaptureChildren()
    {
        int idx = 0;
        foreach (Info info in parsedInfo)  // total 7
        {
            if (info.id.Contains("phone") || info.id.Contains("pad"))
            {
                continue;  // Skip the current iteration and move to the next one
            }
            CaptureArea(imageDatas[idx], info);
            idx++;
        }
    }

    private void CaptureArea(Texture2D sourceTexture, Info info)
    {
        int numRectangles = info.region_name.Length;  // Calculate the number of rectangles
        for (int i = 0; i < numRectangles; i++)
        {
            Debug.Log(numRectangles);

            int x1 = info.point[i * 4 + 0];
            int y1 = 3216 - info.point[i * 4 + 1];
            int x2 = info.point[i * 4 + 2];
            int y2 = 3216 - info.point[i * 4 + 3];
            Debug.Log(info.region_name[i]);

            // Calculate width and height based on the points
            int width = x2 - x1;
            int height = y1 - y2;  // Notice this is reversed compared to before

            // sourceTexture에서 해당 영역을 잘라냄
            Texture2D croppedTexture = CropTexture2D(sourceTexture, x1, y2, width, height);

            // 잘라낸 Texture2D로 새로운 GameObject 생성
            GameObject croppedImageObj = new GameObject("" + info.id + " " + info.region_name[i]);
            RawImage rawImage = croppedImageObj.AddComponent<RawImage>();
            rawImage.texture = croppedTexture;

            // 잘라낸 이미지의 RectTransform 설정
            RectTransform croppedRect = croppedImageObj.GetComponent<RectTransform>();
            croppedRect.sizeDelta = new Vector2(width, height);  // You might need to adjust this if you have a scaling factor
            croppedRect.anchoredPosition = new Vector2(x1, y1);  // You might need to adjust this if you have a scaling factor

            // croppedImageObj에 Text component를 가진 자식 GameObject 추가
            GameObject textObj = new GameObject("NameText");
            Text nameText = textObj.AddComponent<Text>();
            nameText.text = info.id + " " + info.region_name[i];  // why reverse sorted?
            nameText.transform.SetParent(croppedImageObj.transform, false);
            nameText.color = Color.black;
            nameText.fontSize = 40;  // Set font size to 40
            nameText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");  // Set font to Arial
            nameText.alignment = TextAnchor.UpperCenter;  // Set alignment to middle top
            nameText.horizontalOverflow = HorizontalWrapMode.Overflow;  // Set horizontal overflow
            nameText.verticalOverflow = VerticalWrapMode.Overflow;  // Set vertical overflow
            nameText.transform.SetParent(croppedImageObj.transform, false);
            nameText.rectTransform.anchorMin = new Vector2(0.5f, 1);  // Set anchor min to middle top
            nameText.rectTransform.anchorMax = new Vector2(0.5f, 1);  // Set anchor max to middle top
            nameText.rectTransform.pivot = new Vector2(0.5f, 1);  // Set pivot to middle top

            Vector3 textPosition = nameText.rectTransform.localPosition;
            nameText.rectTransform.localPosition = new Vector3(textPosition.x, textPosition.y + 50f, textPosition.z);


            RectTransform rect = croppedImageObj.GetComponent<RectTransform>();
            switch (info.region_name[i])
            {
                case "forehead":
                    rect.sizeDelta = new Vector2(rect.sizeDelta.x * 0.5f, rect.sizeDelta.y * 0.5f);
                    croppedImageObj.transform.SetParent(foreheadSpawn.transform, false);
                    break;
                case "glabellus":
                    croppedImageObj.transform.SetParent(glabellusSpawn.transform, false);
                    break;
                case "l_peroucular":
                    croppedImageObj.transform.SetParent(lPeriocularSpawn.transform, false);
                    break;
                case "r_peroucular":
                    croppedImageObj.transform.SetParent(rPeriocularSpawn.transform, false);
                    break;
                case "l_cheek":
                    croppedImageObj.transform.SetParent(lCheekSpawn.transform, false);
                    break;
                case "r_cheek":
                    croppedImageObj.transform.SetParent(rCheekSpawn.transform, false);
                    break;
                case "lip":
                    croppedImageObj.transform.SetParent(lipSpawn.transform, false);
                    break;
                case "chin":
                    rect.sizeDelta = new Vector2(rect.sizeDelta.x * 0.5f, rect.sizeDelta.y * 0.5f);
                    croppedImageObj.transform.SetParent(chinSpawn.transform, false);
                    break;
                default:
                    // Optional: Handle any unexpected region names
                    Debug.LogWarning($"Unexpected region name: {info.region_name[i]}");
                    break;
            }
        }

    }

    public void ClearCropImage()
    {
        DestroyChildrenOf(foreheadSpawn);
        DestroyChildrenOf(glabellusSpawn);
        DestroyChildrenOf(lPeriocularSpawn);
        DestroyChildrenOf(rPeriocularSpawn);
        DestroyChildrenOf(lCheekSpawn);
        DestroyChildrenOf(rCheekSpawn);
        DestroyChildrenOf(lipSpawn);
        DestroyChildrenOf(chinSpawn);
    }

    private void DestroyChildrenOf(GameObject parent)
    {
        foreach (Transform child in parent.transform)
        {
            Destroy(child.gameObject);
        }
    }
    public void DestroyStatusButton()  // mainPanel의 자식 오브젝트중 tag가 StatusButton인 것들을 다삭제. 
    {
        foreach (Transform child in mainPanel.transform)
        {
            if (child.CompareTag("StatusButton"))
            {
                Destroy(child.gameObject);
            }
        }
    }


    private Texture2D CropTexture2D(Texture2D sourceTexture, int x, int y, int width, int height)
    {
        Color[] pixels = sourceTexture.GetPixels(x, y, width, height);
        Texture2D result = new Texture2D(width, height);
        result.SetPixels(pixels);
        result.Apply();
        return result;
    }
}
