using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    [SerializeField]
    private GameObject simpleAnimation;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            simpleAnimation.GetComponent<SimpleAnimation>().Play("Default");
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            simpleAnimation.GetComponent<SimpleAnimation>().Play("Default (1)");
        }
    }
}
