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
    

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform.name == "KeypadGate")
            {
                //Debug.Log("키패드만져는짐");
                /* if (this.is_accessable != true)
                {
                    //Debug.Log("클릭됨");
                    EAM.Effect_Sound("AccessDeny");
                    StartCoroutine(ColorChanger(Color.red));
                }
                else if (this.is_accessable == true)
                {
                    EAM.Effect_Sound("Access");
                    StartCoroutine(ColorChanger(Color.green));
                } */

                if (Inventory_Checking.InventoryChecking(key.Key) == true)
                {
                    Debug.Log("카드키 사용");
                    EAM.Effect_Sound("USBinsertion");
                    StartCoroutine(Text_Effect.Typing(GameObject.FindObjectOfType<WOB_Alarm>().textbox, new string[] { "문이 열렸다." }, "N"));

                    //anim.Play("Open_G");
                    Open_G();



                }
                else if (Inventory_Checking.InventoryChecking(key.Key) != true)
                {
                    StartCoroutine(Text_Effect.Typing(GameObject.FindObjectOfType<WOB_Alarm>().textbox, new string[] { "카드키가 필요할 것 같다" }, "N"));
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
