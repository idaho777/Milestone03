using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Goal : MonoBehaviour {
    	
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            AudioSource audio = col.transform.GetComponent<AudioSource>();
            audio.clip = Resources.Load<AudioClip>("Sounds/fireworks");
            audio.Play();
            
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }

    void Awake()
    {
        GameObject.Find("POI").SetActive(false);
    }
}
