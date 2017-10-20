using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Source File Name:RedUFOController.cs
 * Author's Name: Albert Nguyen
 * Last Modified by: Albert Nguyen
 * Date Last Modified: Oct 20, 2017
 * 
 *Program Descrption: How the red ufo works
 *
 *Revision History:
 *
*/

public class RedUFOController : MonoBehaviour {

	//My variables
	[SerializeField]
	private float minY;
	[SerializeField]
	private float maxY;
	[SerializeField]
	private float minX;
	[SerializeField]
	private float maxX;
	[SerializeField]
	private float startX;
	[SerializeField]
	private float endX;
	[SerializeField]
	private float topY;
	[SerializeField]
	private float bottomY;
	[SerializeField]
	private float startY;

	private Transform _transform;
	private Vector2 _currentSpeed;
	private Vector2 _currentPos;
	[SerializeField]
	private Vector2 _getLoco;
	[SerializeField]
	private float yAcel;
	[SerializeField]
	private float yBound;

	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		Reset ();
	}

	//Reset the red ufo position.
	public void Reset(){
		float xAcel = Random.Range (minX, maxX);
		_currentSpeed = new Vector2 (xAcel, 0);

		float y = Random.Range (bottomY, topY); 
		_transform.position	=	new Vector2 (startX+Random.Range(0,50), startY);

	}

	//Position the red ufo going up or down and then moves it in a straight line towards the player.
	void Acceleration(){

		// When red ufo hits the Y Axis boundary it will move towards a straight line. System.Math.Round is needed to detect boundaries correctly. System.Math.Round is founded by DeveshPandy on http://answers.unity3d.com/questions/535424/round-float-with-2-decimal.html
		if (System.Math.Round(_getLoco.y) != System.Math.Round(yBound) && yAcel!=0) {
			_currentPos = _transform.position;
			_currentPos -= new Vector2 (0, yAcel);
			_transform.position = _currentPos;
		} else {
			_currentPos = _transform.position;
			_currentPos -= new Vector2 (0.65f, 0);
			_transform.position = _currentPos;
		}
	}
		
	void Update () {

		//This will stop the UFO just after it has enter the game screen.
		if (_getLoco.x > 14) {

			_currentPos = _transform.position;
			_currentPos -= _currentSpeed;
			_transform.position = _currentPos;

			//Randomize the direction of the red UFO of up or down
			yAcel = (float)System.Math.Round(Random.Range (minY, maxY),2);

			//Ensure that red UFO does not past the boundaries 
			if (bottomY > 0) {
				
				if (yAcel < 0) {
					yBound = Random.Range (topY /2, topY);
					yAcel= yAcel - 0.1f;

				} else {
					yBound = Random.Range (topY/2, bottomY);
					yAcel= yAcel + 0.1f;
				}
					
			} else {
				if (yAcel < 0) {
					yBound = Random.Range (0, bottomY/2);
					yAcel= yAcel - 0.1f;
				} else {
					yBound = Random.Range (bottomY / 2, bottomY);
					yAcel= yAcel + 0.1f;
				}
			}
			
			
			//Once the red UFO stops call the Acceleration() function
		} else
			Acceleration ();
		_getLoco = _transform.position;
		//Once red UFO hits X axis boundary it will reset
		if (_currentPos.x <= endX ) {
			Reset ();
		}


	}
}
