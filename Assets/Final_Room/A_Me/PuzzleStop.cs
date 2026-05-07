using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleStop : MonoBehaviour
{
    
    public GameObject Target;
    public static GameObject Ui;
    public GameObject Char;

    // public static PuzzlePiece pp;


    // Start is called before the first frame update
    void Start()
    {
      

        //StageManager = GameObject.Find("stagenum");
        //nowStage = StageManager.GetComponent<SceneChange>().stageNum;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void PuzzleOn()
    {
        /* if (pp.puzzle_on = true)
        {
            Target.SetActive(false);
            Ui.SetActive(false);
            //Char.SetActive(false); 캐릭터 무력화는 나중에
        } */
    }
}
