using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	float horizontalMove;
	float verticalMove;
	public float speed = 40f;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		horizontalMove = Input.GetAxis("Horizontal") * speed;
		verticalMove = Input.GetAxis("Vertical")*speed ;
		Debug.Log(verticalMove);
		transform.position = new Vector2(horizontalMove,verticalMove);
	}
}
