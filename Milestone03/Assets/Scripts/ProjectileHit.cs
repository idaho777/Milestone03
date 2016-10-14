using UnityEngine;
using System.Collections;

public class ProjectileHit : MonoBehaviour {

    public int damage;
    	
    void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag == "Player")
        {
            X_Bot_Controller script = col.transform.GetComponent<X_Bot_Controller>();
            AudioSource audio = col.transform.GetComponent<AudioSource>();
            script.DealDamage(damage);

            audio.clip = Resources.Load<AudioClip>("Sounds/projectile_hit");
            audio.Play();

            damage = 0;
        }
        GameObject.Destroy(this.gameObject);
    }
}
