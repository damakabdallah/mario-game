using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turtleEnemy : enemy {
    public GameObject shell;
    int numberOfSons = 0;

    // Use this for initialization
    void Start ()
    {
        initalisation();
	}
	
	// Update is called once per frame
	void Update ()
    {
        enemyMoving();
        createHits();
        DestroyPlayer(RightHit);
        DestroyPlayer(LeftHit);
        enterTheShell();
    }
    private void enterTheShell()
    {
        whatHit(UpHit);
        whatHit(UpHit2);
        whatHit(UpHit3);
    }
    private void whatHit(RaycastHit2D hit2D)
    {
        if (hit2D.collider != null)
        {
            if (UpHit.collider.tag == "Player" && numberOfSons ==0)
            {
                numberOfSons++;
                playerRB.velocity = new Vector2(playerRB.velocity.x, 5f);
                Instantiate(shell, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "ground")
            direction *= -1;
    }
   
}
