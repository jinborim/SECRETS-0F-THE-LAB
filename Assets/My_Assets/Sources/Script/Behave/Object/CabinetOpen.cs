using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CabinetOpen : MonoBehaviour, IPointerClickHandler
{
    /**
     * 캐비닛 문 상호작용을 관리하는 클래스
     * IPointerClickHandler 인터페이스를 상속받아 클릭 이벤트 처리
     **/

    public GameObject CurrentDoor; // 회전시킬 문 오브젝트
    public float moveSpeed = 3; 
    public bool is_activated = false; //문이 닫힌 상태
    public bool is_locked;  // 잠금 상태 여부

    public Material[] mat=new Material[2]; //상태에 따른 머티리얼 변경

    string[] message =new string[1];        // 잠겨있을시 출력할 메세지

    // 다른 시스템과 연동을 위한 매니저 클래스
    public Inventory_Checking invenCheck;   //  인벤토리 아이템 체크용
    public Effect_AudioClip_Manager EAM;    // 사운드 효과 재생 관리

    [SerializeField]
    KEY lockKey;    // 이 문을 여는 데 필요한 정보
    

    // Start is called before the first frame update
    void Start()
    {
        CurrentDoor = this.transform.gameObject;
        invenCheck = GameObject.FindObjectOfType<Inventory_Checking>();
        EAM = GameObject.FindObjectOfType<Effect_AudioClip_Manager>();
        message = new string[] { "잠겨있다.", "키패드에 번호를 입력해야 할 거 같다." };
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // 우클릭인 경우에만 상호작용 진행
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            // 클릭 지점에서 Ray를 쏘아 타겟 확인
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform.name == "door")
            {
                // 잠겨 있지 않은 경우
                if (is_locked != true)
                {
                    // 문이 닫혀 있으면 열기
                    if (is_activated == false)
                    {
                        hit.transform.gameObject.GetComponent<CabinetOpen>().Open_Door();

                        is_activated = true;
                    }

                    // 문이 열려 있으면 닫기
                    else if (is_activated == true)
                    {
                        hit.transform.gameObject.GetComponent<CabinetOpen>().Close_Door();

                        is_activated = false;
                    }
                }

                // 문이 잠겨 있는 경우
                else if (is_locked == true)
                {

                    EAM.Effect_Sound("CabinetLocked");  // 잠금 효과음 재생
                    // 화면에 타이핑 효과로 잠겨있다는 텍스트 출력
                    StartCoroutine(Text_Effect.Typing(GameObject.FindObjectOfType<WOB_Alarm>().textbox, message, "N"));
                }
            }
        }
    }
    // 문의 회전값 및 사운드
    public void Open_Door()
    {
        EAM.Effect_Sound("CabinetOpen");
        CurrentDoor.transform.rotation = Quaternion.Euler(0, -75, 0); 
        
    }
    public void Close_Door()
    {
        EAM.Effect_Sound("CabinetClose");
        CurrentDoor.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void Unlock_Door()
    {
        EAM.Effect_Sound("Unlock");
        StartCoroutine(Text_Effect.Typing(GameObject.FindObjectOfType<WOB_Alarm>().textbox, new string[] { "문이 열렸다." }, "N"));
        is_locked = false;
    }
}
