using UnityEngine;

public class Resource : MonoBehaviour
{
    public bool IsReserved { get; private set; }

    public bool TryReserved()
    {
        if (IsReserved)
        {
            return false;
        }

        IsReserved = true;
        return true;
    }

    public void RemoveReserve() =>
        IsReserved = false;
}