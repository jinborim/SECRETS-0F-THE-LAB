using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Keypad_touch : MonoBehaviour, IPointerClickHandler
{
    public Inventory_Checking invenCheck;
    public Effect_AudioClip_Manager EAM;

    public KEY key;

    public Animator Left_door;
    public Animator RIght_door;
    

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform.name == "KeypadGate")
            {
               

                if (Inventory_Checking.InventoryChecking(key.Key) == true)
                {
                    Debug.Log("카드키 사용");
                    EAM.Effect_Sound("USBinsertion");
                    StartCoroutine(Text_Effect.Typing(GameObject.FindObjectOfType<WOB_Alarm>().textbox, new string[] { "문이 열렸다." }, "N"));

                    Open_G();



                }
                else if (Inventory_Checking.InventoryChecking(key.Key) != true)
                {
                    StartCoroutine(Text_Effect.Typing(GameObject.FindObjectOfType<WOB_Alarm>().textbox, new string[] { "카드키가 필요할 것 같다." }, "N"));
                }
            }

        }
    }

    public void Open_G()
    {
        
        Left_door.SetBool("isOpen", false);
        RIght_door.SetBool("isOpen", false);
    }

    void Start()
    {
        invenCheck = GameObject.FindObjectOfType<Inventory_Checking>();
        //door = GameObject.FindObjectOfType<Door>();
        EAM = GameObject.FindObjectOfType<Effect_AudioClip_Manager>();

        Left_door.SetBool("isOpen", true);
        RIght_door.SetBool("isOpen", true);
    }
}
