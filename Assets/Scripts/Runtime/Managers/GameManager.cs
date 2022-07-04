using UnityEngine;

[System.Serializable]
public class GameData
{
    public bool IsFeverModeActive = false;
    public float FeverTimer = 3;
    public float SpeederTimer = 3;
    public Transform Mover;
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
    public GameData GameData = new GameData();
    
    private PlayerData playerData;
    public PlayerData PlayerData
    {
        get
        {
            if (playerData == null)
            {
                playerData = SaveLoad.GetObject<PlayerData>(PlayerPrefsKeys.PlayerData, new PlayerData());
                if (playerData == null)
                    playerData = new PlayerData();
            }

            return playerData;
        }
    }
}