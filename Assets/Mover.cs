using DG.Tweening;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Transform _baseTransform;
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private float _durationTime;
    [SerializeField] private int _repeatCount;
    [SerializeField] private float _delayTime;

    private void Start()
    {
        Sequence sequence = DOTween.Sequence();

        var targetPos = new Vector3(_targetTransform.position.x, transform.position.y, _targetTransform.position.z);
        var basePos = new Vector3(_baseTransform.position.x, transform.position.y, _baseTransform.position.z);

        sequence.Append(transform.DOMove(targetPos, _durationTime).SetDelay(_delayTime))
                .Join(transform.DOLookAt(targetPos, 0.3f))
                .Append(transform.DOMove(basePos, _durationTime).SetDelay(_delayTime))
                .Join(transform.DOLookAt(basePos, 0.3f))
                .SetLoops(_repeatCount, LoopType.Restart);
    }
}