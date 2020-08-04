using UnityEngine;

public class DisableAfterThreeSec : MonoBehaviour
{
    private void Start()
    {
        Invoke(nameof(Do), 1.5f);
    }

    private void Do()
    {
        gameObject.SetActive(false);
    }
}
