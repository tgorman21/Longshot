using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    private Camera myCam;
    private Vector3 screenPos;
    private float angleOffset;
    private Collider2D col;
    // Start is called before the first frame update
    void Start()
    {
        myCam = Camera.main;
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        {
            Vector3 mousePos = myCam.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetMouseButtonDown(0))
            {
                if (col == Physics2D.OverlapPoint(mousePos))
                {
                    screenPos = myCam.WorldToScreenPoint(transform.position);
                    Vector3 vec3 = Input.mousePosition - screenPos;
                    angleOffset = (Mathf.Atan2(transform.right.y, transform.right.x) - Mathf.Atan2(vec3.y, vec3.x)) * Mathf.Rad2Deg;

                }
            }
            if (Input.GetMouseButton(0))
            {
                if (col == Physics2D.OverlapPoint(mousePos))
                {
                    Vector3 vec3 = Input.mousePosition - screenPos;
                    float angle = Mathf.Atan2(vec3.y, vec3.x) * Mathf.Rad2Deg;
                    transform.eulerAngles = new Vector3(0, 0, angle + angleOffset);
                    Vector3 rot = new Vector3(0, 0, angle + angleOffset);
                    rot.z = Mathf.Clamp(rot.z, -47, 34);
                    transform.rotation = Quaternion.Euler(rot.x, rot.y, rot.z);
                }
            }
        }
    }

}
