using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ObjInstantManager : MonoBehaviour
{
    public GameObject rectanglePrefab;
    public RawImage SpawnPoint;

    public void ObjInstant(List<Data> dataItems)
    {

        foreach (Data dataItem in dataItems)
        {
            // Instantiate a rectangle object from the prefab
            GameObject rectangle = Instantiate(rectanglePrefab, SpawnPoint.transform);

            // Set the parent of the rectangle object
            rectangle.transform.SetParent(SpawnPoint.transform, false);

            // Set the size of the rectangle object with scaling
            RectTransform rectTransform = rectangle.GetComponent<RectTransform>();

           
            rectTransform.sizeDelta = new Vector2(dataItem.width, dataItem.height);
            rectTransform.anchoredPosition = new Vector2(dataItem.position.x,dataItem.position.y); // here is your offset

            // Set the name of the rectangle object
            rectangle.gameObject.name = dataItem.name;
            rectangle.layer = LayerMask.NameToLayer("UI");

            Text regionNameText = rectangle.GetComponentInChildren<Text>();
            if (regionNameText != null)
            {
                regionNameText.text = dataItem.name;
                regionNameText.color = Color.gray;
            }
        }
    }
}

