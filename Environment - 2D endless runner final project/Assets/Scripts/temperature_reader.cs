using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;


/*
 * Data  is provided from ORNL DAAC, Distributed Active Archive Center for Biogeochemical Dynamics.

Jacobs, N., W.R. Simpson, F. Hase, T. Blumenstock, Q. Tu, M. Frey, M.K. Dubey, and H.A. Parker. 2021. Ground-based Observations of XCO2,
XCH4, and XCO, Fairbanks, AK, 2016-2019. ORNL DAAC, Oak Ridge, Tennessee, USA. https://doi.org/10.3334/ORNLDAAC/1831

Diego Velasco, 11 April 2023
 */
public class temperature_reader : MonoBehaviour
{/**
  * Tutorial link
  * https://github.com/tikonen/blog/tree/master/csvreader
  * */

    List<Dictionary<string, object>> data;
    public GameObject myCube;//prefab
    int rowCount; //variable 

    private float startDelay = 2.0f;
    private float timeInterval = 1.0f;
    public object tempObj;
    public float tempFloat;
    SpriteRenderer sprite;

    void Awake()
    {

        data = CSVReader.Read("temperature_trim");//udata is the name of the csv file 

        for (var i = 0; i < data.Count; i++)
        {
            //name, age, speed, description, is the headers of the database
            //print("mass difference " + data[i]["xco2"] + " ");
        }
        rowCount = 0;


    }//end Awake()

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("SpawnObject", startDelay, timeInterval);
        sprite = GetComponent<SpriteRenderer>();
    }//end Start()

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {

            tempObj = data[rowCount]["temps"];
            tempFloat = System.Convert.ToSingle(tempObj);
            rowCount = UnityEngine.Random.Range(0, 20);

            // Change the 'color' property of the 'Sprite Renderer'
            sprite.color = new Color(tempFloat, tempFloat, tempFloat, tempFloat);
        }        //As long as cube count is not zero, instantiate prefab
        /*
        while (cubeCount > 0)
        {
            Instantiate(myCube);
            cubeCount--;
            Debug.Log("cubeCount" + cubeCount);
        }
        */

        /*
        for (var i = 0; i < data.Count; i++)
        {
            object xco2 = data[i]["xco2"];//get age data

            gameObject.transform.localScale = new Vector3((float)xco2, (float)xco2, (float)xco2);
            //cubeCount += (int)xco2;//convert age data to int and add to cubeCount
            //Debug.Log("cubeCount" + cubeCount);
        }
        */


    }//end Update()


    void SpawnObject()
    {
        tempObj = data[rowCount]["temps"];
        tempFloat = System.Convert.ToSingle(tempObj);
        //Minimum is 388.09
        tempFloat = tempFloat;
        rowCount++;

        transform.localScale = new Vector3(tempFloat, tempFloat, tempFloat);
        Debug.Log("tempFloat = " + tempFloat);
        Debug.Log("Count = " + rowCount);
    }

}