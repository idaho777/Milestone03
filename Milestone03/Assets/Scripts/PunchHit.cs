using UnityEngine;
using System.Collections;
using RAIN.Core;

public class PunchHit : MonoBehaviour {

    public X_Bot_Controller controller;
    public GameObject hitter;
    public RAIN.Core.AIRig ai;

    void Start()
    {
        
    }

	void Update () {
	}

    void Punch()
    {
        hitter = GameObject.Find("NPC_Prefab");
        Debug.Log(hitter);
        Debug.Log("PUNCH");
        GameObject.Find("NPC_Prefab");



    }
}
