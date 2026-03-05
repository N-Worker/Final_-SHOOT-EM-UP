using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMove : MonoBehaviour
{
    public float waveSize = 2f;
    public float freeQ = 0.5f;
    public bool inverted = false;
    private float startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        float sin = Mathf.Sin(pos.x * freeQ) * waveSize;
        if (inverted)
        {
            sin *= -1;
        }
        pos.y = sin + startPos;
        transform.position = pos;
    }
}
