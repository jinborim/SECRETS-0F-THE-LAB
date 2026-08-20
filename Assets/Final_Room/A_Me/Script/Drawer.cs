using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



    public class Drawer : MonoBehaviour, IPointerClickHandler
    {

        public Drawer drawer;
        public bool open;



        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                /* if (Physics.Raycast(ray, out hit) && hit.transform.name == "TableS")
                {

                    StartCoroutine(Text_Effect.Typing(GameObject.FindObjectOfType<WOB_Alarm>().textbox, new string[] { "서랍을 열었다." }, "N"));


                } */

                if (Physics.Raycast(ray, out hit) && hit.transform.name == "Drawer.006")
                {

                    Debug.Log("서랍");

                    /* if (open == false)
                            {
                                
                                    StartCoroutine(opening());
                                
                            }
                            else
                            {
                                if (open == true)
                                {
                                        StartCoroutine(closing());
                                }

                            } */



                }


            }
        }

        void Start()
        {
            open = false;
            drawer = GameObject.FindObjectOfType<Drawer>();

    }

        /* void OnMouseOver()
		{
			

		} */

        IEnumerator opening()
        {
            print("you are opening the door");
            
            open = true;
            yield return new WaitForSeconds(.5f);
        }

        IEnumerator closing()
        {
            print("you are closing the door");
            
            open = false;
            yield return new WaitForSeconds(.5f);
        }


    }