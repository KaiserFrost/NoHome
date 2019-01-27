using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour {

	public int intensity = 0;  // 0 normal e 1 perseguição

	public bool walking = false;
	FMODUnity.StudioEventEmitter walkSound;
	FMOD.Studio.EventInstance music;
	FMOD.Studio.EventInstance ambience;

	[SerializeField] private float walkTiming = 0.5f; 

	private bool coroutineStarted;
	// Use this for initialization
	void Start () {
		
		walkSound = GetComponent<FMODUnity.StudioEventEmitter>();
		music = FMODUnity.RuntimeManager.CreateInstance("event:/Music");
		ambience = FMODUnity.RuntimeManager.CreateInstance("event:/Ambience");
		
		music.start();
		music.setVolume(0.5f);
		music.setParameterValue("Intensity", 0f);
		ambience.start();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetAxisRaw("Horizontal") != 0)
		{
			if (!coroutineStarted)
			{
				coroutineStarted = true;
				StartCoroutine(SoundSpacing());
			}	
		}

		if (intensity == 1)
			music.setParameterValue("Intensity", 1f);
		else
			music.setParameterValue("Intensity", 0f);
		
	}

	IEnumerator SoundSpacing()
	{
		yield return new WaitForSeconds(walkTiming);
		walkSound.Play();
		
		coroutineStarted = false;
	}
}
