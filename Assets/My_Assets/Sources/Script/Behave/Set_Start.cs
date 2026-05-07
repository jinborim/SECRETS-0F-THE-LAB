using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_Start : MonoBehaviour
{
    public float Xpoint;
    public float Ypoint;
    public float Zpoint;

    

    public GameObject character;
    public Vector3 start_transform;

    // Start is called before the first frame update
    void Start()
    {
        

        start_transform = new Vector3(Xpoint, Ypoint, Zpoint);
        if (character == null)
        {
            character = GameObject.Find("head");
        }
        character.transform.position = start_transform;
        
        // ÂÑ±æ¶§¸¸ Àá±ñ ¼Óµµ ¹Ù²ãÁÖ´Â ¿ëµµ

        //character.GetComponent<CharacterMovement>().moveSpeed = 50f;
        //character.GetComponent<CharacterMovement>().jumpSpeed = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
