using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 継承シングルトンクラス
/// </summary>
/// <typeparam name="T"></typeparam>
public class Singleton<T> where T : class, new()
{
    protected Singleton()
    {
        Debug.Assert(instance == null);
    }

    private static readonly T instance = new T();
    public static T Instance
    {
        get
        {
            return instance;
        }
    }
}
