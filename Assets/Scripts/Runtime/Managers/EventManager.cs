using UnityEngine.Events;

public static class EventManager
{
    public static PlayerDataEvent OnPlayerDataUpdated = new PlayerDataEvent();
    public static SpeedEvent OnSpeedChange = new SpeedEvent();
    public static UnityEvent SetDefaultSpeed = new UnityEvent();

    public static UnityEvent OnFeverModeActive = new UnityEvent();
    public static UnityEvent OnFeverModePassive = new UnityEvent();
}

public class PlayerDataEvent : UnityEvent<PlayerData> { }
public class SpeedEvent : UnityEvent<float> { }