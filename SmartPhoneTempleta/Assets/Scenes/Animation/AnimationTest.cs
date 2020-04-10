using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int Begin(int a)
    {
        Debug.Log(a);
        this.transform.Find("Text").GetComponent<Text>().text = "Begin";
        return a;
    }

    public int End(int b)
    {
        Debug.Log(b);
        this.transform.Find("Text").GetComponent<Text>().text = "End";
        return b;
    }
}
