using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene4Manager : MonoBehaviour
{
    public static GameScene4Manager ins;
    [SerializeField] ShadeBg endShade;
    [SerializeField] ShadeBg startShade;
    [SerializeField] AudioClip BGM_Gameplay;
    private void Start()
    {
        ins = this;
        startShade.gameObject.SetActive(true);
        AudioManager.Instance.PlayMusicGamePlay(BGM_Gameplay);
    }

    public void EndScene()
    {
        StartCoroutine(StartToNextScene());
    }

    IEnumerator StartToNextScene()
    {
        yield return new WaitForSeconds(1f);
        endShade.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        LoadNextScene();
    }
    private void LoadNextScene()
    {
        AudioManager.Instance.StopSound();
        string curMinigame = PlayerPrefs.GetString("curMinigame");
        int curScene = PlayerPrefs.GetInt("curScene") + 1;
        PlayerPrefs.SetInt("curScene", curScene);
        ScenesManager.ins.LoadScene(curMinigame + "." + curScene.ToString());
    }
}
