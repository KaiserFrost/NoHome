using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour {

	// Use this for initialization
	public Transform player;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.position = new Vector3(player.position.x + 6, 0, -10);
	}
}
