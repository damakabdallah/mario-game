using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IsPlayerDead : MonoBehaviour {

    public GameObject GameOver;
    player Player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Player = GetComponent<player>();
        if (Player == null)
        {
            GameOver.SetActive(true);
            StartCoroutine(Restart());

        }
    }
    IEnumerator Restart()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }
}
