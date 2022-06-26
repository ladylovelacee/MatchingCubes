using UnityEngine;
using DG.Tweening;
using System;

public class Tweens
{
    private Tween curTween;
    private Transform usedTransform;

    public Tweens(Transform transform)
    {
        usedTransform = transform;
    }

    public Tweens()
    {
    }

    #region Tweens For Scale
    public void PunchScaleTween(float punchRatio, float duration = 0, Ease ease = Ease.Linear, Action completeAction = null)
    {
        curTween = usedTransform.DOPunchScale(Vector3.one * punchRatio, duration)
            .SetEase(ease)
            .OnComplete(()=> {
                CompleteAction(completeAction);
            });
    }

    public void ScaleTween(Transform transform, Vector3 targetScale, float duration = 0, Ease ease = Ease.Linear, Action completeAction = null)
    {
        curTween = transform.DOScale(targetScale, duration)
            .SetEase(ease)
            .OnComplete(() =>
            {
                CompleteAction(completeAction);
            });
    }

    public void ScaleTween(Vector3 targetScale, float duration = 0, Ease ease = Ease.Linear, Action completeAction = null)
    {
        curTween = usedTransform.DOScale(targetScale, duration)
            .SetEase(ease)
            .OnComplete(() =>
            {
                CompleteAction(completeAction);
            });
    }
    #endregion

    #region Tweens For Move
    public void MoveTween(Vector3 targetPos, float duration = 0, Ease ease = Ease.Linear, Action completeAction = null)
    {
        curTween = usedTransform.DOMove(targetPos, duration)
            .SetEase(ease)
            .OnComplete(() =>
            {
                CompleteAction(completeAction);
            });
    }

    public void LoopMoveTween(Vector3 targetPos, float duration = 0, Ease ease = Ease.Linear, int loopCount = -1, LoopType loopType = LoopType.Yoyo)
    {
        curTween = usedTransform.DOMove(targetPos, duration)
            .SetEase(ease)
            .SetLoops(loopCount, loopType);
    }

    public void MoveTween(Transform transform, Vector3 targetPos, float duration = 0, Ease ease = Ease.Linear, Action completeAction = null)
    {
        curTween = transform.DOMove(targetPos, duration)
            .SetEase(ease)
            .OnComplete(() =>
            {
                CompleteAction(completeAction);
            });
    }
    #endregion

    #region Methods For Tween Process
    private void CompleteAction(Action completeAction = null)
    {
        curTween = null;

        if (completeAction != null)
            completeAction();
    }

    public void CompleteCurrentTween()
    {
        if (curTween == null)
            return;

        curTween.Complete();
    }

    public void KillCurrentTween()
    {
        if (curTween == null)
            return;

        curTween.Kill();
    }
    #endregion
}