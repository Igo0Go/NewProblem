using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplicaPoint : LogicModule
{
    public ReplicDispetcher replicDispether;
    public List<ReplicItem> replicas;

    public override void ActivateModule()
    {
        DeleteMeFromActors();
        PlayReplicas();
    }

    [ContextMenu("???????? ??? ???????")]
    public void PlayReplicas()
    {
        replicDispether.AddInList(replicas);

        float delayTime = 0;

        foreach (var item in replicas)
        {
            delayTime += item.clip.length;
        }
        delayTime += 2;
        Destroy(gameObject, delayTime + 1);
    }
}
