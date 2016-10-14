using UnityEngine;
using System.Collections;

public class Hud : MonoBehaviour {

    public X_Bot_Controller controller;
    public GameObject health;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        health.GetComponent<UnityEngine.UI.Text>().text = "HP: " + controller.health + ":" + X_Bot_Controller.MAX_HEALTH;
	}
}
