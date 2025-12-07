using DG.Tweening;
using System.Collections;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Resource _resource;
    [SerializeField] private Transform _conteiner;

    public bool IsFull => _resource != null;

    private Coroutine _animating;

    public void Add(Resource resource)
    {
        _resource = resource;

        _animating = StartCoroutine(Animating(_conteiner.transform.position));
        Attached(_resource);
    }

    public Resource Drop(Vector3 target)
    {
        var resource = _resource;
        _animating = StartCoroutine(Animating(target));
        Detached(resource);
        _resource = null;

        return resource;
    }

    private void Attached(Resource resource)
    {
        resource.gameObject.transform.parent = _conteiner.transform;
    }

    private static void Detached(Resource resource)
    {
        resource.gameObject.transform.parent = null;
    }

    private IEnumerator Animating(Vector3 target)
    {
        _resource.transform.position = _conteiner.position;
        _resource.transform.rotation = _conteiner.rotation;
        _resource.transform.localScale = _conteiner.localScale;

        yield return null;
    }
}