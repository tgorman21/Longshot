using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Variables : ScriptableObject
{
    public float distance_count;
    public float best_distance;
    public float flingSpeed;
    public float boostPower;
    public float distanceTravelled;
    public bool playerLanded = false;
}
