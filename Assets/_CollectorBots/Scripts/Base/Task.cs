using UnityEngine;

namespace CollectorBots.Sheduler
{
    public class Task
    {
        public Task(Resource resource, Vector3 basePosition)
        {
            Resource = resource;
            BasePosition = basePosition;
        }

        public Resource Resource { get; }
        public Vector3 BasePosition { get; }
        public Vector3 ResourcePosition => Resource.transform.position;
        public float Distance =>  Vector3.Distance(BasePosition, ResourcePosition);
    }
}
