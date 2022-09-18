using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground_0 : MonoBehaviour
{
    //	I adjusted the ParallaxBackground script to work how I wanted by separating the layers into groups, adding the Land/Sky functions, and offsetting the layers. -Tyler
    public bool Camera_Move;
    public float Camera_MoveSpeed = 1.5f;
    [Header("Layer Setting")]
    public float[] Layer_Speed = new float[7];
    public GameObject[] Layer_ObjectsLand = new GameObject[7];
    public GameObject[] Layer_ObjectsSky = new GameObject[7];

    public Transform _camera;
    public Transform player;
    private float[] startPos = new float[7];
    private float[] startPos2 = new float[7];
    private float boundSizeX;
    private float boundSizeX2;
    private float sizeX;
    public Vector3 offset;
    private GameObject Layer_0;
    void Start()
    {
        Land();
        Sky();
    }

    void Update()
    {
        //Moving camera
        if (Camera_Move)
        {
            _camera.position += Vector3.right * Time.deltaTime * Camera_MoveSpeed;
        }
        for (int i = 0; i < 4; i++)
        {
            float temp = (_camera.position.x * (1 - Layer_Speed[i]));
            float distance = _camera.position.x * Layer_Speed[i];
            Layer_ObjectsLand[i].transform.position = new Vector2(startPos[i] + distance, _camera.position.y + offset.y);

            if (temp > startPos[i] + boundSizeX * sizeX)
            {
                startPos[i] += boundSizeX * sizeX;
            }
            else if (temp < startPos[i] - boundSizeX * sizeX)
            {
                startPos[i] -= boundSizeX * sizeX;
            }

        }
        for (int t = 0; t < 1; t++)
        {
            float temp = (_camera.position.x * (1 - Layer_Speed[t]));
            float distance = _camera.position.x + offset.x * Layer_Speed[t];
            Layer_ObjectsSky[t].transform.position = new Vector2(startPos2[t] + distance, player.position.y + offset.y);
            if (temp > startPos2[t] + boundSizeX2 * sizeX)
            {
                startPos2[t] += boundSizeX2 * sizeX;
            }
            else if (temp < startPos2[t] - boundSizeX2 * sizeX)
            {
                startPos2[t] -= boundSizeX2 * sizeX;
            }
        }
    }
    public void Land()
    {
        sizeX = Layer_ObjectsLand[0].transform.localScale.x;
        boundSizeX = Layer_ObjectsLand[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        for (int i = 0; i < 4; i++)
        {
            startPos[i] = _camera.position.x;
        }
    }
    void Sky()
    {
        sizeX = Layer_ObjectsSky[0].transform.localScale.x;
        boundSizeX2 = Layer_ObjectsSky[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        for (int t = 0; t < 1; t++)
        {
            startPos2[t] = _camera.position.x;
        }
    }
}
