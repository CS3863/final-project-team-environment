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
    public GameObject water;
    public Material material;
    int rowCount; 

    private float startDelay = 0.0f;
    private float timeInterval = 0.25f;

    void Awake()
    {
        data = CSVReader.Read("Global Temperature Anomalies");//udata is the name of the csv file 

        //for (var i = 0; i < data.Count; i++)
        //{
        //    print("global ocean temperature for row " + i + ", year " + data[i]["Year"] + ": " + data[i]["Value"]);
        //}
        rowCount = 0;
    }

    void Start()
    {
        InvokeRepeating("updateColor", startDelay, timeInterval);
    }


    void updateColor()
    {
        if (rowCount < data.Count - 1) {
            rowCount += 1;
        } else {
            rowCount = 0;
        }
        print("global ocean temperature for row " + rowCount + ", year " + data[rowCount]["Year"] + ": " + data[rowCount]["Value"]);
        float oceanChange = map(System.Convert.ToSingle(dataObject), -0.64, 1.35, 0, 1);
        material.color = new Color(yearData, dayData, hourData);
        //transform.localScale = new Vector3(tempFloat, tempFloat, tempFloat);
        //Debug.Log("tempFloat = " + tempFloat);
        //Debug.Log("Count = " + rowCount);
    }

    float map(float value, float domainMin, float domainMax, float newDomainMin, float newDomainMax)
    {
        return newDomainMin + ((newDomainMax - newDomainMin) / (domainMax - domainMin)) * (value - domainMin);
    }
}