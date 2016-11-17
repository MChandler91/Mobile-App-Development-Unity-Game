using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class buttonScript : MonoBehaviour {

    /// <summary>
    /// A text variable to hold the string which will display on the button in the UI
    /// </summary>
    public Text quitBtn;

    /// <summary>
    /// Called once at the start
    /// </summary>
    void Start()
    {
        //Set the button's text appropriately
        quitBtn.text = "Quit Application";
    }

    /// <summary>
    /// Will be called when the button is pressed
    /// </summary>
   public void quitClick()
    {
        //Quit the application
        Application.Quit();
    }

}
