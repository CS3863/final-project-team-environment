
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public float JumpForce;

    [SerializeField]
    bool isGrounded = false;
    public static bool isAlive = true;
    float score;
    public Text ScoreTxt;


    Rigidbody2D RB;

        private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        score = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
        if (isGrounded == true)
            {
            RB.AddForce(Vector2.up * JumpForce);
                isGrounded = false;
               
            }
        }





    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("ground"))
        {
            if(isGrounded== false)
            {
                isGrounded= true;
            }
        }
        
        if (collision.gameObject.CompareTag("spike"))
        {
            isAlive = false;
            Debug.Log("collision");
            Destroy(this.gameObject);
            System.Threading.Thread.Sleep(600);
            SceneManager.LoadScene("Death Scene");
            //Application.Quit();
            //SpikeGenerator.currentSpeed = 0;
        }




    }
    
}
