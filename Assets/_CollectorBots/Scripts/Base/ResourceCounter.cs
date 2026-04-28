using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ResourceCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _label;
    [SerializeField] private int _count;
    [SerializeField] private string _text;

    private void Awake()
    {
        if (_label == null)
        {
            _label = GetComponent<TextMeshProUGUI>();
        }
    }

    private void Start()
    {
        _count = 0;
        _label.text = $"- {_count} -";
    }

    public void Add()
    {
        _count++;
        _label.text = $"- {_count} -";
    }
}