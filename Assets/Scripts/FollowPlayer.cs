using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Vector3 offset;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Camera follows the player with specified offset position
        if (gameObject.CompareTag("MainCamera"))
        {
            transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z);
        }
        else if (gameObject.CompareTag("Ground"))
        {
            transform.position = new Vector2(player.position.x + offset.x, transform.position.y + offset.y);
        }
    }
}
