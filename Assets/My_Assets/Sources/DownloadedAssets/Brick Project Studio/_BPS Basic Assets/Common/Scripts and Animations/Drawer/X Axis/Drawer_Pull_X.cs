using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SojaExiles

{

	public class Drawer_Pull_X : MonoBehaviour, IPointerClickHandler
    {
        
		public Animator pull_01;
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
            
        }

		/* void OnMouseOver()
		{
			

		} */

		IEnumerator opening()
		{
			print("you are opening the door");
			pull_01.Play("openpull_01");
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator closing()
		{
			print("you are closing the door");
			pull_01.Play("closepush_01");
			open = false;
			yield return new WaitForSeconds(.5f);
		}


	}
}