using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowerCamera : MonoBehaviour
{
    private GameObject target;
    public GameObject ball;
    public GameObject log;
    public float offset;
    public Camera mainCamera;
    public float offsetMultyplier;
    public GameMaster gameMaster;
    void Start()
    {
        target = ball;
    }

    // Update is called once per frame
    void Update()
    {
        Forward();

        if(target.transform.position.x <= log.transform.position.x )
        {
            return;
        }
        target = log;
        mainCamera.GetComponent<Animator>().enabled = false;
        gameMaster.buttonCanvas.SetActive(true);
    }
    
    private void Forward()
    {
        Vector3 pos = new Vector3(target.transform.position.x - offset, transform.position.y, target.transform.position.z * offsetMultyplier);
        transform.position = pos;

        Vector3 dir = target.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = lookRotation.eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    
}
