using UnityEngine.Events;

public static class EventManager
{
    public static UnityEvent OnGameStart = new UnityEvent();
    public static UnityEvent OnGameEnd = new UnityEvent();

    public static UnityEvent OnLevelStart = new UnityEvent();
    public static UnityEvent OnLevelFinish = new UnityEvent();

    public static UnityEvent OnLevelSuccess = new UnityEvent();
    public static UnityEvent OnLevelFail = new UnityEvent();

    public static PlayerDataEvent OnPlayerDataUpdated = new PlayerDataEvent();
    public static SpeedEvent OnSpeedChange = new SpeedEvent();
    public static UnityEvent SetDefaultSpeed = new UnityEvent();
}

public class PlayerDataEvent : UnityEvent<PlayerData> { }
public class SpeedEvent : UnityEvent<float> { }