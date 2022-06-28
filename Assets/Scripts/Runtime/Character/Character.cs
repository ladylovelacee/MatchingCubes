using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    #region Local Events
    [HideInInspector]
    public StackEvent OnStackCollected = new StackEvent();
    [HideInInspector]
    public UnityEvent OnStacksSort = new UnityEvent();    
    [HideInInspector]
    public UnityEvent OnStacksShuffle = new UnityEvent();
    #endregion

    [SerializeField]
    private CharacterData characterData;
    public CharacterData CharacterData => characterData;
}
