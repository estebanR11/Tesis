using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    [SerializeField] int scene;
    // Start is called before the first frame update
    void Start()
    {
        Button but = GetComponent<Button>();
        but.onClick.AddListener(loadScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadScene()
    {
        SceneManager.LoadScene(scene);
    }
}
