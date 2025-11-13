using UnityEngine;

public class PollenFloat : MonoBehaviour
{
    public float frequency = 0f, amplitude = 0f;
    public float startY = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

    }


}
