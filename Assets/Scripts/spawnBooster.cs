using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBooster : MonoBehaviour
{
    public Variables distanceTravelled;
    Vector2 lastPosition;
    public GameObject boostObject;
    private bool spawn;
    private float yVal;
    private float xVal;
    private Vector2 newPos;

    // Start is called before the first frame update
    void Start()
    {
        spawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (distanceTravelled.distanceTravelled % 20 == 0 && distanceTravelled.distanceTravelled != 0 && spawn)
        {
            StartCoroutine(WaitToSpawn());
        }

    }
    IEnumerator WaitToSpawn()
    {
        spawn = false;
        for(int i = 0;i<2; i++)
        {
            xVal = Random.Range(transform.position.x - 10, transform.position.x + 20);
            yVal = Random.Range(transform.position.y - 30, transform.position.y + 30);
            newPos = new Vector2(xVal, yVal);
            Instantiate(boostObject, newPos, Quaternion.identity);
        }
        yield return new WaitForSeconds(0.2f);
        spawn = true;
    }
}
