using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, 1), 0.1f);
        StartCoroutine(move());
    }

    public IEnumerator move()
    {
        do
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, 3), 0.1f);
            yield return new WaitForSeconds(0.01f);
        } while (transform.position != new Vector3(transform.position.x, transform.position.y, 3));
        transform.position = new Vector3(transform.position.x, transform.position.y, 3);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
