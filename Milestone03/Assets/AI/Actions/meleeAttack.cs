using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class meleeAttack : RAINAction
{
    private static float PUNCH_RATE = 2;
    private static int DAMAGE = 10;

    private AudioSource audio;
    private Transform target;
    private float time;

    public override void Start(RAIN.Core.AI ai)
    {
        target = GameObject.Find("Player_Container_Prefab").transform;
        audio = GameObject.Find("NPC_Prefab").GetComponent<AudioSource>();
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
        time = time + Time.deltaTime;
        if (time > PUNCH_RATE)
        {
            X_Bot_Controller controller = target.GetComponent<X_Bot_Controller>();
            controller.DealDamage(DAMAGE);
            audio.clip = Resources.Load<AudioClip>("Sounds/punch");
            audio.Play();
            time = 0;
        }
        if (!audio.isPlaying)
            audio.clip = Resources.Load<AudioClip>("Sounds/found");

        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}