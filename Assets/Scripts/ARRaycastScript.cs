using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARRaycastScript : MonoBehaviour
{
    /// <summary>
    /// The Prefab will be instatiated on touch
    /// </summary>
    [SerializeField]
    [Tooltip("Instantiates this prefab on a plane at the touch location")]
    GameObject placedPrefab;

    /// <summary>
    /// The Prefab will be instatiated on touch
    /// </summary>
    [SerializeField]
    [Tooltip("Drone Show Fab that is placed after the user presses the confirm button")]
    GameObject dronePrefab;

    /// <summary>
    /// The Instantiated object
    /// </summary>
    GameObject spawnedObject;

    ARRaycastManager raycastManager;
    ARPlaneManager planeManager;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();
    GameObject showPlacement;
    GameObject playShow;
    bool confirmedPlacement = false;

    void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        planeManager = GetComponent<ARPlaneManager>();
    }

    private void Start()
    {
        showPlacement = GameObject.Find("ConfirmPlacement");
        playShow = GameObject.Find("PlayShow");
    }

    void Update()
    {
        // Check if any existing touch
        if (Input.touchCount == 0) return;

        // Check is the raycast hit any trackables
        if (raycastManager.Raycast(
            Input.GetTouch(0).position,
            hits,
            TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;

            // Reveal Show Placement UI
            showPlacement.transform.localScale = new Vector3(1, 1, 1);

            if (spawnedObject == null)
            {
                spawnedObject = Instantiate(placedPrefab, hitPose.position, hitPose.rotation);
            }
            else
            {
                // Change the spanwed object position and rotation to the touch posiiton.
                spawnedObject.transform.position = hitPose.position;
                spawnedObject.transform.rotation = hitPose.rotation;
            }

            // To make the spawned object position always look at the camera.
            Vector3 lookPos = Camera.main.transform.position - spawnedObject.transform.position;
            lookPos.y = 0;
            spawnedObject.transform.rotation = Quaternion.LookRotation(lookPos);

            if (confirmedPlacement == true)
            {
                return;
            }
        }


        // Hide Plane Visualization
        // planeManager.SetTrackablesActive(false);


        //if (confirmedPlacement)
   

        // Check for if player confirmed placement
        // Hide ShowPlacement GameObject
        // Show PlayShow Object
        // showPlacement.transform.localScale = new Vector3(1, 1, 1);
    }
    
    public void ConfirmPlacement()
    {
        /// Needs to capture the last touch position
        /// Visualize placeholder/ space being taken up before placement - Needs to be the same size as Drown show altogether
        /// Press a 'play' button to start the drown show
        /// Restart button to restart the drone show
        confirmedPlacement = true;
        var hitPose = hits[0].pose;
        spawnedObject = Instantiate(dronePrefab, hitPose.position, hitPose.rotation);
    }

    public void StartShow()
    {
        playShow.transform.localScale = new Vector3(0, 0, 0);
    }
}
