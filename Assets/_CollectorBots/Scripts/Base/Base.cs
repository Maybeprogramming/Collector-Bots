using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Bot _bot;

    [ContextMenu("GiveTask")]
    private void GiveTask()
    {
        _bot.MoveTo(_target.position);
    }
}