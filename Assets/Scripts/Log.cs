using System.Collections;
using UnityEngine;

public class Log : MonoBehaviour
{
    private Rigidbody rb;
    private HingeJoint hj;
    private GameObject lava;
    private GameMaster gameMaster;
    public GameObject explosionPrefab;
    public float force;
    public float delayTime;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        hj = this.GetComponent<HingeJoint>();
        lava = GameObject.Find("Lava");
        gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
    }

    public void SwingLeft()
    {
        Vector3 forceDir = new Vector3(0, 0, force);
        rb.AddForce(forceDir);
    }
    public void SwingRight()
    {
        Vector3 forceDir = new Vector3(0, 0, -force);
        rb.AddForce(forceDir);
    }

    public void Release()
    {
        rb.AddForce(Vector3.up);
        hj.breakForce = 0;
        gameMaster.buttonCanvas.SetActive(false);
        StartCoroutine(StuckHendler());
    }

    IEnumerator StuckHendler()
    {
        yield return new WaitForSeconds(delayTime);
        Explode();
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject == lava)
        {
            Explode();         
        }
    }

    public void Explode()
    {
        GameObject explosionEffect = (GameObject)Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(explosionEffect, 5f);
        gameMaster.RestartGame();
    }
}
