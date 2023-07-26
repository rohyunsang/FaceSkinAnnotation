using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

[System.Serializable]
public class FaceData
{
    public string name;
    public Vector2 position;
    public float width;
    public float height;
    public string description;
}


public class Json : MonoBehaviour  // Json, Show Status 
{
    public List<GameObject> faceStatuses = new List<GameObject>(); // List of GameObjects

    public GameObject foreheadStatus;
    public GameObject glabellusStatus;
    public GameObject l_peroucularStatus;
    public GameObject r_peroucularStatus;
    public GameObject l_cheekStatus;
    public GameObject r_cheekStatus;
    public GameObject lipStatus;
    public GameObject chinStatus;

    public List<Data> dataItems;

    public void CopyJsonData(List<Data> dataItems)
    {
        this.dataItems = dataItems;
    }

    public void FacePartictionName(string region_name)
    {
        // Reset all GameObjects to inactive
        foreach (GameObject faceStatus in faceStatuses)
        {
            faceStatus.SetActive(false);
        }

        // Find the corresponding GameObject and set it to active
        switch (region_name)
        {
            case "forehead":
                faceStatuses[0].SetActive(true);
                break;
            case "glabellus":
                faceStatuses[1].SetActive(true);
                break;
            case "l_peroucular":
                faceStatuses[2].SetActive(true);
                break;
            case "r_peroucular":
                faceStatuses[3].SetActive(true);
                break;
            case "l_cheek":
                faceStatuses[4].SetActive(true);
                break;
            case "r_cheek":
                faceStatuses[5].SetActive(true);
                break;
            case "lip":
                faceStatuses[6].SetActive(true);
                break;
            case "chin":
                faceStatuses[7].SetActive(true);
                break;
            default:
                break;
        }
    }

    public void FaceScore(string name)
    {
        string region_name = "";
        string region_condition = "";

        // Split the name string on space
        string[] splitName = name.Split(' ');

        // Assuming the first part is the region name
        region_name = splitName[0];

        // Assuming the second part is the region condition
        if (splitName.Length > 1)  // Make sure there is a second part
            region_condition = splitName[1];

        switch (region_name)
        {
            case "forehead":
                dataItems[0].description = region_condition;
                break;
            case "glabellus":
                
                break;
            case "l_peroucular":
                
                break;
            case "r_peroucular":
                
                break;
            case "l_cheek":
                
                break;
            case "r_cheek":
                
                break;
            case "lip":
                
                break;
            case "chin":
                
                break;
            default:
                break;
        }
    }

    public void JsonOut()  // save in desktop 
    {
        DataWrapper wrapper = new DataWrapper();
        wrapper.list = dataItems;

        // Serialize it to a JSON string
        string json = JsonUtility.ToJson(wrapper, true);

        // Write the JSON string to a file in desktop
        string desktopPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
        File.WriteAllText(desktopPath + "/faceField.json", json);

        Debug.Log("Complete");
    }

    private void Start()
    {
        // Add GameObjects to the list
        faceStatuses.Add(foreheadStatus);
        faceStatuses.Add(glabellusStatus);
        faceStatuses.Add(l_peroucularStatus);
        faceStatuses.Add(r_peroucularStatus);
        faceStatuses.Add(l_cheekStatus);
        faceStatuses.Add(r_cheekStatus);
        faceStatuses.Add(lipStatus);
        faceStatuses.Add(chinStatus);
    }
}