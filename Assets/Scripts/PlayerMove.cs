using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    /// <summary>
    /// Used to display the current score of the player
    /// </summary>
    public Text displayScore;

    /// <summary>
    /// Used to display the current high score
    /// </summary>
    public Text displayHscore;

    /// <summary>
    /// The rigidbody of the player object
    /// </summary>
    private Rigidbody rb;

    /// <summary>
    /// The integer value of the high score
    /// </summary>
    private int highScore;

    /// <summary>
    /// The integer value of the player's score
    /// </summary>
    private int score;


	/// <summary>
    /// Called once at the start
    /// </summary>
	void Start () {

        //Grab the rigidbody component from the player object
        rb = GetComponent<Rigidbody>();

        //Set the screen's sleep timeout and orientation 
        //so that the device never goes to sleep while the application
        //is open, and so that the view mode is constantly set to "landscape"
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.orientation = ScreenOrientation.Landscape;

        //Set the score to zero
        score = 0;

        //Set the high score by referencing the player's preferences
        //from other game sessions
        highScore = PlayerPrefs.GetInt("High Score");

        //Set the UI text appropriately
        displayScore.text = "Score: " + score;
        displayHscore.text = "High score: " + highScore;


	}

    /// <summary>
    /// Will be called when a collision occurs with a trigger object
    /// </summary>
    /// <param name="col"></param>
    void OnTriggerEnter(Collider col) {

        //If the trigger object's tag is "exit" 
        //set the high score and re-load the scene to play again
        if (col.CompareTag("exit"))
        {
            PlayerPrefs.SetInt("High Score", highScore);
            SceneManager.LoadScene(0);
        }

        //Set the text for the UI appropriately
        //So that it updates as the player gains points
        displayScore.text = "Score: " + score;
        displayHscore.text = "High score: " + highScore;

        //If the trigger objects' tag is "coin"
        //increment the player's score and destroy the 
        //coin object
        if (col.CompareTag("coin"))
        {
            score++;
            Destroy(col.gameObject);
        }

    }

    /// <summary>
    /// Is called every fixed framerate frame
    /// </summary>
    void FixedUpdate () {

        //If the player's score goes above the current high score
        //set the new high score
        if(score > highScore)
        {
            highScore = score;
        }

        //Create a movement vector using input from the phone's accelerometer
        Vector3 movement = new Vector3(Input.acceleration.x, 0.0f, Input.acceleration.y);

        //Move the player object by setting the rigidbody's 
        //velocity to movement times the current value of accel.
        //By incrementing accel, the object's speed will increase
        //as the player object continues to move. 
        for (int accel = 0; accel <= 15; accel++)
        {
            rb.velocity = movement * accel;
        }

	}
}
