using Unity.VisualScripting;
using UnityEngine;

public class StarGenerator : MonoBehaviour
{
    public GameObject star;

    public float MaxSpeed;
    public float MinSpeed;
    public float currentSpeed;
    public float SpeedMultiplier;
    bool isGrounded = false;
    public bool isAlive = true;


    // Start is called before the first frame update
    void Awake()
    {
        currentSpeed = MinSpeed;
        generateStar();
    }

    public void GenerateNextStarWithGap()
    {
        float Wait = Random.Range(1.0f, 3.2f);
        Invoke("generateStar", Wait);
    }

    // Update is called once per frame
    void generateStar()
    {
        GameObject StarIns = Instantiate(star, transform.position, transform.rotation);

        StarIns.GetComponent<StarData>().starGenerator = this;
        
    }

    private void Update()
    {/*
        if (currentSpeed < MaxSpeed)
        {
            currentSpeed += SpeedMultiplier;
        }
*/    
    } 
        


    }