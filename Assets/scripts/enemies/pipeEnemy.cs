using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pipeEnemy : MonoBehaviour {
    
    Transform target;
    public Transform target1;
    public Transform target2;
    float length=5;


	// Use this for initialization
	void Start () {
        target = target1;
        StartCoroutine(changeDirection());
       // GameOver = GameObject.FindGameObjectWithTag("game over");
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, target.position, length * Time.deltaTime);
        
    }
    IEnumerator changeDirection()
    {
        yield return new WaitForSeconds(3);
        if (transform.position == target.position)
        {
            if (target == target1)
                target = target2;
            else
                target = target1;
        }
        StartCoroutine(changeDirection());
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D playerRB = collision.gameObject.GetComponent<Rigidbody2D>();
        if (collision.gameObject.tag == "Player" && player.hasPowerUp == false)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(collision.gameObject.GetComponent<Rigidbody2D>().velocity.x, 5f);
            Destroy(collision.gameObject.GetComponent<BoxCollider2D>());
            Destroy(collision.gameObject.GetComponent<player>());
            Destroy(GameObject.Find("Main Camera").GetComponent<cameraFollow>());
        }
        else
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, 10f);
            StartCoroutine(enemy.noPowerUp());
        }
    }

}
