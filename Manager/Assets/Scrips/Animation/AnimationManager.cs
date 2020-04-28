using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField]
    private GameObject ScreenTransitionAnimaObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickButton()
    {
        ScreenTransitionAnimaObj.SetActive(true);
        ScreenTransitionAnimaObj.GetComponent<Animator>().Play("ScreenTransitionAnimationFadeOut");
    }
}
