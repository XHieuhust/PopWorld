using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScene3Manager : MonoBehaviour
{
    public static GameScene3Manager ins;
    [SerializeField] ProgressBarScene13 barProgress;
    [SerializeField] List<GameObject> ListTurns;
    [SerializeField] AudioClip SFX_CompleteTurn;

    public int cntCompleteTurn;
    int maxTurn;
    private void Start()
    {
        ins = this;
        maxTurn = ListTurns.Count;
        ListTurns[0].SetActive(true);
    }

    public void UpdateBar(float seconds)
    {
       barProgress.UpdateBar(1f * (cntCompleteTurn+1) / maxTurn, seconds);
    }

    public void UpdateTurn()
    {
        ListTurns[cntCompleteTurn].SetActive(false);
        cntCompleteTurn++;
        AudioManager.Instance.PlaySoundEffect(SFX_CompleteTurn);
        if (cntCompleteTurn == maxTurn)
        {
            StartCoroutine(EndScene());
        }
        else
        {
            ListTurns[cntCompleteTurn].SetActive(true);
        }
    }

    IEnumerator EndScene()
    {
        barProgress.MoveLeft();
        yield return new WaitForSeconds(0.5f);
        LoadNextScene();
    }
    private void LoadNextScene()
    {
        string curMinigame = PlayerPrefs.GetString("curMinigame");
        int curScene = PlayerPrefs.GetInt("curScene") + 1;
        PlayerPrefs.SetInt("curScene", curScene);
        ScenesManager.ins.LoadScene(curMinigame + "." + curScene.ToString());
    }
}
