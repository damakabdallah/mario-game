using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normalEnemy : enemy {

	// Use this for initialization
	void Start () {
        initalisation();
	}
	
	// Update is called once per frame
	void Update () {
        enemyMoving();
        createHits();
        DestroyPlayer(RightHit);
        DestroyPlayer(LeftHit);
        die();
	}
    private void die()
    {
        if(UpHit.collider!= null || UpHit2.collider != null || UpHit3.collider != null)
        {
            if (UpHit.collider.tag == "Player" || UpHit2.collider.tag == "Player" || UpHit3.collider.tag == "Player")
            {
                playerRB.velocity = new Vector2(playerRB.velocity.x, 5f);
                Destroy(gameObject);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "ground")
           direction *= -1;
    }
}
