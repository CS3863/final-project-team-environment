using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/*
 * Data  is provided from ORNL DAAC, Distributed Active Archive Center for Biogeochemical Dynamics.

Jacobs, N., W.R. Simpson, F. Hase, T. Blumenstock, Q. Tu, M. Frey, M.K. Dubey, and H.A. Parker. 2021. Ground-based Observations of XCO2,
XCH4, and XCO, Fairbanks, AK, 2016-2019. ORNL DAAC, Oak Ridge, Tennessee, USA. https://doi.org/10.3334/ORNLDAAC/1831

Diego Velasco, 11 April 2023
 */
public class icemass_datareader : MonoBehaviour
{/**
  * Tutorial link
  * https://github.com/tikonen/blog/tree/master/csvreader
  * */

    
    public GameObject prefabIceberg;
    public int dataMode;

    private float dataOffset = 0.33f;
    private int dataUpperbound = 0;
    private int dataLowerbound = 0;
    private int rowCount;

    private float startDelay = 1.0f;
    private float timeInterval = 4.0f;
    private List<Dictionary<string, object>> data;

    void Awake()
    {
        data = CSVReader.Read("greenland_mass_trim");//udata is the name of the csv file 
        dataUpperbound = (int)(data.Count * map(dataMode, 1, 3, 0.33f, 1));
        dataLowerbound = dataUpperbound - ((int)(data.Count * dataOffset));
        rowCount = dataLowerbound;
        print("ICEMASS!!!! === data mode: " + dataMode + ", data upperbound: " + dataUpperbound + ", data lowerbound: " + dataLowerbound);

        rowCount = dataLowerbound;
    }

    void Start()
    {
        if (tag != "spike") //this is EXTREMELY IMPORTANT but I forgot how it works
        {
            InvokeRepeating("SpawnObject", startDelay, timeInterval);
        }
        else { SpawnObject(); }
        
    }//end Start()

    void SpawnObject()
    {
        if (rowCount < dataUpperbound - 1)
        {
            rowCount += 1;
        }
        else
        {
            rowCount = dataLowerbound;
        }
        float iceMass = System.Convert.ToSingle(data[rowCount]["diff"]);
        iceMass = Mathf.Abs(iceMass);
        iceMass = Mathf.Pow(iceMass, 0.01f);

        print("ice mass for row " + rowCount + ": " + data[rowCount]["diff"]);

        GameObject iceberg = Instantiate(prefabIceberg, transform.position, transform.rotation);
        iceberg.transform.localScale = new Vector2(iceMass, iceMass);
    }

    float map(float value, float domainMin, float domainMax, float newDomainMin, float newDomainMax)
    {
        return newDomainMin + ((newDomainMax - newDomainMin) / (domainMax - domainMin)) * (value - domainMin);
    }
}