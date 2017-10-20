using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Source File Name:CoinCollider.cs
 * Author's Name: Albert Nguyen
 * Last Modified by: Albert Nguyen
 * Date Last Modified: Oct 20, 2017
 * Program Descrption: How the Coin works.
 * Revision History:
 *
*/



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

	//Reset the coin to random location within boundaries
	public void Reset(){
		float y = Random.Range (topY, bottomY); 
		_transform.position	=	new Vector2 (startX+Random.Range(0,50), y);
	}

	//Coin will move towards the left. If the coin hits the boundaries of x or y call Reset() function
	void Update () {
		_currentPos = _transform.position;
		_currentPos -= new Vector2 (speed, 0);
		_transform.position = _currentPos;

		if (_currentPos.x <= endX || _currentPos.y >= topY || _currentPos.y <= bottomY) {
			Reset ();
		}
	}

}
