using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResourcesData : MonoBehaviour
{
    private List<Resource> _resourcesAvaible;
    private List<Resource> _resourcesReserved;

    private void Start()
    {
        _resourcesAvaible = new List<Resource>();
        _resourcesReserved = new List<Resource>();
    }

    public bool TryGetResource(out Resource resource)
    {
        if (_resourcesAvaible.Count > 0)
        {
            resource = _resourcesAvaible.First();

            DoReserved(resource);

            return true;
        }

        resource = null;
        return false;
    }

    public void AddResourceToData(Resource resource)
    {
        if (_resourcesAvaible.Contains(resource) == false)
        {
            _resourcesAvaible.Add(resource);
        }
        else
        {
            Debug.LogError($"{resource} - уже в списке {nameof(_resourcesAvaible)}");
        }
    }

    public void RemoveReservation(Resource resource)
    {
        if (_resourcesReserved.Contains(resource))
        {
            DoUnreserved(resource);
        }
        else
        {
            Debug.LogError($"{resource} - нет в списке {nameof(_resourcesReserved)}");
        }
    }

    private void DoReserved(Resource resource)
    {
        _resourcesReserved.Add(resource);
        _resourcesAvaible.Remove(resource);
    }

    private void DoUnreserved(Resource resource)
    {
        _resourcesReserved.Remove(resource);
        _resourcesAvaible.Add(resource);
    }
}