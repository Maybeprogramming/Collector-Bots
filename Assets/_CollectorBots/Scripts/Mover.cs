using DG.Tweening;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Transform _baseTransform;
    [SerializeField] private float _offsetDistance;
    [SerializeField] private float _durationTime;
    [SerializeField] private int _repeatCount;
    [SerializeField] private float _delayTime;

    public void MoveTo(Vector3 target)
    {
        transform.DOMove(target, _durationTime).SetDelay(_delayTime).SetLoops(_repeatCount);
    }

    public void ReturnToBase()
    {
        MoveTo(_baseTransform.position);
    }
}