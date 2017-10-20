using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Source File Name:EyeBallController.cs
 * Author's Name: Albert Nguyen
 * Last Modified by: Albert Nguyen
 * Date Last Modified: Oct 20, 2017
 * 
 *Program Descrption: How the Eyeball works
 *
 *Revision History:
 *
*/

public class EyeBallController : MonoBehaviour {

	//My variables
	[SerializeField]
	float minY;
	[SerializeField]
	float maxY;
	[SerializeField]
	float minX;
	[SerializeField]
	float maxX;
	[SerializeField]
	float startX;
	[SerializeField]
	float endX;
	[SerializeField]
	float topY;
	[SerializeField]
	float bottomY;

	private Transform _transform;
	private Vector2 _currentSpeed;
	private Vector2 _currentPos;

	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		Reset ();
	}

	//Reset eyeball to a random location within bounds. Set the direction and speed of the eyeball to a random number
	public void Reset(){
		float xAcel = Random.Range (minX, maxX);
		float yAcel = Random.Range (minY, maxY);
		_currentSpeed = new Vector2 (xAcel, yAcel);

		float y = Random.Range (-0.1f, 0.1f); 
		_transform.position	=	new Vector2 (startX+Random.Range(0,50), y);

	}
		
	//Eyeball will move towards the left with randomize direction of up or down. If the eyeball hit boundaries of x or y call Reset() function
	void Update () {
		_currentPos = _transform.position;
		_currentPos -= _currentSpeed;
		_transform.position = _currentPos;

		if (_currentPos.x <= endX || _currentPos.y >= topY || _currentPos.y <= bottomY) {
			Reset ();
		}
	}

}
