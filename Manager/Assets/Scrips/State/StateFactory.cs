using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace state
{
    /// <summary>
    /// ステート作成クラス
    /// </summary>
    public class StateFactory : Singleton<StateFactory>
    {
        /// <summary>
        /// ステートクラス管理
        /// </summary>
        private Dictionary<string, StateBase> stateDictionary = new Dictionary<string, StateBase>();

        /// <summary>
        /// ステートクラス取得
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public StateBase GetState(string key)
        {
            if (!stateDictionary.ContainsKey(key))
            {
                Debug.LogError("StateFactory GetState key : " + key);
                return null;
            }

            return stateDictionary[key];
        }

        /// <summary>
        /// ステートクラス作成
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        public void Create<T>(string key) where T : new()
        {
            T StateBase = new T();
            if (StateBase.GetType().IsSubclassOf(typeof(StateBase)))
            {
                // StateBase を継承しているクラスを登録
                stateDictionary[key] = StateBase as StateBase;
            }
            else
            {
                Debug.LogError("StateFactory Create key : " + key);
            }
        }
    }
}
