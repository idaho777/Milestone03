using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class FindAmmoTent : RAINAction
{
    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
        GameObject ammoTent = GameObject.Find("AmmoTent1");
        GameObject ammoTent2 = GameObject.Find("AmmoTent2");


        float ammoTentDist = Vector3.Distance(ammoTent.transform.position, ai.Body.transform.position);
        if (Vector3.Distance(ammoTent2.transform.position, ai.Body.transform.position) < ammoTentDist)
        {
            ammoTent = ammoTent2;
        }
        ai.WorkingMemory.SetItem<string>("AmmoTent", ammoTent.name);
        
        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}