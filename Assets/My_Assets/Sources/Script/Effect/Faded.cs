using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Faded : MonoBehaviour
{
    public static GameObject Screen_Obj;
    public static Image screen;

    // Start is called before the first frame update
    void Start()
    {
        Screen_Obj = GameObject.Find("Black_screen");
        screen = Screen_Obj.GetComponent<Image>();
        Screen_Obj.gameObject.SetActive(false);
        
    }

    static public IEnumerator Desolving()
    {
        
        //모든 움직임 정지 해제
        Movement_Controll.Move_Stop();
        Screen_Obj.gameObject.SetActive(true);

        float fade = 0;
        while (fade < 1) //fade in
        {
            fade += 0.01f;
            yield return new WaitForSeconds(0.01f);
            screen.color = new Color(0, 0, 0, fade);
        }
        yield return new WaitForSeconds(0.05f);
        while (fade > 0) //fade in
        {
            fade -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            screen.color = new Color(0, 0, 0, fade);
        }

        Screen_Obj.gameObject.SetActive(false);
        //모든 움직임 정지 해제
        Movement_Controll.Move_Start();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
