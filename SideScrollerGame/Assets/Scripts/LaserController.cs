using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour {

	[SerializeField]
	float speed =0.1f;

	private Transform _transform;
	private Vector2 _currentPos;
	// Use this for initialization
	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		_currentPos = _transform.position;
		_currentPos += new Vector2 (speed, 0);
		_transform.position = _currentPos;
		if (_currentPos.x > 19)
			Destroy (gameObject);
	}
}
