using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour
{
    private Rigidbody rb;
    private HingeJoint hj;
    public float force;
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        hj = this.GetComponent<HingeJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Swing(float dir)
    {
        Vector3 forceDir = new Vector3(0, 0, force * dir);
        rb.AddForce(forceDir);
    }

    public void Release()
    {
        hj.breakForce = 0;
    }
}
