using UnityEngine;

public class Panel : MonoBehaviour
{
    CanvasGroup _canvasGroup;
    CanvasGroup CanvasGroup => (_canvasGroup == null) ? _canvasGroup = GetComponent<CanvasGroup>() : _canvasGroup;

    public void ShowPanel()
    {
        CanvasGroup.interactable = true;
        CanvasGroup.blocksRaycasts = true;
        CanvasGroup.alpha = 1;
    }

    public void HidePanel()
    {
        CanvasGroup.alpha = 0;
        CanvasGroup.interactable = false;
        CanvasGroup.blocksRaycasts = false;
    }
}
