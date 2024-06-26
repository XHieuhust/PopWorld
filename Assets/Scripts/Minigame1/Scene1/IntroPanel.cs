using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spine.Unity;

public class IntroPanel : MonoBehaviour
{
    [SerializeField] public Button btnBoDam;
    [SerializeField] SkeletonGraphic wolfooNam;
    [SerializeField] SkeletonGraphic wolfooNu;
    [SerializeField] Image screen;
    [SerializeField] Image bg;
    [SerializeField] Image bodamBone;
    [SerializeField] AudioClip SFX_ClickPhone;

    private void Start()
    {
        btnBoDam.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        StartCoroutine(StartOnClick());
    }

    IEnumerator StartOnClick()
    {
        AudioManager.Instance.StopAudioEffect();
        AudioManager.Instance.PlaySoundEffect(SFX_ClickPhone);
        Destroy(btnBoDam.gameObject);

        wolfooNam.AnimationState.SetAnimation(0, "Sit_Phone", true);
        bodamBone.gameObject.SetActive(true);
        wolfooNu.AnimationState.SetAnimation(0, "Sit_Typing2", true);
        yield return new WaitForSeconds(2f);
        IntroPanel_Complete();
    }


    private void IntroPanel_Complete()
    {
        StartCoroutine(MoveDownCamera(this.gameObject));
        StartCoroutine(MoveDownCamera(wolfooNam.gameObject));
        StartCoroutine(MoveDownCamera(wolfooNu.gameObject));
        StartCoroutine(MoveCenterCamera(screen.gameObject));
    }

    IEnumerator MoveDownCamera(GameObject ob)
    {
        float elapsedTime = 0;
        float seconds = 1;
        Vector3 startingPos = ob.GetComponent<RectTransform>().position;
        Vector3 newPos = startingPos - new Vector3(0, 10, 0);
        while (elapsedTime < seconds)
        {
            ob.GetComponent<RectTransform>().position = Vector3.Lerp(startingPos, newPos, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        ob.GetComponent<RectTransform>().position = newPos;
    }

    IEnumerator MoveCenterCamera(GameObject ob)
    {

        RectTransform rect = ob.GetComponent<RectTransform>();
        float elapsedTime = 0;
        float seconds = 1;
        Vector3 startingPos = rect.position;
        Vector3 newPos = Vector3.zero;
        Vector3 startScale = rect.localScale;
        float curDist;
        float maxDist = Vector2.Distance(startingPos, newPos);
        float maxScale = 1.5f * startScale.x;
        float newScale;
        while (elapsedTime < seconds)
        {
            curDist = Vector2.Distance(rect.position, newPos);
            newScale = (1 - curDist / maxDist) * (maxScale - startScale.x);
            rect.localScale = startScale + new Vector3(newScale, newScale, newScale);
            rect.position = Vector3.Lerp(startingPos, newPos, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        rect.position = newPos;
        ob.GetComponent<Screen_SceneCall>().TurnOnTheLight();
    }

}
