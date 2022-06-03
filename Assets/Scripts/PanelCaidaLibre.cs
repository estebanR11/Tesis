using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelCaidaLibre : MonoBehaviour
{
    [SerializeField] GameObject prefab;

    public void instanciarPrefab(string tiempo, string posy,string veloY)
    {
        GameObject inst = Instantiate(prefab);

        inst.transform.SetParent(this.gameObject.transform);
        inst.GetComponent<ValuesCaida>().setValues(tiempo, posy,veloY);
    }

    
}
