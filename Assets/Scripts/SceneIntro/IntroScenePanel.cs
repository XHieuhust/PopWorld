using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IntroScenePanel : MonoBehaviour
{
    [SerializeField] Button playButton;
    [SerializeField] AudioClip bgm_home;
    private void Awake()
    {
        playButton.onClick.AddListener(delegate
        {
            AudioManager.Instance.PlayAudioClick();
            ScenesManager.ins.LoadScene("SceneMenu");
        });
    }
    private void Start()
    {
        AudioManager.Instance.PlayMusicGamePlay(bgm_home);
    }
}
