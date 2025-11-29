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
                .Append(transform.DORotate(new Vector3(0f, 90f, 0f), 1f, RotateMode.FastBeyond360))
                .Append(transform.DOMove(basePos, _durationTime).SetDelay(_delayTime))
                .Append(transform.DORotate(new Vector3(0f, -90f, 0f), 1f, RotateMode.FastBeyond360))
                .SetLoops(_repeatCount, LoopType.Restart);
    }
}