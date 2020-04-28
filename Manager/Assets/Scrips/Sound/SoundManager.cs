using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// サウンド管理クラス
/// </summary>
public class SoundManager : SingletonMonoBehaviour<SoundManager>
{
    [SerializeField]
    private AudioMixer audioMixer;

    // Start is called before the first frame update
    void Start()
    {
        if (this != Instance)
        {
            Destroy(this);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 全体音量設定
    /// </summary>
    /// <param name="volume"></param>
    public void SetMaster(float volume)
    {
        audioMixer.SetFloat("Master", volume);
    }

    /// <summary>
    /// BGM音量設定
    /// </summary>
    /// <param name="volume"></param>
    public void SetBGM(float volume)
    {
        audioMixer.SetFloat("BGM", volume);
    }

    /// <summary>
    /// 効果音音量設定
    /// </summary>
    /// <param name="volume"></param>
    public void SetSE(float volume)
    {
        audioMixer.SetFloat("SE", volume);
    }

    /// <summary>
    /// ボイス音量設定
    /// </summary>
    /// <param name="volume"></param>
    public void SetVOICE(float volume)
    {
        audioMixer.SetFloat("VOICE", volume);
    }
}
