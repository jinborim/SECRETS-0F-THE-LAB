using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CinematicTrigger : MonoBehaviour
{
    /**
     *  씬으로 넘어오자마자 NPC 애니메이션과 TTS 음성을 출력
     **/

    public Animator npcAnimator;
    public string animationTriggerName = "Talk"; // 믹사모 애니메이션 파라미터 이름

    public AudioSource ttsSource;
    public AudioClip ttsClip;

    [Header("VR Subtitle")]
    public Canvas subtitleCanvas;
    public GameObject subtitlePanel;
    public Text subtitleText;
    [TextArea(2, 5)]
    public string subtitleMessage = "연구원\n자네는.. 어떻게 여기로 온거지..?";

    [SerializeField] private Vector3 subtitleLocalPosition = new Vector3(0f, -0.25f, 1.5f);
    [SerializeField] private Vector3 subtitleLocalScale = new Vector3(0.0015f, 0.0015f, 0.0015f);

    void Start()
    {
        // 씬으로 넘어오자마자 1초 뒤에 시네마틱 시작
        StartCoroutine(PlayCinematic(1.0f));
    }

    IEnumerator PlayCinematic(float delay)
    {
        // 지정된 시간 대기
        yield return new WaitForSeconds(delay);

        // 애니메이션이랑 TTS 음성 동시에 실행
        // 믹사모 애니메이션실행
        if (npcAnimator != null)
        {
            npcAnimator.SetTrigger(animationTriggerName);
            Debug.Log("믹사모 애니메이션 실행");
        }

        SetupVrSubtitle();

        if (subtitleText != null)
        {
            subtitleText.text = subtitleMessage;
        }

        if (subtitlePanel != null)
        {
            subtitlePanel.SetActive(true);
        }

        // TTS 음성 재생
        if (ttsSource != null && ttsClip != null)
        {
            ttsSource.clip = ttsClip;
            ttsSource.Play();
            Debug.Log("TTS 재생");

            yield return new WaitForSeconds(ttsClip.length);
        }

        if (subtitlePanel != null)
        {
            subtitlePanel.SetActive(false);
        }
    }

    private void SetupVrSubtitle()
    {
        if (subtitleCanvas == null)
        {
            return;
        }

        Camera vrCamera = Camera.main;
        if (vrCamera == null)
        {
            vrCamera = FindObjectOfType<Camera>();
        }

        if (vrCamera == null)
        {
            Debug.LogWarning("VR 자막을 배치할 카메라를 찾지 못했습니다.");
            return;
        }

        RectTransform canvasTransform = subtitleCanvas.transform as RectTransform;
        subtitleCanvas.renderMode = RenderMode.WorldSpace;
        subtitleCanvas.worldCamera = vrCamera;
        canvasTransform.SetParent(vrCamera.transform, false);
        canvasTransform.localPosition = subtitleLocalPosition;
        canvasTransform.localRotation = Quaternion.identity;
        canvasTransform.localScale = subtitleLocalScale;
        canvasTransform.sizeDelta = new Vector2(1000f, 220f);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
