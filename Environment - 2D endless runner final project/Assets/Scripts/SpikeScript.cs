using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    public float speed = 12;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
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
    





