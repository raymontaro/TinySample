using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Collections;
using Unity.Tiny.Rendering;

public class SpawnWithTapSystem : ComponentSystem
{
    private Random random;

    protected override void OnCreate()
    {
        base.OnCreate();
        
        RequireSingletonForUpdate<Spawn>();
        RequireSingletonForUpdate<Camera>();

        random = new Random(314159);
    }

    protected override void OnUpdate()
    {
        Entities.WithAll<SpawnWithTap>().ForEach((ref Tappable tappable) =>
        {
            if (tappable.IsTapped)
            {
                tappable.IsTapped = false;

                var settingsEntity = GetSingletonEntity<Spawn>();
                var settings = EntityManager.GetBuffer<Spawn>(settingsEntity);

                

                var spawnedEntity = EntityManager.Instantiate(settings[random.NextInt(settings.Length)].Prefab);                
                
                EntityManager.SetComponentData(spawnedEntity, new Translation { Value = new float3(tappable.posX, 1f, tappable.posZ) });
            }
        });

    }
}