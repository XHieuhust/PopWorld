using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstantiateMapScene3 : MonoBehaviour
{
    [SerializeField] List<Image> ListMap;
    [SerializeField] AudioClip bgm_suspect;
    private int numOfMap;
    void Start()
    {
        numOfMap = ListMap.Count;
        LoadMap();
        AudioManager.Instance.PlayMusicGamePlay(bgm_suspect);
    }

    public void LoadMap()
    {
        string curMinigame = PlayerPrefs.GetString("curMinigame");
        int curLevel = LevelManager.ins.GetLevel(curMinigame);
        Image mapCur = Instantiate(ListMap[curLevel % numOfMap], transform.position, Quaternion.identity);
        mapCur.transform.SetParent(transform, false);
    }
}
