using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour {

	// Use this for initialization
	public Rigidbody2D player;
	public Vector2 position;
     Rigidbody2D rigidbody;
	void Start () {
		
		rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		position =new Vector2 (player.position.x, transform.position.y);
		
		transform.position = position;
	}
}
