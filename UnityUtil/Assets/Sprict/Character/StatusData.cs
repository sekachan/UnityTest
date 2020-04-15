using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// データを宣言するクラス（ScriptableObject）
/// 定数データ、URL、ファイルパスなど
/// </summary>
public class StatusData : ScriptableObject
{
    public int PlayerHP { get; set; } = 200;

    public int EnemyHP { get; set; } = 100;

    public bool IsFlag = false;
}
