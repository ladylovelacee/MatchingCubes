using UnityEngine.Events;
using UnityEngine;
public class LevelManager : Singleton<LevelManager>
{
    [HideInInspector]
    public UnityEvent OnLevelStart = new UnityEvent();
    [HideInInspector]
    public UnityEvent OnLevelFinish = new UnityEvent();

    public LevelData LevelData;
    public Level CurrentLevel { get { return LevelData.Levels[LevelIndex]; } }

    bool isLevelStarted;
    public bool IsLevelStarted { get { return isLevelStarted; } set { isLevelStarted = value; } }

    public int LevelIndex
    {
        get
        {
            int level = SaveLoad.GetInt(PlayerPrefsKeys.LastLevel, 0);
            if (level > LevelData.Levels.Count - 1)
                level = 0;

            return level;
        }
        set
        {
            PlayerPrefs.SetInt(PlayerPrefsKeys.LastLevel, value);
        }
    }

    public void ReloadLevel()
    {
        FinishLevel();
        SceneController.Instance.LoadScene(CurrentLevel.LoadLevelID);
    }

    public void LoadLastLevel()
    {
        FinishLevel();
        SceneController.Instance.LoadScene(CurrentLevel.LoadLevelID);
    }

    public void LoadNextLevel()
    {
        FinishLevel();

        LevelIndex++;
        if (LevelIndex > LevelData.Levels.Count - 1)
        {
            LevelIndex = 0;
        }

        SceneController.Instance.LoadScene(CurrentLevel.LoadLevelID);
    }

    public void LoadPreviousLevel()
    {
        FinishLevel();

        LevelIndex--;
        if (LevelIndex <= -1)
        {
            LevelIndex = LevelData.Levels.Count - 1;

        }

        SceneController.Instance.LoadScene(CurrentLevel.LoadLevelID);
    }

    public void StartLevel()
    {
        if (IsLevelStarted)
            return;
        IsLevelStarted = true;
        OnLevelStart.Invoke();
    }

    public void FinishLevel()
    {
        if (!IsLevelStarted)
            return;
        IsLevelStarted = false;
        OnLevelFinish.Invoke();
    }
}