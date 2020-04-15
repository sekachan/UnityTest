using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// プレイヤーキャラクター
/// </summary>
public class PlayerChar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StatusData data = ScriptableObject.CreateInstance<StatusData>();

        this.gameObject.transform.GetComponentInChildren<Text>().text = data.PlayerHP.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
