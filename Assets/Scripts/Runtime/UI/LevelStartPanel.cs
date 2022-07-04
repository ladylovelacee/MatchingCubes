public class LevelStartPanel : Panel
{
    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;

        LevelManager.Instance.OnLevelStart.AddListener(HidePanel);
        LevelManager.Instance.OnLevelFinish.AddListener(ShowPanel);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        LevelManager.Instance.OnLevelStart.RemoveListener(HidePanel);
        LevelManager.Instance.OnLevelFinish.RemoveListener(ShowPanel);
    }
}
