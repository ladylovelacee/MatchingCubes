using UnityEngine;
using DG.Tweening;
public class LineController : MonoBehaviour
{
    Renderer _renderer;
    Renderer Renderer => (_renderer == null) ? _renderer = GetComponent<Renderer>() : _renderer;

    Character _character;
    Character Character => (_character == null) ? _character = GetComponentInParent<Character>() : _character;

    [SerializeField]
    private StackDataHolder stackData;
    [SerializeField]
    private Transform leadPoint;

    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private Transform[] _points;

    private void DrawLine()
    {
        for (int i = 0; i < _points.Length; i++)
        {
            _lineRenderer.SetPosition(i, _points[i].position);
        }
    }

    private void LateUpdate()
    {
        DrawLine();
    }

    private void OnEnable()
    {
        HideTrail();
        Character.OnLastStackUpdate.AddListener(UpdateTrail);
    }

    private void OnDestroy()
    {
        Character.OnLastStackUpdate.RemoveListener(UpdateTrail);
    }

    private void UpdateTrail(IStackable stack)
    {
        if (stack == null)
            HideTrail();
        else
        {
            SetTrailColor(stackData.GetColorByID(stack.StackID));
            ShowTrail();
        }
    }

    [SerializeField]
    private float transitionDuration = .2f;
    Tween curTween;
    private void SetTrailColor(Color color)
    {
        curTween.Complete();
        curTween = Renderer.material.DOColor(color, transitionDuration);
    }
    [SerializeField]
    private float fadeDuration = .5f;
    private void ShowTrail()
    {
        Renderer.material.DOFade(1, fadeDuration);
    }

    private void HideTrail()
    {
        Renderer.material.DOFade(0, fadeDuration);
    }
}
