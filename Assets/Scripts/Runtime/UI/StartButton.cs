using UnityEngine;

public class StartButton : MonoBehaviour
{
    public void StartLevel()
    {
        if (SceneController.Instance.loadingInProgress)
            return;

        LevelManager.Instance.StartLevel();
    }
}
