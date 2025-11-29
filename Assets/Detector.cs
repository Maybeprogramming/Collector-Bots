using UnityEngine;

public class Detector : MonoBehaviour
{
    [SerializeField] private GameObject _ore;

    private void OnTriggerEnter(Collider other)
    {
        _ore.SetActive(!_ore.activeSelf);
    }
}