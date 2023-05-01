using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            SceneManager.LoadScene("1st Scene");
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            SceneManager.LoadScene("2nd Scene");
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene("3rd Scene");
        }
    }
}
