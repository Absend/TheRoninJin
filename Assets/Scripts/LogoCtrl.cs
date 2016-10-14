using System.Xml.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoCtrl : MonoBehaviour
{
    public GUIStyle style;
    

    public void Start()
    {
        SceneManager.UnloadScene("LevelOne");
    }
    

    public void OnGUI()
    {
        DisplayLogo();
        DisplayStartButton();
    }

    //===========================================================

    private void DisplayLogo()
    {
        var r = new Rect(Screen.width / 6, Screen.height / 3 + 13, 60, 30);

        GUI.Label(r, "The Ronin Jin", this.style);
    }

    private void DisplayStartButton()
    {
        var rec = new Rect(Screen.width / 2 - 17, 2* Screen.height / 3, 60, 30);
        var button = GUI.Button(rec, "PLAY");

        if (button|| Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("LevelOne");
        }
    }
}
