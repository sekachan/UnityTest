using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageTest : MonoBehaviour
{
    int index = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // アニメーションの情報取得
        AnimatorClipInfo[] clipInfo = this.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0);

        // 再生中のクリップ名
        string clipName = "名前：" + clipInfo[0].clip.name;
        Debug.Log(clipName);
    }

    public void OnClickButton()
    {
        index++;
        if (3 <= index) index = 0;

        switch (index)
        {
            case 0: this.GetComponent<Animator>().Play("ImageAnimation"); break;
            case 1: this.GetComponent<Animator>().SetBool("Image1", true); break;
            case 2: this.GetComponent<Animator>().Play("Image2Animation"); break;
        }
    }
}
