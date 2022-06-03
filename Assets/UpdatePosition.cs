using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePosition : MonoBehaviour
{
    float xInicial;
    float yInicial;
    float zInicial;
    // Start is called before the first frame update
    void Start()
    {
        xInicial = transform.position.x;
        yInicial = transform.position.y;
        zInicial = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(xInicial, yInicial, zInicial);
    }
}
