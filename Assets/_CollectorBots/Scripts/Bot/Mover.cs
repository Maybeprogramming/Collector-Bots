using DG.Tweening;
using UnityEngine;

public class Mover : MonoBehaviour, IMover
{
    [SerializeField] private Transform _baseTransform;
    [SerializeField] private float _offsetDistance;
    [SerializeField] private float _durationTime;
    [SerializeField] private int _repeatCount;
    [SerializeField] private float _delayTime;

    public void MoveTo(Vector3 target)
    {
        Vector3 newTarget = new Vector3(target.x, transform.position.y, target.z);
        transform.DOMove(newTarget, _durationTime).SetDelay(_delayTime).SetLoops(_repeatCount);
        transform.DOLookAt(newTarget, 0.2f);
    }

    public void ReturnToBase()
    {
        MoveTo(_baseTransform.position);
    }
}