using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowStatus : MonoBehaviour
{
    public GameObject a;
    public void SelectStatus(string name)
    {
        a.SetActive(true);
    }
}
