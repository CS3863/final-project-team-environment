using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using TMPro;
using static UnityEditor.Experimental.GraphView.GraphView;



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
    private float timeInterval = 1.5f;
    private List<Dictionary<string, object>> data;

    public static bool isAlive = true;
    public float score;
    public TMP_Text ScoreTxt;

    void Awake()
    {
        data = CSVReader.Read("IceMassDataYear");//udata is the name of the csv file 
        dataUpperbound = (int)(data.Count * map(dataMode, 1, 3, 0.33f, 1));
        dataLowerbound = dataUpperbound - ((int)(data.Count * dataOffset));
        rowCount = dataLowerbound;
        print("ICEMASS!!!! === data mode: " + dataMode + ", data upperbound: " + dataUpperbound + ", data lowerbound: " + dataLowerbound);

        rowCount = dataLowerbound;
    }

    void Start()
    {
    //    if (tag != "spike") //this is EXTREMELY IMPORTANT but I forgot how it works
     //   {
      InvokeRepeating("SpawnObject", startDelay, timeInterval);
      //  }
      //  else { SpawnObject(); }
        
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
        //float iceMass = System.Convert.ToSingle(data[rowCount]["diff"]);
        //iceMass = Mathf.Abs(iceMass);
        //iceMass = 2 - Mathf.Pow(iceMass, 0.01f);

        if (prefabIceberg != null)
        {
            float iceMass = map(System.Convert.ToSingle(data[rowCount]["IceMass Change"]), -5248.44f, 66.04f, 0.01f, 1);

            print("ice mass for row " + rowCount + ": " + data[rowCount]["IceMass Change"]);

            GameObject iceberg = Instantiate(prefabIceberg, transform.position, transform.rotation);
            iceberg.transform.localScale = new Vector2(iceMass * 2, iceMass * 2);
            iceberg.layer = 2;
        }
        score = System.Convert.ToSingle(data[rowCount]["Year"]);
        ScoreTxt.text = "Ice Cap Year:  " + score.ToString("F");

    }

    float map(float value, float domainMin, float domainMax, float newDomainMin, float newDomainMax)
    {
        return newDomainMin + ((newDomainMax - newDomainMin) / (domainMax - domainMin)) * (value - domainMin);
    }
}