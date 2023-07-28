using System.Collections.Generic;
using UnityEngine;

public class ShowButtons : MonoBehaviour
{
    public GameObject[] Btns;

    private Dictionary<string, int> regionMap = new Dictionary<string, int>()
{
    { "forehead wrinkle", 8 },
    { "forehead pigmentation", 6 },
    { "glabellus wrinkle", 8 },
    { "l_peroucular wrinkle", 6 },
    { "r_peroucular wrinkle", 6 },
    { "l_cheek pigmentation", 7 },
    { "l_cheek pores", 5 },
    { "r_cheek pigmentation", 7 },
    { "r_cheek pores", 5 },
    { "lip dryness lip", 4 },
    { "chin chin ptosis", 6 },
};

    public void OnNumPad(string region_name)
    {
        if (regionMap.TryGetValue(region_name, out int maxButtonNumber))
        {
            for (int i = 0; i < Btns.Length; i++)
            {
                // Enable button if it's within the range, otherwise disable
                Btns[i].SetActive(i <= maxButtonNumber);
            }
        }
        else
        {
            Debug.LogError("Region name not found in the map: " + region_name);
        }
    }

    public void OffNumPad()
    {
        foreach(GameObject btn in Btns)
        {
            btn.gameObject.SetActive(false);
        }
    }
}
