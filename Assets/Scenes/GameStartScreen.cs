using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartScreen : MonoBehaviour {
    public GameObject mainGame;
	// Use this for initialization
	void Start () {
        mainGame.SetActive(false);
	}
	
    public void Update()
    {
	    if (Input.GetKey(KeyCode.Space))
	    {
		    mainGame.SetActive(true);
		    Destroy(this.gameObject);   
	    }
    }
}
