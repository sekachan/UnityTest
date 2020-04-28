using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ステート処理抽象クラス
/// </summary>
public abstract class StateBase
{
    /// <summary>
    /// ステート開始処理
    /// </summary>
    public abstract void Begin();

    /// <summary>
    /// ステート終了処理
    /// </summary>
    public abstract void End();

    /// <summary>
    /// ステート中処理
    /// </summary>
    /// <returns>次のステート</returns>
    public abstract StateBase Execute();
}
