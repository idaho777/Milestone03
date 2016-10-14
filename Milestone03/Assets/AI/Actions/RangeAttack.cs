using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class RangeAttack : RAINAction
{
    private static float FIRE_RATE = 2;

    private Transform target;
    private float time;
    private GameObject projectilePrefab;
    private AudioSource audio;

    public override void Start(RAIN.Core.AI ai)
    {
        target = GameObject.Find("Player_Container_Prefab").transform;
        projectilePrefab = Resources.Load("Projectile") as GameObject;
        audio = GameObject.Find("NPC_Prefab").GetComponent<AudioSource>();

        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
        time = time + Time.deltaTime;
        if (time > FIRE_RATE)
        {
            shootProjectile(GameObject.Instantiate(projectilePrefab), ai);
            time = 0;
        }
        
        return ActionResult.SUCCESS;
    }

    private void shootProjectile(GameObject projectile, RAIN.Core.AI ai)
    {
        projectile.transform.position = ai.Body.transform.position + new Vector3(0, 1, 0) + ai.Body.transform.forward;
        
        Vector2 Pbi = new Vector2(projectile.transform.position.x, projectile.transform.position.z);            // initial projectile position
        Vector2 Pti = new Vector2(target.position.x, target.position.z);   // initial player position
        Vector2 Vt = new Vector2(target.GetComponent<Rigidbody>().velocity.x, target.GetComponent<Rigidbody>().velocity.z); // player velocity

        float Sb = 10;                              // projectile speed
        float theta = Vector2.Angle(Vt, Pti - Pbi); // angle between player velocity and player - projectile.
        float D = Vector2.Distance(Pbi, Pti);       // distance between player and projectile initially
        float St = Vt.magnitude;           // player speed

        float t = (-2 * D * St * Mathf.Cos(theta) + Mathf.Sqrt((2 * D * St * Mathf.Cos(theta)) * 2 + 4 * (Mathf.Pow(Sb, 2) - Mathf.Pow(St, 2)) * Mathf.Pow(D, 2)))
                / (2 * (Mathf.Pow(Sb, 2) - Mathf.Pow(St, 2)));

        float t2 = (-2 * D * St * Mathf.Cos(theta) + Mathf.Sqrt((2 * D * St * Mathf.Cos(theta)) * 2 + 4 * (Mathf.Pow(Sb, 2) - Mathf.Pow(St, 2)) * Mathf.Pow(D, 2)))
                / (2 * (Mathf.Pow(Sb, 2) - Mathf.Pow(St, 2)));
        
        Vector2 Vb = Vt + ((Pti - Pbi) / t);

        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(Vb.normalized.x, 0, Vb.normalized.y) * Sb;

        ai.WorkingMemory.SetItem<int>("ammo", ai.WorkingMemory.GetItem<int>("ammo") - 1);

        audio = projectile.GetComponent<AudioSource>();
        audio.clip = Resources.Load<AudioClip>("Sounds/shoot");
        audio.Play();
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}