using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallParent : MonoBehaviour
{
    public Vector3 startPosition;
    public Vector3 endPosition;
    public float speed;
    void Start()
    {
        transform.position = startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);
    }
}
