using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// modular set of instructions to make any invader move the same way
public class invaderScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Move");
    }

    // Update is called once per frame
    void Update()
    {

        // just translating forward at constant speed
        transform.Translate(Vector3.forward * 100f * Time.deltaTime);

    }

    IEnumerator Move()
    {
        while (true)
        {
            // move forward for 3.5s and changes direction 180degrees then repeat
            yield return new WaitForSeconds(3.5f);
            transform.eulerAngles += new Vector3(0, 90f, 0);

        }
    }
}
