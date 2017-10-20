using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	//Reset object to random location. Set the direction and speed of the object to a random number
	public void Reset(){
		float xAcel = Random.Range (minX, maxX);
		_currentSpeed = new Vector2 (xAcel, 0);

		float y = Random.Range (bottomY, topY); 
		_transform.position	=	new Vector2 (startX+Random.Range(0,50), startY);

	}

	void Acceleration(){
		
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

	//Object will move towards the left with randomize direction of up or down. If object hit boundaries of x or y call Reset() function
	void Update () {

		if (_getLoco.x > 14) {

			_currentPos = _transform.position;
			_currentPos -= _currentSpeed;
			_transform.position = _currentPos;
			yAcel = (float)System.Math.Round(Random.Range (minY, maxY),2);
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
			
			

		} else
			Acceleration ();

		_getLoco = _transform.position;
		if (_currentPos.x <= endX ) {
			Reset ();
		}


	}
}
