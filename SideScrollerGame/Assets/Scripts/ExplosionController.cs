using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Source File Name:ExplosionController.cs
 * Author's Name: Albert Nguyen
 * Last Modified by: Albert Nguyen
 * Date Last Modified: Oct 20, 2017
 * 
 *Program Descrption: Destroy exploding animation
 *
 *Revision History:
 *
*/


public class ExplosionController : MonoBehaviour {

	public float delay = 3f;

	// Removes the object from the game completely after 3 seconds. Solution found by firestroke on http://answers.unity3d.com/questions/670860/delete-object-after-animation-2d.html
	void Start(){
		Destroy (gameObject,+delay);

	}
	//Destroy the exlpoding animiation at the end of its animation
	public void End(){
		Destroy (gameObject);
	}

}
