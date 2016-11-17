using UnityEngine;
using System.Collections;

public class coin : MonoBehaviour {
	
	/// <summary>
    /// Called once every frame
    /// </summary>
	void Update () {

        //Rotate the coin object slowly around it's x axis
        transform.Rotate(15 * Time.deltaTime, 0, 0);
	}
}
