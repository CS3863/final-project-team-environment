using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StarData : MonoBehaviour
{/**
  * Tutorial link
  * https://github.com/tikonen/blog/tree/master/csvreader
  * */

  public StarGenerator starGenerator;

    List<Dictionary<string, object>> data; 
    public GameObject myCube;//prefab
    int cubeCount; //variable 
    string[] dataSets = {"Globe at Night 2021 SQM", "Globe at Night 2020 SQM", "Globe at Night 2019 SQM", "Globe at Night 2018 SQM", "Globe at Night 2017 SQM", "Globe at Night 2016 SQM", "Globe at Night 2015 SQM", "Globe at Night 2014 SQM", "Globe at Night 2013 SQM", "Globe at Night 2012 SQM", "Globe at Night 2011 SQM", "Globe at Night 2010 SQM", "Globe at Night 2009 SQM", "Globe at Night 2008 SQM", "Globe at Night 2007 SQM" };

   /* void Awake()
    {

        data = CSVReader.Read("udata");//udata is the name of the csv file 

        for (var i = 0; i < data.Count; i++)
        {
            //name, age, speed, description, is the headers of the database
            print("name " + data[i]["name"] + " " +
                   "age " + data[i]["age"] + " " +
                   "speed " + data[i]["speed"] + " " +
                   "desc " + data[i]["description"]);
        }


    }//end Awake()
    */

    // Use this for initialization
    void Start()
    {
        /*
        for (var i = 0; i < data.Count; i++)
        {
            object age = data[i]["age"];//get age data
            cubeCount += (int)age;//convert age data to int and add to cubeCount
            Debug.Log("cubeCount" +cubeCount);
            Debug.Log("variable i" + i);

        }
        Debug.Log("end start" +cubeCount);
        */

    }//end Start()

    // Update is called once per frame
    void Update()
    {

        data = CSVReader.Read(dataSets[0]); 

        transform.Translate(Vector2.left * starGenerator.currentSpeed * Time.deltaTime);

        for(int i = 1; i < dataSets.Length; i++)
        {
            //datasetName = dataSets[currentDataset += 1]
            data = CSVReader.Read(dataSets[i]); 



            Debug.Log("data " + data);





        }
       
       // if data.count < currentEntry
        

    /*
         Debug.Log("update cubeCount" +cubeCount);

        //As long as cube count is not zero, instantiate prefab
        while (cubeCount > 0)
        {
            Instantiate(myCube);
            cubeCount--;
            Debug.Log("while cubeCount" +cubeCount);

        }
    */

    }
    //end Update()
}