using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StarData : MonoBehaviour
{/**
  * Tutorial link
  * https://github.com/tikonen/blog/tree/master/csvreader
  * */
    public Sprite mySprite;
    public int dataMode;

    private int rowCount = 0;
    private GameObject[] starLayer1 = new GameObject[84];
    private GameObject[] starLayer2 = new GameObject[84];
    private GameObject[] starLayer3 = new GameObject[84];
    private GameObject[] starLayer4 = new GameObject[84];

    List<Dictionary<string, object>> data; 
    string[] dataSets = {"2007_trim", "2016_trim", "2021_trim"};
    
    //  -12 < x < 12, -8 < y < 1
    void Awake() {
        data = CSVReader.Read(dataSets[0]);

        for (int i = 0; i < starLayer2.Length; i++)
        {
            starLayer1[i] = new GameObject();
            SpriteRenderer renderer = starLayer1[i].AddComponent<SpriteRenderer>();
            renderer.sprite = mySprite;
            starLayer1[i].transform.localScale = new Vector2(0.1f, 0.1f);
            starLayer1[i].transform.position = new Vector2(Random.Range(-12f, 12f), Random.Range(-3.78f, 1f));
            starLayer1[i].layer = -1;
        }

        for (int i = 0; i < starLayer2.Length; i++)
        {
            starLayer2[i] = new GameObject();
            SpriteRenderer renderer = starLayer2[i].AddComponent<SpriteRenderer>();
            renderer.sprite = mySprite;
            starLayer2[i].transform.localScale = new Vector2(0.1f, 0.1f);
            starLayer2[i].transform.position = new Vector2(Random.Range(-12f, 12f), Random.Range(-3.78f, 1f));
            starLayer2[i].layer = -1;
        }


        for (int i = 0; i < starLayer2.Length; i++)
        {
            starLayer3[i] = new GameObject();
            SpriteRenderer renderer = starLayer3[i].AddComponent<SpriteRenderer>();
            renderer.sprite = mySprite;
            starLayer3[i].transform.localScale = new Vector2(0.1f, 0.1f);
            starLayer3[i].transform.position = new Vector2(Random.Range(-12f, 12f), Random.Range(-3.78f, 1f));
            starLayer3[i].layer = -1;
        }

        for (int i = 0; i < starLayer2.Length; i++)
        {
            starLayer4[i] = new GameObject();
            SpriteRenderer renderer = starLayer4[i].AddComponent<SpriteRenderer>();
            renderer.sprite = mySprite;
            starLayer4[i].transform.localScale = new Vector2(0.1f, 0.1f);
            starLayer4[i].transform.position = new Vector2(Random.Range(-12f, 12f), Random.Range(-3.78f, 1f));
            starLayer4[i].layer = -1;
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
        float skyVisibility = System.Convert.ToSingle(data[rowCount]["CloudCover"]);

        switch (skyVisibility)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            default:
                break;
        }
    }

    void hideLayers(GameObject[] starLayers)
    {
        for (int i = 0; i < starLayers.Length; i++)
        {
            Renderer starColor = starLayers[i].GetComponent<Renderer>();
            starColor.material.color.a = 1.0f;
        }
    }

}