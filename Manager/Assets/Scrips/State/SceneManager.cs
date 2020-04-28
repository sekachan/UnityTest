using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace state
{
    /// <summary>
    /// シーン管理クラス
    /// 時間経過でシーン１～３を切り替える（どのシーンから起動しても同じ）
    /// </summary>
    public class SceneManager : SingletonMonoBehaviour<SceneManager>
    {
        Statemachine statemachine = new Statemachine();

        void Start()
        {
            if (this != Instance)
            {
                Destroy(this);
                return;
            }

            DontDestroyOnLoad(this.gameObject);

            // シーンステート登録
            StateFactory.Instance.Create<State1>("Scene1");
            StateFactory.Instance.Create<State2>("Scene2");
            StateFactory.Instance.Create<State3>("Scene3");

            // 開始ステート設定
            statemachine.SetRootState(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }

        // Update is called once per frame
        void Update()
        {
            // ステート更新
            statemachine.Execute();
        }
    }
}
