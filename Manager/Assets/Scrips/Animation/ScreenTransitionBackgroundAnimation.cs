using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenTransitionBackgroundAnimation : MonoBehaviour
{
    public void FadeInBegin()
    {
        Debug.Log("Animation Play");
    }

    public void FadeInEnd()
    {
        Debug.Log("Animation End");
        this.gameObject.SetActive(false);
    }
}
