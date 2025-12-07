using System.Collections;
using UnityEngine;

public class Mover : MonoBehaviour, IMover
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _offsetDistance;

    [SerializeField] private float _distance;

    private Vector3 _target;
    private Coroutine _moving;

    public Vector3 Position => transform.position;

    private void Start()
    {
        _target = transform.position;
    }

    public void MoveTo(Vector3 target)
    {
        _target = target;

        _moving = StartCoroutine(Moving());
    }

    public void Stop()
    {
        if (_moving != null)
        {
            StopCoroutine(_moving);
        }
    }

    public bool IsCompliteMoving()
    {
        _distance = Vector3.Distance(transform.position, _target);

        return _distance < _offsetDistance;
    }

    private IEnumerator Moving()
    {
        Vector3 direction = (_target - transform.position).normalized;
        transform.LookAt(new Vector3(_target.x, transform.position.y, _target.z));

        while (IsCompliteMoving() == false)
        {
            transform.position += direction * _moveSpeed * Time.deltaTime;

            yield return null;
        }
    }
}