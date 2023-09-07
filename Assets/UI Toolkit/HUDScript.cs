using System.Collections;
using UnityEngine;

public class HUDScript : MonoBehaviour
{
    GameObject hamMenuOpen;
    GameObject sideNav;
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
}
