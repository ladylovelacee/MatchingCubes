using UnityEngine;

public class TrailController : MonoBehaviour
{
    TrailRenderer _trailRenderer;
    TrailRenderer TrailRenderer => (_trailRenderer == null) ? _trailRenderer = GetComponent<TrailRenderer>() : _trailRenderer;

    Character _character;
    Character Character => (_character == null) ? _character = GetComponentInParent<Character>() : _character;

    MaterialPropertyBlock propertyBlock = new MaterialPropertyBlock();

    Color curColor = Color.white;

    private void OnEnable()
    {
        HideTrail();
        Character.OnStackCollected.AddListener(UpdateTrail);
    }

    private void OnDestroy()
    {
        Character.OnStackCollected.RemoveListener(UpdateTrail);
    }

    private void UpdateTrail(IStackable stack)
    {
        
    }

    private void ShowTrail()
    {

    }

    private void HideTrail()
    {

    }
}
