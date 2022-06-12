using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 startTouchPosition;
    private Vector2 currentPosition;
    private Vector2 endTouchPosition;
    private bool stopTouch = false;
    private bool isGrounded = false;
    
    public float swipeRange;
    public float tapRange;
    public float playerSpeed;
    void Update()
    {
        Swipe();
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Road")
            isGrounded = true;
    }

    private void OnCollisionExit(Collision other) {
        if(other.gameObject.tag == "Road")
            isGrounded = false;
    }

    public void Swipe()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            currentPosition = Input.GetTouch(0).position;
            Vector2 Distance = currentPosition - startTouchPosition;

            if (!stopTouch)
            {

                if (Distance.x < -swipeRange)
                {
                    gameObject.transform.position = new Vector3(transform.position.x - 0.25f, transform.position.y, transform.position.z);
                    stopTouch = true;
                }
                else if (Distance.x > swipeRange)
                {
                    gameObject.transform.position = new Vector3(transform.position.x + 0.25f, transform.position.y, transform.position.z);
                    stopTouch = true;
                }
                else if (Distance.y > swipeRange)
                {
                    if(isGrounded)
                    {
                        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 222f);
                    }
                    stopTouch = true;
                }
                // else if (Distance.y < -swipeRange)
                // {
                //     outputText.text = "Down";
                //     stopTouch = true;
                // }

            }

        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            stopTouch = false;

            endTouchPosition = Input.GetTouch(0).position;

            Vector2 Distance = endTouchPosition - startTouchPosition;

            if (Mathf.Abs(Distance.x) < tapRange && Mathf.Abs(Distance.y) < tapRange)
            {
                // outputText.text = "Tap";
            }

        }

        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * Time.deltaTime * playerSpeed);
        // gameObject.transform.Translate(Vector3.forward * Time.deltaTime * 3f, Space.World);
    }
}
