using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyChar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StatusData data = ScriptableObject.CreateInstance<StatusData>();

        this.gameObject.transform.GetComponentInChildren<Text>().text = data.EnemyHP.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
