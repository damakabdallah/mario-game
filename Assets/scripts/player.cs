using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour {

    [HideInInspector]
    public float coinNB;
    [HideInInspector]
    public static bool hasPowerUp;
    public Text coinTxt;
    public GameObject NormalSprite;
    public GameObject PouwerUpSprite;
    public float walkingSpeed;
    public float jumpingSpeed;
    float x;
    float jump=0;
    bool isGrounded;
    Rigidbody2D playerRB;

	// Use this for initialization
	void Start () {
        playerRB = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        x = Input.GetAxis("Horizontal")*walkingSpeed;
        if (isGrounded == true)
        {
            jump = Input.GetAxis("Jump") * jumpingSpeed;
        }
        else
            jump = 0;
        if (jump == 0)
            jump = playerRB.velocity.y;
        else
            isGrounded = false;
        playerRB.velocity = new Vector2(x, jump);
        if (hasPowerUp == true)
        {
            NormalSprite.SetActive(false);
            PouwerUpSprite.SetActive(true);
        }
        else
        {
            PouwerUpSprite.SetActive(false);
            NormalSprite.SetActive(true);
        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coin")
        {
            coinNB++;
            coinTxt.text = "coins : " + coinNB;
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag=="power up")
        {
            hasPowerUp = true;
            Destroy(collision.gameObject);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
       
        if (collision.collider.tag == "ground")
        {
            isGrounded = true;
        }
    }
}
