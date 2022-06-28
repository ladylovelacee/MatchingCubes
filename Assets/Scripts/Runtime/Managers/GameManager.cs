using UnityEngine;

[System.Serializable]
public class GameData
{
    public float FeverTimer;
    public float SpeederTimer = 5;
}

[System.Serializable]
public class PlayerData
{
    [SerializeField]
    private int coinAmount;
    public int CoinAmount { get { return coinAmount; } set { coinAmount = value; EventManager.OnPlayerDataUpdated.Invoke(this); } }
}

public class GameManager : Singleton<GameManager>
{
    private bool isGameStarted;
    public bool IsGameStarted { get { return isGameStarted; } private set { isGameStarted = value; } }

    public GameData GameData = new GameData();

    public void StartGame()
    {
        if (IsGameStarted)
            return;

        IsGameStarted = true;
        EventManager.OnGameStart.Invoke();
    }

    public void EndGame()
    {
        if (!IsGameStarted)
            return;

        IsGameStarted = false;
        EventManager.OnGameEnd.Invoke();
    }
}