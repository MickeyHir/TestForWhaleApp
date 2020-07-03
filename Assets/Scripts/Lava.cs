using UnityEngine;

public class Lava : MonoBehaviour
{
    private Material material;
    private float offset;
    public float offsetSpeed;

    void Start()
    {
        material = this.gameObject.GetComponent<Renderer>().material;
        offset = 0;
    }

    void Update()
    {
        material.mainTextureOffset =  new Vector2(offset, offset);
        offset += offsetSpeed * Time.deltaTime;
    }
}
