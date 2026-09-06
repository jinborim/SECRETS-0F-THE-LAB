using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Door3 : MonoBehaviour
{
    public GameObject DOOR;
    public bool is_locked=true;

    public Effect_AudioClip_Manager EAM;

    public void OnPointerClick(PointerEventData eventData)
    {

        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform.name == "Locked_Door")
            {
                if (is_locked == true)
                {
                    EAM.Effect_Sound("LockedDoor");
                    StartCoroutine(Text_Effect.Typing(GameObject.FindObjectOfType<WOB_Alarm>().textbox, new string[] { "자네 여긴 어떻게 들어온거지 빨리 이곳에서 탈출해!  ", "여긴 지금 괴물의 탈을 쓴 사람이 있어" , "여긴 아무것도 없으니 그대로 나가도 된다네"," 난 탈출하기는 글렀어..","그리고 명심해 뒤에서 괴물이 쫓아와도 멈추지말게"}, "N"));
                }
                else if (is_locked == false)
                {
                    EAM.Effect_Sound("Unlock");
                    StartCoroutine(Text_Effect.Typing(GameObject.FindObjectOfType<WOB_Alarm>().textbox, new string[] { "문이 열렸다." },"N"));
                    
                }
            }
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        EAM = GameObject.FindObjectOfType<Effect_AudioClip_Manager>();
    }

    public void Open_Door()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
