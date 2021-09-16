using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class SpawnWithTapComponent : MonoBehaviour, IConvertGameObjectToEntity, IDeclareReferencedPrefabs
{
    public GameObject[] Prefabs;



    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {        
        var buffer = dstManager.AddBuffer<Spawn>(entity);
        foreach(var s in Prefabs)
        {
            buffer.Add(new Spawn { Prefab = conversionSystem.GetPrimaryEntity(s)});
        }
    }

    public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
    {
        foreach(var p in Prefabs)
        {
            referencedPrefabs.Add(p);
        }
    }
}
