using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	//Reset object to random location. Set the direction and speed of the object to a random number
	public void Reset(){
		float xSpeed = Random.Range (minX, maxX);
		float ySpeed = Random.Range (minY, maxY);
		_currentSpeed = new Vector2 (xSpeed, ySpeed);

		float y = Random.Range (-0.1f, 0.1f); 
		_transform.position	=	new Vector2 (startX+Random.Range(0,50), y);

	}
		
	//Object will move towards the left with randomize direction of up or down. If object hit boundaries of x or y call Reset() function
	void Update () {
		_currentPos = _transform.position;
		_currentPos -= _currentSpeed;
		_transform.position = _currentPos;

		if (_currentPos.x <= endX || _currentPos.y >= topY || _currentPos.y <= bottomY) {
			Reset ();
		}
	}

}
