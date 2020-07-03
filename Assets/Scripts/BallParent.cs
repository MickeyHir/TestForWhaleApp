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

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);

        if(transform.position == endPosition)
        {
            Destroy(this.gameObject);
        }
    }
}
