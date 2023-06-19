using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAnimation : MonoBehaviour
{
    public float Speed = 1f;
    public float Strength = 2.5f;

    private float randomOffset;


    void Start()
    {
        randomOffset = Random.Range(-Strength, Strength);
    }

    void Update()
    {
        Vector3 position = transform.position;
        position.x = Mathf.Sin(Time.time * Speed * randomOffset) * Strength;
        transform.position = position;
    }
}
