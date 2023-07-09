using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public GameObject InitPanel;

    public void OffInitPanel()
    {
        InitPanel.SetActive(false);
    }
    public void OnInitPanel()
    {
        InitPanel.SetActive(true);
    }
}
