using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
     private Fire fire;  
     float offset = 0.0f; private Vector3 difference;
    void Start()
    {

    }

    void FixedUpdate()
    {

         Vector3 difference = Camera.main.ScreenToWorldPoint((Input.mousePosition) - transform.position);
        difference.Normalize();
        
        float rotation_z = Mathf.Atan2(difference.y,  difference.y) * Mathf.Rad2Deg;
        float angleLookAt = (180/ Mathf.PI) * rotation_z;
        transform.rotation = Quaternion.Euler (0f, 0f, angleLookAt );
        

        
    }

    


}
