using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingingLight : MonoBehaviour
{
    
    public float angle_forward;
    public float angle_backward;
    public float angle_result;
    public float TimeDelay;
    

    // Start is called before the first frame update
    void Start()
    {
        //angle_forward = Random.Range(3f, 5f);
        //swing_forward = new Vector3(0, 0, 5);
        //this.transform.Rotate(swing_forward * Time.deltaTime * 5);
        StartCoroutine(Swing());

    }

    public IEnumerator Swing_forward()
    {
        Debug.Log("앞으로");
        do
        {
            angle_forward = Random.Range(6f, 7f);
            //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, angle_forward), Time.deltaTime);
            transform.Rotate(0, 0, angle_forward);
            yield return new WaitForSeconds(0.01f);

        } while (transform.rotation.z==angle_forward);

    }

    public IEnumerator Swing_backward()
    {
        Debug.Log("뒤로");
        do
        {
            angle_backward = Random.Range(-6f, -7f);
            //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, angle_backward), Time.deltaTime);
            transform.Rotate(0, 0, angle_backward);
            yield return new WaitForSeconds(0.01f);

        } while (transform.rotation.z == angle_backward);

    }

    public IEnumerator Swing_zero()
    {
        Debug.Log("원점");
        do
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime);
            yield return new WaitForSeconds(0.01f);

        } while (true);
    }

    public IEnumerator Swing()
    {
        do
        {
            StartCoroutine(Swing_forward());
            TimeDelay = Random.Range(2f, 3f);
            yield return new WaitForSeconds(TimeDelay);
            StartCoroutine(Swing_zero());
            TimeDelay = Random.Range(2f, 3f);
            yield return new WaitForSeconds(TimeDelay);
            StartCoroutine(Swing_backward());
            TimeDelay = Random.Range(2f, 3f);
            yield return new WaitForSeconds(TimeDelay);
            StartCoroutine(Swing_zero());
            TimeDelay = Random.Range(2f, 3f);
            yield return new WaitForSeconds(TimeDelay);
        } while (true);
    }


    


    // Update is called once per frame
    void Update()
    {
        
    }
}
