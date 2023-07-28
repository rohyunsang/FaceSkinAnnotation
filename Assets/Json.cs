using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.CompilerServices;

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
        Debug.Log("FaceScore" + name);
        string region_name = "";
        string region_condition = "";
        

        // Split the name string on space
        string[] splitName = name.Split(' ');

        // Assuming the first part is the region name
        region_name = splitName[0];

        // Assuming the second part is the region condition
        
        foreach(string s in splitName)
        {
            if(!s.Equals(region_name))
                region_condition += s;
        }

        Debug.Log(region_name);
        Debug.Log(region_condition);

        switch (region_name)
        {
            case "forehead":
                int index1 = region_condition.IndexOf(':');
                string condition1 = region_condition.Substring(0, index1);
                if (condition1.Equals("wrinkle"))
                    dataItems[0].status.statusA = region_condition; // wrinkle - 주름
                else
                    dataItems[0].status.statusB = region_condition; // pigmentation - 색소 침착
                break;
            case "glabellus":
                dataItems[1].status.statusA = region_condition; // wrinkle  
                break;
            case "l_peroucular":
                dataItems[2].status.statusA = region_condition; // wrinkle  
                break;
            case "r_peroucular":
                dataItems[3].status.statusA = region_condition; // wrinkle  
                break;
            case "l_cheek":
                int index2 = region_condition.IndexOf(':');
                string condition2 = region_condition.Substring(0, index2);
                if (condition2.Equals("pigmentation"))
                    dataItems[4].status.statusA = region_condition; // pigmentation
                else
                    dataItems[4].status.statusB = region_condition; // pores - 모공
                break;
            case "r_cheek":
                int index3 = region_condition.IndexOf(':');
                string condition3 = region_condition.Substring(0, index3);
                if (condition3.Equals("pigmentation"))
                    dataItems[5].status.statusA = region_condition; // pigmentation
                else
                    dataItems[5].status.statusB = region_condition; // pores - 모공
                break;
            case "lip":
                dataItems[6].status.statusA = region_condition; // dryness - 입술 건조도 
                break;
            case "chin":
                dataItems[7].status.statusA = region_condition; // chin ptosis - 턱선 처짐
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