using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;

public class Json : MonoBehaviour
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