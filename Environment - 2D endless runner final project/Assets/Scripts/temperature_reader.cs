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
    public GameObject water;
    public Material material;
    // dataMode must be value between [1 , 3]
    public int dataMode;

    private float dataOffset = 0.33f;
    private int dataUpperbound = 0;
    private int dataLowerbound = 0;
    private int rowCount;

    private List<Dictionary<string, object>> data;
    private float startDelay = 0.0f;
    private float timeInterval = 0.25f;

    void Awake()
    {
        data = CSVReader.Read("Global Temperature Anomalies");//udata is the name of the csv file 
        dataUpperbound = (int) (data.Count * map(dataMode, 1, 3, 0.33f, 1));
        dataLowerbound = dataUpperbound - ((int) (data.Count * dataOffset));
        rowCount = dataLowerbound;
        //print("data mode: " + dataMode + ", data upperbound: " + dataUpperbound + ", data lowerbound: " + dataLowerbound);
    }

    void Start()
    {
        InvokeRepeating("updateColor", startDelay, timeInterval);
    }


    void updateColor()
    {
        if (rowCount < dataUpperbound - 1) {
            rowCount += 1;
        } else {
            rowCount = dataLowerbound;
        }
        //print("global ocean temperature for row " + rowCount + ", year " + data[rowCount]["Year"] + ": " + data[rowCount]["Value"]);
        float redChange = map(System.Convert.ToSingle((float) (data[rowCount]["Value"])), -0.64f, 1.35f, 1f, 4f);
        float greenChange = map(System.Convert.ToSingle((float)(data[rowCount]["Value"])), -0.64f, 1.35f, -0.5f, 1f);
        float blueChange = map(System.Convert.ToSingle((float)(data[rowCount]["Value"])), -0.64f, 1.35f, 1, -1);
        material.color = new Color(redChange, 1f + greenChange, 2f + blueChange);
    }

    float map(float value, float domainMin, float domainMax, float newDomainMin, float newDomainMax)
    {
        return newDomainMin + ((newDomainMax - newDomainMin) / (domainMax - domainMin)) * (value - domainMin);
    }
}