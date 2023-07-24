using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class DataWrapper
{
    public List<Data> list;
}

[System.Serializable]
public class Data
{
    public string name;
    public PositionData position;
    public float width;
    public float height;
}

[System.Serializable]
public class PositionData
{
    public float x;
    public float y;
}

public class JsonParsing : MonoBehaviour
{
    public List<Data> dataItems = null;
    public GameObject ObjInstantGameObject; // using call ObjInstantManager Class Function
    public void ParseJSONData(string jsonData)
    {
        // Deserialize the JSON data into the DataWrapper object
        DataWrapper dataWrapper = JsonUtility.FromJson<DataWrapper>(jsonData);

        // Clear existing data list
        dataItems.Clear();

        // Add the parsed data items to the list
        dataItems.AddRange(dataWrapper.list);

        // Access individual data objects and their properties
        if (dataItems != null)
        {
            foreach (Data data in dataItems)
            {
                string logString = "Name: " + data.name +
                                   ", Position: (" + data.position.x + ", " + data.position.y + ")" +
                                   ", Width: " + data.width +
                                   ", Height: " + data.height;
                Debug.Log(logString);
                
            }
        }
        ObjInstantGameObject.GetComponent<ObjInstantManager>().ObjInstant(dataItems);

    }
}