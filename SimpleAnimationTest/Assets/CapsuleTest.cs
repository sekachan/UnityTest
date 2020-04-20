using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<SimpleAnimation>().Play("Default");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick()
    {
        this.GetComponent<SimpleAnimation>().Stop();
        this.GetComponent<SimpleAnimation>().CrossFade("Anima1", 0.5f);
    }
}
