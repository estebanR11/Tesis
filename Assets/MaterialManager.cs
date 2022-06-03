using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MaterialManager : MonoBehaviour
{


    [SerializeField] PhysicMaterial mat;
    [SerializeField] TMP_InputField inputField;
    [SerializeField] TMP_InputField inputFieldMasa;
    [SerializeField] Rigidbody rb;
    private void Start()
    {
        mat = GetComponent<MeshCollider>().material;

    }

    public void onValueChange()
    {
        float valor = float.Parse(inputField.text);
        mat.staticFriction = valor;
    }

    public void masaChange()
    {
        float masa = float.Parse(inputFieldMasa.text);
        rb.mass = masa;
    }
}
