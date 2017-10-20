using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour {

	public float delay = 3f;
	void Start(){
		Destroy (gameObject,+delay);

	}
	//Destroy object at the end animation
	public void End(){
		Destroy (gameObject);
	}

}
