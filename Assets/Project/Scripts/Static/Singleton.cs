using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindFirstObjectByType(typeof(T)) as T;
                if (_instance == null)
                {
                    SetupInstance();
                }
            }
            return _instance;
        }
    }
    public virtual void Awake()
    {
        RemoveDuplicates();
    }

    private static void SetupInstance()
    {
        _instance = FindFirstObjectByType(typeof(T)) as T;

        if (_instance)
        {
            Destroy( _instance );
        }

        //GameObject gameObj = new GameObject();
        //gameObj.name = typeof(T).Name;
        //_instance = gameObj.AddComponent<T>();
    }

    public void RemoveDuplicates()
    {
        _instance = FindFirstObjectByType(typeof(T)) as T;

        if (_instance && _instance != gameObject.GetComponent<T>())
        {
            Destroy(_instance);
        }

        DontDestroyOnLoad(gameObject);

        //if (_instance == null)
        //{
        //    _instance = this as T;
        //    DontDestroyOnLoad(gameObject);
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}
    }
}
