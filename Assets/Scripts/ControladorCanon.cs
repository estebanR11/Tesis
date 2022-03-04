using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorCanon : MonoBehaviour
{
    [SerializeField] GameObject canon;
    [SerializeField] Quaternion actualAngle;
    [SerializeField] Vector3 rotacion;
    [SerializeField] Slider slid;
    public float angle;
    private void Start()
    {
        actualAngle = canon.transform.rotation;
    }
    public void changeRotation()
    {
        angle = -slid.value; 
        angle = (angle > 180) ? angle - 360 : angle;
        canon.transform.localEulerAngles = new Vector3(angle, 0, 0);
    }

    private void Update()
    {
    
 
    }
}
