using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Character character = other.GetComponent<Character>();
        if (character == null)
            return;

        LevelManager.Instance.FinishLevel();
        LevelManager.Instance.LoadNextLevel();
    }
}
