using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Vuforia;

public class QRScript : MonoBehaviour
{
    GameObject ScanningUI;
    void Start()
    {
        
    }
    public void AreaTracked()
    {
        ScanningUI.transform.localScale= Vector3.zero;
    }
    public void AreaLost()
    {
        ScanningUI.transform.localScale = Vector3.one;
    }
}