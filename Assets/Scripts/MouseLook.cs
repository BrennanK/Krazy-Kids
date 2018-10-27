using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

         Vector2 mouseOnScreen = Camera.main.ScreenToViewportPoint( Input.mousePosition );

         float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        float AngleDeg = (180 / Mathf.PI) * angle;

        transform.rotation = Quaternion.Euler(new Vector3(0f, AngleDeg, 0f)); 
        
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {

         return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg; ;
        
    } 
}
