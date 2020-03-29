using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
public class PlayerMovement_2D : MonoBehaviour
{
    public float speed, tilt;
    private float moveHorizontal, moveVertical, deltaX, deltaZ;
    public Boundary boundary;
    bool controlIsActivated = true;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Boundary();
    }
    public void Movement()
    {
        if (controlIsActivated) {
            //moveHorizontal = Input.GetAxis("Horizontal");
            //moveVertical = Input.GetAxis("Vertical");
            //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            //rb.velocity = movement * speed;
#if UNITY_STANDALONE || UNITY_EDITOR
            if (Input.GetMouseButton(0))
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePos.y = transform.position.y;
                rb.position = Vector3.MoveTowards(transform.position, mousePos, speed * Time.deltaTime);
            }
#endif

#if UNITY_IOS || UNITY_ANDROID
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        deltaX = touchPos.x - transform.position.x;
                        deltaZ = touchPos.z - transform.position.z;
                        break;
                    case TouchPhase.Moved:
                        rb.MovePosition(new Vector3(touchPos.x - deltaX, 0.0f, touchPos.z - deltaZ));
                        break;
                    case TouchPhase.Ended:
                        rb.velocity = Vector3.zero;
                        break;
                }
            }
#endif
            rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
        }
    }
    void Boundary()
    {
        rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );
    }
}
