using UnityEngine;

public class Bot: MonoBehaviour
{
    [SerializeField] private Mover _mover; //убрать
    [SerializeField] private IMover _imover; //оставить

    public void MoveTo(Vector3 target)
    {
        _mover.MoveTo(target);
    }
}