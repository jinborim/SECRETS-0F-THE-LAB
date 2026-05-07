using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get_Item : MonoBehaviour
{
    /**
     *  아이템을 감지하고 시스템을 전달
     **/

    [SerializeField]
    private Inventory theInventory; //아이템을 저장할 인벤토리 시스템 창조

   
    void Update()
    {
        // 마우스 우클릭 감지
        if (Input.GetMouseButtonDown(1))
        {
            //  화면 클릭 지점으로부터 Ray 발사
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Raycastrk "item"태그를 가진 오브젝트에 충돌했는지 확인
            if (Physics.Raycast(ray, out hit) && hit.transform.CompareTag("Item"))
            {
                
                // 아이템을 슬롯으로 보내는 작업
                if (hit.transform.GetComponent<ItemPickup>().item != null)
                {
                    // 아이템 타입이 Read인 경우
                    if (hit.transform.GetComponent<ItemPickup>().item.itemType == Item.ItemType.Read)
                    {
                        // 텍스트 데이터 추출 및 인벤토리의 텍스트 표시 시스템 호출
                        theInventory.Temp_Readable_Text(hit.transform.GetComponent<Readable>().Read_Text);
                    }

                    // 인벤토리에 아이템 획득 처리 수행
                    theInventory.AcquireItem(hit.transform.GetComponent<ItemPickup>().item);
                    
                    // 아이템 획드시 게임에서 아이템 오브젝트 제거
                    Destroy(hit.transform.gameObject);
                }
                else
                {
                    Debug.Log("아이템");
                }


            }
        }
    }
}
