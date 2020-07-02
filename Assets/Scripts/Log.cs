using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour
{
    private Rigidbody rb;
    private HingeJoint hj;
    public float force;
    public GameObject lava;
    public GameObject explosionPrefab;
    public GameMaster gameMaster;
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        hj = this.GetComponent<HingeJoint>();
    }

    public void Swing(float dir)
    {
        Vector3 forceDir = new Vector3(0, 0, force * dir);
        rb.AddForce(forceDir);
    }

    public void Release()
    {
        hj.breakForce = 0;
        gameMaster.buttonCanvas.SetActive(false);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject == lava)
        {
            //create explosion effect
            GameObject explosionEffect = (GameObject)Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(explosionEffect, 5f);
            //call for restart
            gameMaster.RestartGame();
        }
    }
}
