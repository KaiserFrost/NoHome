using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Manager : MonoBehaviour {

	public int comida;
	//public TextMeshPro comidaText;
	public Text comidaText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		comidaText.text = ("Snacks: " + comida);
	}
}
