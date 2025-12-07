using TMPro;
using UnityEngine;

public class ResourceCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _label;
    [SerializeField] private int _count;
    [SerializeField] private string _text;

    private void Start()
    {
        _count = 0;
        _label.text = $"Ресурсов\n- {_count} -";
    }

    public void Add()
    {
        _count++;
        _label.text = $"Ресурсов\n- {_count} -";
    }
}