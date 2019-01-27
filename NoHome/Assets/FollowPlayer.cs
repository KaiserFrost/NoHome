using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {


	public Rigidbody2D player;
	private Vector3 position;
	private Vector2 positionZ;
    Rigidbody2D rigidbody;
	public float speed = 0.5f;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

		//positionZ = new Vector3()
		position = new Vector3 (player.position.x, transform.position.y, transform.position.z) * speed ;
		
		transform.position = position;
		
	}
}
