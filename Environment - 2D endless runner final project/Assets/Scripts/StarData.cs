using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class StarData : MonoBehaviour
{/**
  * Tutorial link
  * https://github.com/tikonen/blog/tree/master/csvreader
  * */
    public Sprite mySprite;
    public int dataMode;
    public Material starMaterial;
    public TMP_Text starLabel;

    private int rowCount = 0;
    private GameObject[] starLayer1 = new GameObject[84];
    private GameObject[] starLayer2 = new GameObject[84];
    private GameObject[] starLayer3 = new GameObject[84];
    private GameObject[] starLayer4 = new GameObject[84];

    private Color clear = new Color(1, 1, 1, 0);
    private Color starColor = new Color(1, 1, 1, 1);

    List<Dictionary<string, object>> data; 
    string[] dataSets = {"2007", "2016", "2021"};
    
    //  -12 < x < 12, -8 < y < 2
    void Awake() {
        data = CSVReader.Read(dataSets[dataMode - 1]);

        for (int i = 0; i < starLayer1.Length; i++)
        {
            starLayer1[i] = new GameObject();
            SpriteRenderer renderer = starLayer1[i].AddComponent<SpriteRenderer>();
            renderer.sprite = mySprite;
            starLayer1[i].GetComponent<SpriteRenderer>().color = starColor;
            starLayer1[i].transform.localScale = new Vector2(0.1f, 0.1f);
            starLayer1[i].transform.position = new Vector2(Random.Range(-12f, 12f), Random.Range(-3.5f, 3f));
        }

        for (int i = 0; i < starLayer2.Length; i++)
        {
            starLayer2[i] = new GameObject();
            SpriteRenderer renderer = starLayer2[i].AddComponent<SpriteRenderer>();
            renderer.sprite = mySprite;
            starLayer2[i].GetComponent<SpriteRenderer>().color = starColor;
            starLayer2[i].transform.localScale = new Vector2(0.1f, 0.1f);
            starLayer2[i].transform.position = new Vector2(Random.Range(-12f, 12f), Random.Range(-3.5f, 3f));

        }


        for (int i = 0; i < starLayer3.Length; i++)
        {
            starLayer3[i] = new GameObject();
            SpriteRenderer renderer = starLayer3[i].AddComponent<SpriteRenderer>();
            renderer.sprite = mySprite;
            starLayer3[i].GetComponent<SpriteRenderer>().color = starColor;
            starLayer3[i].transform.localScale = new Vector2(0.1f, 0.1f);
            starLayer3[i].transform.position = new Vector2(Random.Range(-12f, 12f), Random.Range(-3.5f, 3f));
        }

        for (int i = 0; i < starLayer4.Length; i++)
        {
            starLayer4[i] = new GameObject();
            SpriteRenderer renderer = starLayer4[i].AddComponent<SpriteRenderer>();
            renderer.sprite = mySprite;
            starLayer4[i].GetComponent<SpriteRenderer>().color = starColor;

            starLayer4[i].transform.localScale = new Vector2(0.1f, 0.1f);
            starLayer4[i].transform.position = new Vector2(Random.Range(-12f, 12f), Random.Range(-3.78f, 3f));
        }
    }

    void Start()
    {
        InvokeRepeating("updateStars", 0.02f, 0.5f);
    }
    void updateStars()
    {
        if (rowCount < data.Count - 1)
        {
            rowCount += 1;
        }
        else
        {
            rowCount = 0;
        }

        float skyVisibility = System.Convert.ToSingle(data[rowCount]["CloudCover"]);
        starLabel.text = "Star Year: " + dataSets[dataMode-1];

        switch (skyVisibility)
        {
            case 0:
                showLayers(starLayer1);
                showLayers(starLayer2);
                showLayers(starLayer3);
                showLayers(starLayer4);
                break;
            case 1:
                hideLayers(starLayer1);
                showLayers(starLayer2);
                showLayers(starLayer3);
                showLayers(starLayer4);
                break;
            case 2:
                hideLayers(starLayer1);
                hideLayers(starLayer2);
                showLayers(starLayer3);
                showLayers(starLayer4);
                break;
            case 3:
                hideLayers(starLayer3);
                hideLayers(starLayer2);
                hideLayers(starLayer1);
                showLayers(starLayer4);
                break;
            default:
                showLayers(starLayer1);
                showLayers(starLayer2);
                showLayers(starLayer3);
                showLayers(starLayer4);
                break;
        }
    }

    void hideLayers(GameObject[] starLayers)
    {
        for (int i = 0; i < starLayers.Length; i++)
        {
            starLayers[i].GetComponent<SpriteRenderer>().color = clear;
        }
    }

    void showLayers(GameObject[] starLayers)
    {
        for (int i = 0; i < starLayers.Length; i++)
        {
            starLayers[i].GetComponent<SpriteRenderer>().color = starColor;
        }
    }
}