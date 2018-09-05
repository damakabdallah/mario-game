using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normalBlock : MonoBehaviour {
    RaycastHit2D down;
    float origin;
	// Use this for initialization
	void Start () {
        origin = (GetComponent<BoxCollider2D>().size.x / 2) + 0.1f;
    }

    // Update is called once per frame
    void Update () {
        down = Physics2D.Raycast(transform.position - new Vector3(0f, origin), Vector2.down, 0.01f);
        if (down.collider != null)
            if (down.collider.tag == "Player")
            {
                down.collider.GetComponent<Rigidbody2D>().velocity *= new Vector2(1, -1);
                Destroy(gameObject);

            }
	}
}
