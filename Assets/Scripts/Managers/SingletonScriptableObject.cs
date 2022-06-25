using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingletonScriptableObject<T> : ScriptableObject where T : ScriptableObject
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                T[] results = Resources.FindObjectsOfTypeAll<T>();
                if (results.Length == 0)
                {
                    Debug.LogError("Singleton ScriptableObject " + typeof(T).ToString() + " not found in Resources");
                    return null;
                }
                else if (results.Length > 1)
                {
                    Debug.LogError("Singleton ScriptableObject " + typeof(T).ToString() + " found multiple times in Resources");
                    return null;
                }

                _instance = results[0];
            }
            return _instance;
        }
    }
}

