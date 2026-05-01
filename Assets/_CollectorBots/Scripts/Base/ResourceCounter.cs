using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ResourceCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _label;
    [SerializeField] private int _count;

    private void Awake() =>
        _label ??= GetComponent<TextMeshProUGUI>();

    private void Start()
    {
        _count = 0;
        _label.text = $"- {_count} -";
    }

    public void Add(Resource _)
    {
        _count++;
        _label.text = $"- {_count} -";
    }
}