using UnityEngine;

public abstract class SingletonX<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T instance = null;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                // Debug.Log("loading");
                instance = FindObjectOfType<T>();
            }
            return instance;
        }
    }
}