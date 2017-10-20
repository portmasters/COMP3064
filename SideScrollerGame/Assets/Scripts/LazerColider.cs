using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Source File Name:LazerColider.cs
 * Author's Name: Albert Nguyen
 * Last Modified by: Albert Nguyen
 * Date Last Modified: Oct 20, 2017
 * 
 *Program Descrption: How collision between laser and enemies work
 *
 *Revision History:
 *
*/
public class LazerColider : MonoBehaviour {

	// Use this for initialization
	//My Variables
	[SerializeField]
	GameObject death = null;



	private AudioSource deathSound = null;


	void Start (){

	}


	void OnTriggerEnter2D(Collider2D external){

		//Enemy Collision with laser
		if (external.gameObject.tag == ("Enemy") || external.gameObject.tag == ("Enemy2")) {
			Debug.Log ("Enemy Collision\n");

			//Instantiate the exploding animation
			GameObject o = Instantiate (death);
			o.transform.position = external.gameObject.transform.position;

			//Calls the reset function from the external collider
			if (external.gameObject.tag == ("Enemy"))
				external.gameObject.GetComponent <EyeBallController> ().Reset ();
			else
				external.gameObject.GetComponent <RedUFOController> ().Reset ();

			//Set the variable deathSound to the external collider audio source. Play deathSound
			deathSound = external.gameObject.GetComponent<AudioSource> ();
			if (deathSound != null)
				deathSound.Play ();
			
			//Destroys the laser after collision
			Destroy (gameObject);
	
		}
	}
}
