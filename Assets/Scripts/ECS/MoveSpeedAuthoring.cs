using UnityEngine;
using Unity.Entities;

public class MoveSpeedAuthoring : MonoBehaviour
{
    public float WalkSpeed;
    public float RunSpeed;

    private class Baker : Baker<MoveSpeedAuthoring>
    {
        public override void Bake(MoveSpeedAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new MoveSpeed
            {
                WalkSpeed = authoring.WalkSpeed,
                RunSpeed = authoring.RunSpeed,
            });
        }
    }
}

public struct MoveSpeed : IComponentData
{
    public float WalkSpeed;
    public float RunSpeed;
}
