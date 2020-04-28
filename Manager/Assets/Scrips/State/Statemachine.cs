using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace state
{
    /// <summary>
    /// ステートマシンクラス
    /// </summary>
    public class Statemachine
    {
        /// <summary>
        /// 前のステート
        /// </summary>
        StateBase prevState;

        /// <summary>
        /// 現在のステート
        /// </summary>
        StateBase currentState;

        /// <summary>
        /// 次のステート
        /// </summary>
        StateBase nextState;


        /// <summary>
        /// ステート開始処理
        /// </summary>
        public void Begin()
        {
            currentState.Begin();
        }

        /// <summary>
        /// ステート終了処理
        /// </summary>
        public void End()
        {
            currentState.End();
        }

        /// <summary>
        /// ステート中処理
        /// </summary>
        /// <returns>次のステート</returns>
        public void Execute()
        {
            if (currentState == null)
            {
                return;
            }

            if (prevState != currentState)
            {
                this.Begin();
                prevState = currentState;
            }

            nextState = currentState.Execute();

            if (nextState != currentState)
            {
                this.End();
            }

            currentState = nextState;
        }

        /// <summary>
        /// 開始ステートを設定
        /// </summary>
        /// <param name="key"></param>
        /// <returns>false : 失敗</returns>
        public bool SetRootState(string key)
        {
            currentState = StateFactory.Instance.GetState(key);
            return (currentState != null);
        }
    }
}