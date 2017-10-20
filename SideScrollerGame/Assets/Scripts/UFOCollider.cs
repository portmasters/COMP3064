using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Source File Name:UFOCollider.cs
 * Author's Name: Albert Nguyen
 * Last Modified by: Albert Nguyen
 * Date Last Modified: Oct 20, 2017
 * 
 *Program Descrption: How the PLAYER UFO collision work with external object
 *
 *Revision History:
 *
*/
public class UFOCollider : MonoBehaviour {

	//My Variables
	[SerializeField]
	GameObject death = null;
	[SerializeField]
	private GameController gameController;


	private AudioSource deathSound = null;
	private AudioSource coinSound = null;

	void Start (){
		
	}


	void OnTriggerEnter2D(Collider2D external){

		//Coin Collision
		if (external.gameObject.tag == ("PickUp")) {
			Debug.Log ("Coin Collision\n");

			//Calls the Reset function from the external collider
			external.gameObject.GetComponent <CoinController> ().Reset();

			//set coinSound to the coins audio source. Play coinSound
			coinSound = external.gameObject.GetComponent<AudioSource>();
			if (coinSound != null) 
				coinSound.Play ();

			//Update Scoreboard
			gameController.Score += 100;

		}
		//Enemy Collision
		else if (external.gameObject.tag == ("Enemy") ||external.gameObject.tag == ("Enemy2")  ) {
			Debug.Log ("Enemy Collision\n");

			//Explode upon collision
			GameObject o = Instantiate (death);
			o.transform.position = external.gameObject.transform.position;

			//Calls the Reset function from the external collider
			if(external.gameObject.tag == ("Enemy")) 
				external.gameObject.GetComponent <EyeBallController> ().Reset();
			else
				external.gameObject.GetComponent <RedUFOController> ().Reset();

			//Set deathSound to the colider object audio source. Play deathSound
			deathSound = external.gameObject.GetComponent<AudioSource>();
			if (deathSound != null) 
				deathSound.Play ();

			//Upon collision remove a life. Destroy PLAYER UFO when life==0. Background music will end since PLAYER UFO has the audio source.
			gameController.Life--;
			if (gameController.Life == 0)
				Destroy (gameObject);
		}



	}


}
