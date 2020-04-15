using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// セーブデータクラス
/// セーブされないのは プロパティ, static, private, なデータ
/// </summary>
public class SaveData
{ 
    public int PlayerHP;

    public int EnemyHP;
 
    [SerializeField] private GameObject obj;
    public GameObject Obj
    {
        set { this.obj = value; }
        get { return obj; }
    }

    public string GetJsonData()
    {
        return JsonUtility.ToJson(this);
    }

}


