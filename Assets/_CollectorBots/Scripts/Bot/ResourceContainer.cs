using DG.Tweening;
using System.Collections;
using UnityEngine;

public class ResourceContainer : MonoBehaviour
{
    [SerializeField] private Resource _resource;
    [SerializeField] private Transform _conteiner;

    public bool IsFull => _resource != null;

    private Coroutine _animating;

    public void Add(Resource resource)
    {
        _resource = resource;

        _animating = StartCoroutine(Animating(_conteiner.transform.position));

        _resource.gameObject.transform.parent = _conteiner.transform;
    }

    public Resource Drop(Vector3 target)
    {
        var resource = _resource;
        _animating = StartCoroutine(Animating(target));
        resource.gameObject.transform.parent = null;
        _resource = null;

        return resource;
    }

    private IEnumerator Animating(Vector3 target)
    {
        _resource.transform.DOMove(target, 0.1f);
        _resource.transform.DORotate(target, 0.1f);

        yield return new WaitForSeconds(0.2f);
    }
}