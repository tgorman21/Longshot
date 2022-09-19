using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public Variables flingSpeed;
    public Rigidbody2D rb;
    Vector2 mouseUpPos;
    // Start is called before the first frame update
    void Start()
    {
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseUp()
    {
        // get mouse position in world coordinates
        mouseUpPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // difference vector
        Vector2 diff = (Vector2)transform.position - mouseUpPos;
        rb.isKinematic = false;
        // add that force with speed
        rb.AddForce(diff * flingSpeed.flingSpeed);
    }
}
