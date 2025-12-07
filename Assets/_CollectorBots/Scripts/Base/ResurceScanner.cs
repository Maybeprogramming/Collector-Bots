using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResurceScanner : MonoBehaviour
{
    [SerializeField] private Transform _centerLocation;
    [SerializeField] private float _radius;
    [SerializeField] private List<Resource> _resources;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _timeBeetweenScanning;

    [SerializeField] private ScanAnimation _scanAnimation;

    [SerializeField] private bool isGizmosVisible;
    [SerializeField, Range(0, 1)] private float _transporentGizmos;
    [SerializeField] private Color _gizmosColor;

    private void OnDrawGizmos()
    {
        if (isGizmosVisible)
            Gizmos.color = new Color(_gizmosColor.r, _gizmosColor.g, _gizmosColor.b, _transporentGizmos);
        Gizmos.DrawSphere(_centerLocation.position, _radius);
    }

    private void Start()
    {
        StartCoroutine(Scanning());
    }

    public void LocationToScan()
    {
        Debug.Log("Сканиерование");

        var colliders = Physics.OverlapSphere(_centerLocation.position, _radius, _layerMask);

        if (colliders.Length != 0)
        {
            Debug.Log("Найдено ресурсов: " + colliders.Length);

            foreach (var collider in colliders)
            {
                if (_resources.Contains(collider.GetComponent<Resource>()) == false)
                    _resources.Add(collider.GetComponent<Resource>());
            }
        }
    }

    public bool TryGetResource(out Resource resource)
    {
        if (_resources.Count != 0)
        {
            resource = _resources.First();
            return true;
        }
        else
        {
            resource = null;
            return false;
        }    
    }

    private IEnumerator Scanning()
    {
        while (enabled)
        {
            _scanAnimation.gameObject.SetActive(true);
            _scanAnimation.RunScaning();
            yield return new WaitForSeconds(_timeBeetweenScanning);
            _scanAnimation.gameObject.SetActive(false);
            LocationToScan();
        }
    }
}