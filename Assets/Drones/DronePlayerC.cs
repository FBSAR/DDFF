using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    public Animator DronePlayerC;
    public float delay = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartAnimation", delay);
        
    }

    void StartAnimation()
    {
        DronePlayerC.SetTrigger("NextDrone");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
