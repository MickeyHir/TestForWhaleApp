using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowerCamera : MonoBehaviour
{
    private GameObject target;
    private GameObject ball;
    private GameObject log;
    private Animator mainCameraAnimator;
    private GameMaster gameMaster;
    public float offsetX;
    public float offsetY;
    public float offsetMultyplier;
    public float cameraSpeed;
    void Start()
    {
        ball = GameObject.Find("BallParent");
        log = GameObject.Find("Log");
        gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        mainCameraAnimator = this.gameObject.GetComponentInChildren<Animator>();
        target = ball;
    }

    void Update()
    {
        Forward();

        if(target.transform.position.x <= log.transform.position.x )
        {
            return;
        }
        target = log;
        mainCameraAnimator.enabled = false;
        gameMaster.buttonCanvas.SetActive(true);
    }
    
    private void Forward()
    {
        Vector3 pos = new Vector3(target.transform.position.x - offsetX, target.transform.position.y + offsetY, target.transform.position.z * offsetMultyplier);
        transform.position = Vector3.Lerp(transform.position, pos, cameraSpeed);

        Vector3 dir = target.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = lookRotation.eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    
}
