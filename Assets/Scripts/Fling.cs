using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

// Allows the user to click on the square, drag, and release to fling
public class Fling : MonoBehaviour
{
    public Variables flingSpeed;
    public Variables boostPower;
    public Variables distance_count;
    public Variables best_distance;
    public Variables playerLanded;
    public Variables distanceTravelled;
    public Transform cannon;
    private int clickCount = 3;
    Rigidbody2D rb;
    Vector2 mouseDownPos;
    Vector2 mouseUpPos;
    float currentDistance;
    Vector2 initialPos;
    void Start() {
        playerLanded.playerLanded = false;
        distanceTravelled.distanceTravelled = 0;
        rb = GetComponent<Rigidbody2D>();
        distance_count.distance_count = 0;
        initialPos = transform.position;
    }
    private void Update()
    {
        distanceTravelled.distanceTravelled = Mathf.Round(Vector2.Distance(this.transform.position, initialPos));
        if (rb.velocity.magnitude == 0 && this.transform.position.x > 0)
        {
            playerLanded.playerLanded = true;
            StartCoroutine(PlayerReset());
        }
    }

    private void OnMouseOver()
    {
        if( Input.GetMouseButtonDown(0) && this.transform.position.x > 0 && !playerLanded && clickCount > 0)
        {
            boostPower.boostPower = Random.Range(1, 25);
            rb.velocity = ((Vector2)((transform.right * boostPower.boostPower) + (transform.up * Random.Range(1, 30))));
            boostPower.boostPower = 0;
            clickCount = clickCount - 1;
            Debug.Log(clickCount);
        }
        else if(clickCount <= 0)
        {
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Boost"))
        {
            boostPower.boostPower = Random.Range(1, 50);
            rb.velocity = ((Vector2)((transform.right * boostPower.boostPower) + (transform.up * Random.Range(1, 50))));
            Debug.Log(boostPower.boostPower);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        boostPower.boostPower = 0;
    }
IEnumerator PlayerReset()
    {
        while (playerLanded.playerLanded)
        {
            Debug.Log("Player Landed");
            if(best_distance.best_distance < distance_count.distance_count)
            {
                best_distance.best_distance = distance_count.distance_count;
            }
            yield return new WaitForSeconds(3);
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene("Longshot");
        }
        
    }
}
