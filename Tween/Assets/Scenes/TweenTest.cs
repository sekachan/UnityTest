using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TweenTest : MonoBehaviour
{
    Sequence seq;
    Tween currentPlayTween;

    // Start is called before the first frame update
    void Start()
    {
        seq = DOTween.Sequence();
#if false
        seq.Append(this.gameObject.transform.DOMove(Vector3.one, 1.0f));
        seq.Append(this.gameObject.transform.DOLocalMoveY(100.0f, 1.0f));
        seq.Join(this.gameObject.transform.DOScale(2.0f, 1.0f));
        //    this.gameObject.transform.DORotate(new Vector3(0.0f, 90.0f), 1.0f);
        //    this.gameObject.transform.DOJump(Vector3.one, 30, 10, 2.0f);
        this.gameObject.transform.DOPunchScale(new Vector3(1.5f, 1.5f), 1.0f);

        int score = 0;
        var text = GameObject.Find("Text").GetComponent<Text>();
        // 数値の変更
        DOTween.To(
            () => score,          // 何を対象にするのか
            num => { score = num; text.text = score.ToString(); },   // 値の更新
            100,                  // 最終的な値
            2.0f                  // アニメーション時間
        );
#endif
        seq.SetEase(Ease.InOutCirc);
        seq.SetLoops(2);
        seq.SetDelay(1.0f);
        currentPlayTween = this.gameObject.transform.DOMove(Vector3.one, 1.0f);
        //     seq.Append(currentPlayTween);

        currentPlayTween.OnStart(() => {
            // アニメーション開始時によばれる
            Debug.Log("Start");
        });
        currentPlayTween.OnRewind(() => {
            // アニメーション開始時によばれる
            Debug.Log("Rewind");
        });
        currentPlayTween.OnUpdate(() => {
            // 対象の値が変更される度によばれる
            Debug.Log("Play");
        });
        currentPlayTween.OnComplete(() => {
            // アニメーションが終了時によばれる
            Debug.Log("End");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickStartButton()
    {
        currentPlayTween.SetEase(Ease.InOutCirc);
        currentPlayTween.SetLoops(2);
        currentPlayTween.SetDelay(1.0f);
        currentPlayTween.Play();
    }

    public void OnClickStopButton()
    {
        currentPlayTween.Pause();
    }

    public void OnClickReStartButton()
    {
        currentPlayTween.Restart();
    }

    public void OnClickReverseButton()
    {
        currentPlayTween.PlayBackwards();
    }

    public void OnClickEndButton()
    {
        currentPlayTween.Complete();
    }

    public void OnClickKillButton()
    {
        currentPlayTween.Kill();
    }
}
