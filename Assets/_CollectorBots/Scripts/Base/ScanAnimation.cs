using DG.Tweening;
using UnityEngine;

public class ScanAnimation : MonoBehaviour
{

    [SerializeField] private Vector3 _scaleVector;
    [SerializeField] private float _duration;
    [SerializeField] private float _delayTime;
    [SerializeField] private Ease _ease;
    [SerializeField] private int _repeatCount;
    [SerializeField] private MeshRenderer _rendererCircle1;
    [SerializeField] private MeshRenderer _rendererCircle2;
    [SerializeField] private MeshRenderer _rendererCircle3;
    [SerializeField] private float _tranporancy;

    public void RunScaning()
    {
        ResetScale();
        DoScale();
        DoFadeColor(_rendererCircle1);
        DoFadeColor(_rendererCircle2);
        DoFadeColor(_rendererCircle3);
    }

    private void DoFadeColor(MeshRenderer renderer)
    {
        ResetColor(renderer);
        renderer.material.DOFade(_tranporancy, _duration).SetDelay(_delayTime).SetEase(_ease).SetLoops(_repeatCount);
    }

    private void DoScale()
    {
        transform.DOScale(_scaleVector, _duration).SetDelay(_delayTime).SetEase(_ease).SetLoops(_repeatCount);
    }

    private void ResetScale()
    {
        transform.localScale = Vector3.one * 0.5f;
    }

    private void ResetColor(MeshRenderer renderer)
    {
        renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, 1f);
    }
}