using UnityEngine;
using System.Collections;

/// <summary>
/// This script is responsible for controlling the camera. 
/// It is re-used from the roll-a-ball project.
/// It's purpose is to make the camera operate as a third person camera, which will chase the player game object as it moves.
/// </summary>
public class cameraController : MonoBehaviour
{

    /// <summary>
    /// This game object variable is public so it will appear in the Unity suite's inspector window when viewing the object this script is attached to. 
    /// We will be able to drag and drop the player game object into the subsequent box that is created, which will allow this script to function.
    /// </summary>
    public GameObject player;

    /// <summary>
    /// A private vector3 which will be used to hold the calculated offset from the player game object and the camera.
    /// </summary>
    private Vector3 offset;

    /// <summary>
    /// Start is called at the beginning of the game, and is only called once.
    /// </summary>
    void Start()
    {
        //Offset will be assigned the value of the position of the camera minus the position of the player game object.
        offset = transform.position - player.transform.position;
    }

    /// <summary>
    /// LateUpdate is called after all other update functions have been called.
    /// </summary>
    void LateUpdate()
    {

        //Updates the position of the camera by setting it to the current position of the player game object plus the offset, meaning it will constantly be following the player game object.
        transform.position = player.transform.position + offset;
    }
}
