using UnityEngine;
using UnityEngine.InputSystem.HID;

public class MainMenuScript : MonoBehaviour
{
    public GameObject HUD;
    public GameObject mainMenu;
    public GameObject ScanningUI;
    public void Start()
    {   
        // Hide HUD during the Main Menu
        HUD = GameObject.Find("HUD");
    }

    public void StartButton()
    {
        // After the user presses the Start Button, Hide the "MainMenuWrapper",
        // which holds all the elements of the Main Menu.
        mainMenu = GameObject.Find("MainMenuWrapper");
        mainMenu.SetActive(false);

        // Reveal the HUD, which includes the Hamburger Menu and the CameraButton
        HUD = GameObject.Find("HUD");
        ScanningUI = GameObject.Find("ScanningUI");

        //HUD.transform.localScale = new Vector3(1, 1, 1);
        ScanningUI.transform.localScale = new Vector3(1, 1, 1);
    }
}
