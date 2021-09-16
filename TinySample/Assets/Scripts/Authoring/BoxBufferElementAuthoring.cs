using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class BoxBufferElementAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
    public Entity[] objs;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        DynamicBuffer<BoxBufferElement> dynamicBuffer = dstManager.AddBuffer<BoxBufferElement>(entity);
        foreach (Entity value in objs)
        {
            dynamicBuffer.Add(new BoxBufferElement { Value = value });
        }
    }
}
