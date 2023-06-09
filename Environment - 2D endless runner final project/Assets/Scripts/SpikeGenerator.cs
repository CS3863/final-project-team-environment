
using Unity.VisualScripting;
using UnityEngine;

public class SpikeGenerator : MonoBehaviour
{
    public GameObject spike;

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
        generateSpike();
    }

    public void GenerateNextSpikeWithGap()
    {
        float Wait = Random.Range(1.5f, 2.2f);
        Invoke("generateSpike", Wait);
    }

    // Update is called once per frame
    void generateSpike()
    {
        GameObject SpikeIns = Instantiate(spike, transform.position, transform.rotation);

        //SpikeIns.GetComponent<SpikeScript>().spikeGenerator = this;
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

