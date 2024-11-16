using UnityEngine;
using Unity.Entities;
using Unity.Transforms;


public partial struct ZombieMovementSystem : ISystem
{
    public void OnUpdate(ref SystemState state)
    {
        foreach ((RefRW<LocalTransform> localTransform, RefRO<MoveSpeed> moveSpeed) in SystemAPI.Query<RefRW<LocalTransform>, RefRO<MoveSpeed>>())
        {
            localTransform.ValueRW = localTransform.ValueRO.Translate(localTransform.ValueRO.Forward() * moveSpeed.ValueRO.WalkSpeed * SystemAPI.Time.DeltaTime);
        }
    }
}
