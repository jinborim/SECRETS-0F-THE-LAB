using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicTrigger : MonoBehaviour
{
    public Animator npcAnimator;
    public string animationTriggerName = "Talk"; // 믹사모 애니메이션 파라미터 이름

    public AudioSource ttsSource;
    public AudioClip ttsClip;

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

        // TTS 음성 재생 
        if (ttsSource != null && ttsClip != null)
        {
            ttsSource.clip = ttsClip;
            ttsSource.Play();
            Debug.Log("TTS 재생");
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
