using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Vuforia;

public class QRScript : MonoBehaviour
{
    ImageTargetBehaviour QRTracked;
    PlaneFinderBehaviour mPlaneFinder;
    void Start()
    {
        
    }
    public void QR02Tracked()
    {
        
    }
    public void QR02Lost()
    {
        Debug.Log("QR02 Lost");
    }
}