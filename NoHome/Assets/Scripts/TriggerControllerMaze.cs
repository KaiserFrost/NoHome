using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerControllerMaze : MonoBehaviour {

	 public GameObject guiObj;
     public string lvlToLoad;
     
	// Use this for initialization
	void Start () {
        guiObj.SetActive(false);
       
	}

   
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            guiObj.SetActive(true);
            
            //if ( Input.GetKeyDown(KeyCode.Space))
            //{
                SceneManager.LoadScene(lvlToLoad);
                Debug.Log("MUDA CENA");
            //}

        }

        
    }

    void OnTriggerExit2D()
    {
        guiObj.SetActive(false);
    }

	

}
