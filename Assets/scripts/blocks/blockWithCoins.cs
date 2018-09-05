using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class blockWithCoins : MonoBehaviour {
    player player;
    RaycastHit2D down;
    float origin;
    float allCoins=5;
    public GameObject spriteCoin;
    public GameObject coinAdd;
    // Use this for initialization
    void Start()
    {
        origin = (GetComponent<BoxCollider2D>().size.x / 2) + 0.1f;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
    }

    // Update is called once per frame
    void Update () {
        down = Physics2D.Raycast(transform.position - new Vector3(0f, origin), Vector2.down, 0.01f);
        if (down.collider != null)
        {
            if (down.collider.tag == "Player")
            {
                
                down.collider.GetComponent<Rigidbody2D>().velocity *= new Vector2(1, -1);
                if (allCoins > 1)
                {
                    coinAdd.SetActive(true);
                    player.coinNB++;
                    player.coinTxt.text = "coins : " + player.coinNB;
                    allCoins--;
                }
                else
                    Destroy(spriteCoin);

            }
        }
        else
            coinAdd.SetActive(false);
    }
}
