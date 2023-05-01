using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StarData : MonoBehaviour
{/**
  * Tutorial link
  * https://github.com/tikonen/blog/tree/master/csvreader
  * */
    public Sprite mySprite;

    private int rowCount = 0;
    private GameObject[] stars = new GameObject[300];

    List<Dictionary<string, object>> data; 
    string[] dataSets = {"Globe at Night 2021 SQM", "Globe at Night 2020 SQM", "Globe at Night 2019 SQM", "Globe at Night 2018 SQM", "Globe at Night 2017 SQM", "Globe at Night 2016 SQM", "Globe at Night 2015 SQM", "Globe at Night 2014 SQM", "Globe at Night 2013 SQM", "Globe at Night 2012 SQM", "Globe at Night 2011 SQM", "Globe at Night 2010 SQM", "Globe at Night 2009 SQM", "Globe at Night 2008 SQM", "Globe at Night 2007 SQM" };
    
    //  -12 < x < 12, -8 < y < 1
    void Awake() {
        data = CSVReader.Read(dataSets[0]);

        for (int i = 0; i < stars.Length; i++)
        {
            stars[i] = new GameObject();
            SpriteRenderer renderer = stars[i].AddComponent<SpriteRenderer>();
            renderer.sprite = mySprite;
            stars[i].transform.localScale = new Vector2(0.1f, 0.1f);
            stars[i].transform.position = new Vector2(Random.Range(-12f, 12f), Random.Range(-3.78f, 1f));
            stars[i].layer = -1;
        }
     }

        void Start()
    {
       

    }

    public void GenerateNextStarWithGap()
    {
        float Wait = Random.Range(1.0f, 2.2f);
        Invoke("updateStars", Wait);
    }
    void updateStars()
    {
        // mySprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        //Instantiate(mySprite, transform.position, transform.rotation);

    }

}