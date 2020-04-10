using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageWindow : MonoBehaviour
{
    public GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayAnimator(bool value)
    {
        if (obj == null)
        {
            return;
        }

        Animator anim = obj.GetComponent<Animator>();
        anim.SetBool("Play", value);
    }
}
