using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace state
{
    /// <summary>
    /// ステート処理2
    /// </summary>
    public class State2 : StateBase
    {
        float seconds;

        /// <summary>
        /// ステート開始処理
        /// </summary>
        public override void Begin()
        {
            seconds = 0.0f;
            Debug.Log("State2 Begin");
        }

        /// <summary>
        /// ステート終了処理
        /// </summary>
        public override void End()
        {
            Debug.Log("State2 End");
        }

        /// <summary>
        /// ステート中処理
        /// </summary>
        /// <returns>次のステート</returns>
        public override StateBase Execute()
        {
            seconds += Time.deltaTime;
            if (seconds >= 2)
            {
                seconds = 0;
                Debug.Log("2秒経過したのでステート変更");
                UnityEngine.SceneManagement.SceneManager.LoadScene("Scene3");
                return StateFactory.Instance.GetState(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
            }

            //   Debug.Log("State2");
            return this;
        }
    }
}
