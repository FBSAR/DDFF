using UnityEngine;
using UnityEngine.InputSystem.HID;

public class MainMenuScript : MonoBehaviour
{
    public GameObject HUD;
    public GameObject mainMenu;
    public GameObject ScanningUI;
    GameObject infoUI;
    public bool startButtonPressed = false;
    public void Start()
    {   
        // Hide HUD during the Main Menu
        HUD = GameObject.Find("HUD");
    }

    public void StartButton()
    {
        // After the user presses the Start Button, Hide the "MainMenuWrapper"
        mainMenu = GameObject.Find("MainMenuWrapper");
        mainMenu.SetActive(false);

        startButtonPressed = true;

        infoUI = GameObject.Find("InfoUI");

        // Show MessageUI
        infoUI.transform.localScale = new Vector3(1, 1, 1);
    }
}
