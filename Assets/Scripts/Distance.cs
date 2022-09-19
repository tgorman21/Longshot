using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class Distance : MonoBehaviour
{
    public Variables distance_count;
    public Variables best_distance;
    public Transform player;
    public TextMeshProUGUI distance;
    public TextMeshProUGUI bestDistance;
    // Start is called before the first frame update
    void Start()
    {
        distance = GameObject.Find("Distance").GetComponent<TextMeshProUGUI>();
        bestDistance = GameObject.Find("BestDistance").GetComponent<TextMeshProUGUI>();
        //distance.text = "Distance";
        //distance_count = player.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        //distance.text = distance_count.ToString();
        distance_count.distance_count = Mathf.Round(player.position.x) + 7f;
        distance.text = distance_count.distance_count.ToString();
        bestDistance.text = best_distance.best_distance.ToString();


    }
}
