using UnityEngine;
using System.Collections.Generic;
using JetBrains.Annotations;

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
    public Status status;  
}
[System.Serializable]
public class Status
{
    public string statusA;
    public string statusB;
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
    public GameObject JsonGameObject;
    public void ParseJSONData(string jsonData)
    {
        try
        {
            // Deserialize the JSON data into the DataWrapper object
            DataWrapper dataWrapper = JsonUtility.FromJson<DataWrapper>(jsonData);

            // Check if list in dataWrapper is not null
            if (dataWrapper?.list != null)
            {
                // Clear existing data list
                dataItems.Clear();

                // Add the parsed data items to the list
                dataItems.AddRange(dataWrapper.list);

                // Access individual data objects and their properties
                foreach (Data data in dataItems)
                {
                    // Assign a value to the new field
                    data.status.statusA = "";
                    data.status.statusB = "";

                    string logString = "Name: " + data.name +
                                       ", Position: (" + data.position.x + ", " + data.position.y + ")" +
                                       ", Width: " + data.width +
                                       ", Height: " + data.height +
                                       ", Description: " + data.status.statusA + data.status.statusB;  // Include the new field in the log
                    Debug.Log(logString);

                }
                ObjInstantGameObject.GetComponent<ObjInstantManager>().ObjInstant(dataItems);
                JsonGameObject.GetComponent<Json>().CopyJsonData(dataItems);
            }
            else
            {
                Debug.LogError("JSON Parsing failed. DataWrapper or its list is null.");
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("JSON Parsing Error: " + e.Message);
        }
    }
}