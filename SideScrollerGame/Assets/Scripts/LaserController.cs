using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Source File Name:LaserController.cs
 * Author's Name: Albert Nguyen
 * Last Modified by: Albert Nguyen
 * Date Last Modified: Oct 20, 2017
 * 
 * Program Descrption:How the laser is moved.
 *
 * Revision History:
 *
*/

public class LaserController : MonoBehaviour {
	
	[SerializeField]
	float speed =0.1f;

	private Transform _transform;
	private Vector2 _currentPos;


	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
	}
	
	//Moves the laser towards the right. When laser is outside of the game screen the destroy function is called.
	void Update () {
		_currentPos = _transform.position;
		_currentPos += new Vector2 (speed, 0);
		_transform.position = _currentPos;
		if (_currentPos.x > 19)
			Destroy (gameObject);
	}
}
