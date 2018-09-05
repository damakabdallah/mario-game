using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {
    [HideInInspector]
    public GameObject Player;
    [HideInInspector]
    public Rigidbody2D enemyRB;
    [HideInInspector]
    public float direction = 1;
    [HideInInspector]
    public float enemySpeed = 5;
    [HideInInspector]
    public RaycastHit2D UpHit, UpHit2, UpHit3, RightHit, LeftHit;
    [HideInInspector]
    public  float origin;
    [HideInInspector]
    public  Rigidbody2D playerRB;
    [HideInInspector]
    public player playerScript;

    public static GameObject NormalSprite;
    public static GameObject PowerUpSprite;



    public void initalisation()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        origin = (GetComponent<BoxCollider2D>().size.x / 2) + 0.1f;
        Player = GameObject.FindWithTag("Player");
        playerRB = Player.GetComponent<Rigidbody2D>();
        NormalSprite = Player.transform.GetChild(0).gameObject;
        PowerUpSprite = Player.transform.GetChild(1).gameObject;
    }
    public void enemyMoving()
    {
        enemyRB.velocity = new Vector2(direction * enemySpeed, 0);
    }
    public void createHits()
    {
        UpHit =Physics2D.Raycast(transform.position + new Vector3(0f, origin), Vector2.up,0.01f);
        UpHit2 = Physics2D.Raycast(transform.position + new Vector3(origin - 0.2f, origin), Vector2.up,0.01f);
        UpHit3 = Physics2D.Raycast(transform.position - new Vector3(origin - 0.2f, 0f) + new Vector3(0f, origin), Vector2.up,0.01f);

        RightHit = Physics2D.Raycast(transform.position + new Vector3(origin, 0f), Vector2.right,0.01f);
        LeftHit = Physics2D.Raycast(transform.position - new Vector3(origin, 0f), Vector2.left,0.01f);
    }
    public void DestroyPlayer(RaycastHit2D hit)
    {
        if(hit.collider !=null)
        {
            if (hit.collider.tag == "Player")
            {
                if (player.hasPowerUp == false)
                {
                    playerRB.velocity = new Vector2(playerRB.velocity.x, 5f);
                    Destroy(Player.GetComponent<player>());
                    Destroy(Player.GetComponent<BoxCollider2D>());
                    Destroy(Camera.main.GetComponent<cameraFollow>());
                }
                else
                {
                    playerRB.velocity = new Vector2(playerRB.velocity.x, 10f);
                    StartCoroutine(noPowerUp());
                }

            }
        }
    }
    public static IEnumerator noPowerUp()
    {
        for(int i = 0; i < 90; i++)
        {
            PowerUpSprite.SetActive(false);
            NormalSprite.SetActive(i % 3 == 0);
            yield return new WaitForSeconds(3/90);
        }
        player.hasPowerUp = false;
        NormalSprite.SetActive(true);
    }
}



























































































// hit = Physics2D.Raycast(transform.position+ new Vector3(0f, origin), Vector2.up, 0.01f);
// hit2 = Physics2D.Raycast(transform.position + new Vector3(origin-0.2f, origin), Vector2.up, 0.01f);
// hit3 = Physics2D.Raycast(transform.position - new Vector3(origin - 0.2f, 0f)+new Vector3(0f,origin), Vector2.up, 0.01f);
