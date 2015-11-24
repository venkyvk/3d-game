using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {

    public GameObject Player;
	// Use this for initialization
	void Start () {
        Player.GetComponent<Animation>().Play("idle");
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Space)){
            Player.GetComponent<Animation>().Play("jump");
        }
	}
}
