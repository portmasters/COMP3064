using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerColider : MonoBehaviour {

	// Use this for initialization
	//My Variables
	[SerializeField]
	GameObject death = null;



	private AudioSource deathSound = null;


	void Start (){

	}


	void OnTriggerEnter2D(Collider2D external){



		//Enemy Collision
		if (external.gameObject.tag == ("Enemy") || external.gameObject.tag == ("Enemy2")) {
			Debug.Log ("Enemy Collision\n");

			//Explode upon collision
			GameObject o = Instantiate (death);
			o.transform.position = external.gameObject.transform.position;

			//Reset Object
			if (external.gameObject.tag == ("Enemy"))
				external.gameObject.GetComponent <EyeBallController> ().Reset ();
			else
				external.gameObject.GetComponent <RedUFOController> ().Reset ();

			//Set deathSound to the colider object audio source. Play deathSound
			deathSound = external.gameObject.GetComponent<AudioSource> ();
			if (deathSound != null)
				deathSound.Play ();
			Destroy (gameObject);
	
		}
	}
}
