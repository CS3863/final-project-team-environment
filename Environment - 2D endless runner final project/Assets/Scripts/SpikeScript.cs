using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * 2f * Time.deltaTime);
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if(collision.gameObject.CompareTag("nextline"))
        //{
        //   spikeGenerator.GenerateNextSpikeWithGap();
        //}
        if (collision.gameObject.CompareTag("Finish"))
        {
            Destroy(this.gameObject);
        }
        /*
        if (collision.gameObject.CompareTag("player"))
        {
            Debug.Log("collision");
            //Application.Quit();
        }
        */
    }
    
    
}
    





