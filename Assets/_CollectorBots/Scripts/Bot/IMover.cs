using UnityEngine;

public interface IMover
{
    bool IsCompliteMoving();
    void MoveTo(Vector3 target);
    void Stop();
}