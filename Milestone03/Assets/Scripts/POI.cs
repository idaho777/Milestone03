using UnityEngine;
using System.Collections;
using RAIN.Core;

public class POI : MonoBehaviour {
    
    public RAIN.Core.AIRig ai;
    public GameObject goal;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            ai.AI.WorkingMemory.SetItem<string>("State", "Chase");
            goal.SetActive(true);

            AudioSource audio = col.transform.GetComponent<AudioSource>();
            audio.clip = Resources.Load<AudioClip>("Sounds/poi");
            audio.Play();
        }
    }
}
