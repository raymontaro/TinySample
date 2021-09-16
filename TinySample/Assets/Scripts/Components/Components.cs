using Unity.Entities;
using Unity.Mathematics;

public struct Spawn : IBufferElementData
{
    public Entity Prefab;
}
