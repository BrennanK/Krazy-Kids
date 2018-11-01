using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    float offset = 0.0f; private Vector3 difference; private Vector3 mousePos;
    void Start()
    {

    }

    void FixedUpdate()
    {

        //Vector3 difference = Camera.main.ScreenToWorldPoint((Input.mousePosition) - transform.position);
        //difference.Normalize();

        //float rotation_z = Mathf.Atan2(difference.y, difference.y) * Mathf.Rad2Deg;
        //float angleLookAt = (90 / Mathf.PI) * rotation_z;
        //transform.localRotation = Quaternion.Euler(0f, 0f, angleLookAt);
        MouseL();


    }
    void MouseL()
    {
        //Gets mouse position on screen.
        mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        //converts mouse position from screen to world point.

        Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);

        lookPos = (lookPos - transform.position).normalized; //since mouse vector and obj vector are now in same world space, this normalizes the vector.

        float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg; // gets the angle between mouse and the object

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); // rotates the object towards mouse pointer on z-axis.





    }
}

