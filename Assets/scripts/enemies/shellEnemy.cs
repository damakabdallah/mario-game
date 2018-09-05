using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shellEnemy : enemy {

    bool isMoving=true;
	// Use this for initialization
	void Start () {
        initalisation();
	}
	
	// Update is called once per frame
	void Update () {
        createHits();
        realEnemyMoving();
        stopOrMove();
    }
    void realEnemyMoving()
    {
        if (isMoving)
        {
            enemyMoving();
            DestroyPlayer(RightHit);
            DestroyPlayer(LeftHit);
            changeDirection(RightHit);
            changeDirection(LeftHit);
        }
        else
        {
            enemyRB.velocity = Vector2.zero;
            if (RightHit.collider != null)
                if (RightHit.collider.tag == "Player")
                {
                    direction = -1;
                    transform.Translate(-0.5f, 0, 0);
                    isMoving = true;
                }
            if (LeftHit.collider != null)
                if (LeftHit.collider.tag == "Player")
                {
                    direction = 1;
                    transform.Translate(0.5f, 0, 0);
                    isMoving = true;
                }
        }


    }
    void stopOrMove()
    {
        if (UpHit.collider != null|| UpHit2.collider != null || UpHit3.collider != null)
        {
                playerRB.velocity = new Vector2(playerRB.velocity.x, 5f);
                isMoving = !isMoving;
        }
    }
    void changeDirection(RaycastHit2D hit)
    {
        if (hit.collider != null)
        {
            if (hit.collider.tag == "obstacle" || hit.collider.tag == gameObject.tag)
            {
                direction *= -1;
                transform.Translate(direction * 0.5f, 0, 0);
            }
            else
                if (hit.collider.tag == "Player")
                    DestroyPlayer(hit);
                else
                    Destroy(hit.collider.gameObject);
        }
    }
}
