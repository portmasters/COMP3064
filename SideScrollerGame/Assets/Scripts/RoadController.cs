using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Source File Name:RoadController.cs
 * Author's Name: Albert Nguyen
 * Last Modified by: Albert Nguyen
 * Date Last Modified: Oct 20, 2017
 * 
 *Program Descrption: The background movement
 *
 *Revision History:
 *
*/
public class RoadController : MonoBehaviour {

	//My Variables
	[SerializeField]
	private float speed = 5f;
	[SerializeField]
	private float startX;
	[SerializeField]
	private float endX;
	[SerializeField]
	private float posY;

	private Transform _transform;
	private Vector2 _currentPos;




	// Use this for initialization
	void Start () {
		_transform = gameObject.GetComponent<Transform>();
		Reset ();
	}

	// Update is called once per frame
	void Update () {
		//Scrolls the background from right to left
		_currentPos = _transform.position;
		_currentPos -= new Vector2 (speed, 0);

		//if background position reaches the end of image, call Reset() function
		if(_currentPos.x < endX)
			Reset ();

		_transform.position = _currentPos;
	}

	//Reset Background to the beginning
	private void Reset(){
		_currentPos = new Vector2 (startX, posY);
	}
}
