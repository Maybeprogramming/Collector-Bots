using UnityEngine;

interface IMover
{
    void MoveTo(Vector3 target);
    void ReturnToBase();
}