using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {

	//My Variables
	[SerializeField]
	private float speed;
	[SerializeField]
	private float startX;
	[SerializeField]
	private float endX;
	[SerializeField]
	private float topY;
	[SerializeField]
	private float bottomY;

	private Transform _transform;
	private Vector2 _currentPos;


	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		Reset ();
	}

	//Reset object to random location within boundaries
	public void Reset(){
		float y = Random.Range (-0.1f, 0.1f); 
		_transform.position	=	new Vector2 (startX+Random.Range(0,50), y);
	}

	//Object will move towards the left. If object hit boundaries of x call Reset() function
	void Update () {
		_currentPos = _transform.position;
		_currentPos -= new Vector2 (speed, 0);
		_transform.position = _currentPos;

		if (_currentPos.x <= endX || _currentPos.y >= topY || _currentPos.y <= bottomY) {
			Reset ();
		}
	}

}
