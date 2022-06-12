using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.deltaPosition.x > 50.0f)
                gameObject.transform.position = new Vector3(transform.position.x + 0.25f, transform.position.y, transform.position.z);
            if(touch.deltaPosition.x < -50.0f)
                gameObject.transform.position = new Vector3(transform.position.x - 0.25f, transform.position.y, transform.position.z);
        }

        gameObject.GetComponent<Rigidbody>().AddForce(new Vector3( 0, 0, 1), ForceMode.Acceleration);
    }
}
