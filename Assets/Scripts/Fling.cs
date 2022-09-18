using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Allows the user to click on the square, drag, and release to fling
public class Fling : MonoBehaviour
{
    public float flingSpeed = 400f;
    private float boostPower;
    Rigidbody2D rb;
    Vector2 mouseDownPos;
    Vector2 mouseUpPos; 

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        boostPower = Random.Range(100, 400);
    }

    void OnMouseUp() {
        // get mouse position in world coordinates
        mouseUpPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // difference vector
        Vector2 diff = (Vector2)transform.position - mouseUpPos;

        // add that force with speed
        rb.AddForce(diff * flingSpeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Boost"))
        {
            rb.AddForce((Vector2)transform.position * boostPower);
            Debug.Log("Collided");
        }
    }
 
}
