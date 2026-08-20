using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CaseOpenclose : MonoBehaviour, IPointerClickHandler
{
    public GameObject CurrentCase;


    public float moveSpeed = 3;

    public bool is_activated = false;
    public bool is_locked;

    public Material[] mat = new Material[2];

    string[] message = new string[1];


    public Inventory_Checking invenCheck;
    public Effect_AudioClip_Manager EAM;

    // Start is called before the first frame update
    void Start()
    {
        CurrentCase = this.transform.gameObject;
        invenCheck = GameObject.FindObjectOfType<Inventory_Checking>();
        EAM = GameObject.FindObjectOfType<Effect_AudioClip_Manager>();
        message = new string[] { "평범한 서랍이다. 몇 개는 열리지 않는다." };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
             //Debug.Log("포인터 테스트");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform.name == "SheetRackCase")
            {
                
                   //Debug.Log("터치된 오브젝트: " + hit.transform.name);

                if (is_activated == false)
                {
                    //this.gameObject.GetComponent<MeshRenderer>().material = mat[0];
                    //StartCoroutine(Open_Door());
                    hit.transform.gameObject.GetComponent<CaseOpenclose>().Open_Case();
                    EAM.Effect_Sound("CabinetOpen");
                    is_activated = true;
                }

                else if (is_activated == true)
                {
                    //this.gameObject.GetComponent<MeshRenderer>().material = mat[1];
                    //StartCoroutine(Close_Door());
                    hit.transform.gameObject.GetComponent<CaseOpenclose>().Close_Case();
                    EAM.Effect_Sound("CabinetClose");
                    is_activated = false;
                }

                /* if (is_activated == false)
                {
                    //this.gameObject.GetComponent<MeshRenderer>().material = mat[0];
                    //StartCoroutine(Open_Door());
                    hit.transform.gameObject.GetComponent<CabinetOpen_Y>().Open_Door();
                    EAM.Effect_Sound("CabinetOpen");
                    is_activated = true;
                }

                else if (is_activated == true)
                {
                    //this.gameObject.GetComponent<MeshRenderer>().material = mat[1];
                    //StartCoroutine(Close_Door());
                    hit.transform.gameObject.GetComponent<CabinetOpen_Y>().Close_Door();
                    EAM.Effect_Sound("CabinetClose");
                    is_activated = false;
                } */
            }
               

            }

        }
    
    public void Open_Case()
    {
        //Debug.Log("열림");
        StartCoroutine(move_1());
        
        //CurrentCase.transform.localPosition = new Vector3(0, 0, -1);
        //CurrentCase.transform.rotation = Quaternion.Euler(0, -75, 0);
    }

    public void Close_Case()
    {
        //Debug.Log("닫힘");
        StartCoroutine(move_2());
        //CurrentCase.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public IEnumerator move_1()
    {
        do
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, -78), 0.1f);
            yield return new WaitForSeconds(0.01f);
        } while (transform.position != new Vector3(transform.position.x, transform.position.y, -78));
        
        transform.position = new Vector3(transform.position.x, transform.position.y, -78);
    }

    public IEnumerator move_2()
    {
        do
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, -74), 0.1f);
            yield return new WaitForSeconds(0.01f);
        } while (transform.position != new Vector3(transform.position.x, transform.position.y, -74));

        transform.position = new Vector3(transform.position.x, transform.position.y, -74);
    }


}
