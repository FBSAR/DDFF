using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using Vuforia;

public class HUDScript : MonoBehaviour
{
    GameObject hamMenuOpen;
    GameObject sideNav;
    GameObject scanningUI;
    GameObject HUD;
    GameObject infoUI;
    GameObject tookPicUI;
    Timer timer;
    AreaTargetBehaviour areaTargetBeh;
    AreaTargetBehaviour macBridgeArea;
    AreaTargetBehaviour boothArea;
    AreaTargetBehaviour entranceArea;
    AreaTargetBehaviour newlabArea;
    AreaTargetBehaviour btsArea;
    MainMenuScript mainMenuScript;
    public void Start()
    {
        mainMenuScript = GameObject.Find("MainMenuScript").GetComponent<MainMenuScript>();
        tookPicUI = GameObject.Find("TookPicUI");
    }
    public void Update()
    {
        if (mainMenuScript.startButtonPressed == true)
        {
            TrackAreaTargets();
        }
    }
    private IEnumerator Screenshot()
    {
        yield return new WaitForEndOfFrame();
        Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);

        texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        texture.Apply();

        string name = "Screenshot_DDFF_App" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png";

        // Mobile
        NativeGallery.SaveImageToGallery(texture, "DDFF Pic", name);

        Destroy(texture);
    }
    public void TakePicture()
    {
        StartCoroutine("Screenshot");
        //tookPicUI.transform.localScale = new Vector3(1, 1, 1);
        //timer = new Timer(2000, alertTimerCallback);
    }
    public void alertTimerCallback()
    {
        tookPicUI.transform.localScale = new Vector3(0, 0, 0);
    }
    public void goToFBSSite()
    {
        Application.OpenURL("http://finalbossar.com");
    }
    public void goToDCSite()
    {
        Application.OpenURL("https://dronecapital.com/");
    }
    public void SideMenuOpen()
    {
        hamMenuOpen = GameObject.Find("HamMenu-Open");
        sideNav = GameObject.Find("SideNav");

        // Hide Open SideMenu Button
        hamMenuOpen.transform.localScale = new Vector3(0, 0, 0);

        // Push SideMenu to Screen
        sideNav.transform.localScale = new Vector3(1, 1, 1);
    }
    public void SideMenuClose()
    {
        hamMenuOpen = GameObject.Find("HamMenu-Open");
        sideNav = GameObject.Find("SideNav");

        // Show Open SideMenu Button
        hamMenuOpen.transform.localScale = new Vector3(1, 1, 1);

        // Hide SideMenu from Screen
        sideNav.transform.localScale = new Vector3(0, 1, 0);
    }
    public void MessageUIOpen()
    {
        infoUI = GameObject.Find("InfoUI");

        // Show MessageUI
        infoUI.transform.localScale = new Vector3(1, 1, 1);
    }
    public void MessageUIClose()
    {
        infoUI = GameObject.Find("InfoUI");

        // Hide MessageUI
        infoUI.transform.localScale = new Vector3(0, 0, 0);

        // Reveal the HUD
        HUD = GameObject.Find("HUD");
        HUD.transform.localScale = new Vector3(1, 1, 1);
    }
    public void HideScanningUI()
    {
        scanningUI = GameObject.Find("ScanningUI");
        scanningUI.transform.localScale = new Vector3(0, 0, 0);
        
        // Track all AreaTargets
        // When an AreaTarget is Lost, Show ScanningUI

    }
    public void TrackAreaTargets()
    {
        areaTargetBeh = GameObject.Find("705NightAreaTarget").GetComponent<AreaTargetBehaviour>();
        macBridgeArea = GameObject.Find("MacAreaTarget").GetComponent<AreaTargetBehaviour>();
        boothArea = GameObject.Find("BoothAreaTarget").GetComponent<AreaTargetBehaviour>();
        entranceArea = GameObject.Find("EntranceAreaTarget").GetComponent<AreaTargetBehaviour>();
        newlabArea = GameObject.Find("EntranceAreaTarget").GetComponent<AreaTargetBehaviour>();
        btsArea = GameObject.Find("EntranceAreaTarget").GetComponent<AreaTargetBehaviour>();

        if (areaTargetBeh.TargetStatus.Status == Status.NO_POSE ||
           areaTargetBeh.TargetStatus.StatusInfo == StatusInfo.NOT_OBSERVED &&

           macBridgeArea.TargetStatus.Status == Status.NO_POSE ||
           macBridgeArea.TargetStatus.StatusInfo == StatusInfo.NOT_OBSERVED &&

           boothArea.TargetStatus.Status == Status.NO_POSE ||
           boothArea.TargetStatus.StatusInfo == StatusInfo.NOT_OBSERVED &&

           entranceArea.TargetStatus.Status == Status.NO_POSE ||
           entranceArea.TargetStatus.StatusInfo == StatusInfo.NOT_OBSERVED &&

           newlabArea.TargetStatus.Status == Status.NO_POSE ||
           newlabArea.TargetStatus.StatusInfo == StatusInfo.NOT_OBSERVED &&

           btsArea.TargetStatus.Status == Status.NO_POSE ||
           btsArea.TargetStatus.StatusInfo == StatusInfo.NOT_OBSERVED
           )
        {
            scanningUI = GameObject.Find("ScanningUI");
            scanningUI.transform.localScale = new Vector3(1, 1, 1);
        } else
        {
            scanningUI = GameObject.Find("ScanningUI");
            scanningUI.transform.localScale = new Vector3(0, 0, 0);
        }
        
        

    }
}
