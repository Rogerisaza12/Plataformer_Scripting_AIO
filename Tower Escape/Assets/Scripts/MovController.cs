using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MovController : MonoBehaviour {

    private Rigidbody2D rb;
    public float speedX;
    public float speedY;
    float speed;
    bool Jumping, isgrounded;
    private Vector3 lookRight, lookLeft;

    
    int score = 10000;
    public Text scoretext;
    int vidas = 3;
    public Text Vidas;
    int axeUses;
    bool canDestroy = false;
    public Text Axes;

    

    void Start()
    {
        lookLeft = new Vector3(0.5873498f, 0.56f, 1f);
        lookRight = new Vector3(-0.5873498f, 0.56f, 1f);

        rb = GetComponent<Rigidbody2D>();
        axeUses = 0;
        SetCountText();

        
    }

    // Update is called once per frame
    void Update()
    {
        score = score - 1;
        SetCountText();

       
        if (vidas < 0)
        {
            SceneManager.LoadScene("GameOver");
        }

        MovePlayer(speed);

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            speed = -speedX;
            WalkLeft();
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            speed = 0; 
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            speed = speedX;
            WalkRight();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            speed = 0;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }
        
        
    }

    void MovePlayer(float playerSpeed)
    {
        rb.velocity = new Vector3(speed, rb.velocity.y, 0);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Exit")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (other.gameObject.tag == "Axe")
        {
            other.gameObject.SetActive(false);
            axeUses = 3;
            canDestroy = true;

        }
        if (other.gameObject.tag == "ground")
        {
            isgrounded = true;
            Jumping = false;
        }
        if (other.gameObject.tag == "Obstaculo")
        {
            if (canDestroy == true)
            {
                other.gameObject.SetActive(false);
                axeUses = axeUses - 1;
                if(axeUses == 0)
                {
                    canDestroy = false;
                }
            }
            isgrounded = true;
            Jumping = false;
        }
        if (other.gameObject.CompareTag("Persona"))
        {
            other.gameObject.SetActive(false);
            score = score + 500;
            
            SetCountText();
        }
        if (other.gameObject.CompareTag("Roca"))
        {
            other.gameObject.SetActive(false);
            score = score - 750;
            vidas = vidas - 1;
            SetCountText();
        }
    }

    public void WalkLeft()
    {
        speed = -speedX;
        transform.localScale = lookLeft;
    }
    public void WalkRight()
    {
        speed = speedX;
        transform.localScale = lookRight;

    }
   
    public void Jump()
    {
        if (isgrounded)
        {
            Jumping = true;
            isgrounded = false;
            rb.AddForce(new Vector2(rb.velocity.x, speedY));
        }
    }
   
    void SetCountText()
    {
        scoretext.text = "Score: " + score.ToString();
        Axes.text = "Axe Uses: " + axeUses.ToString();
        Vidas.text = "Vidas: " + vidas.ToString();
    }

}
