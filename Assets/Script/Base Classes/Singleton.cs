using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    public static T Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = (T)this;
    }
}
