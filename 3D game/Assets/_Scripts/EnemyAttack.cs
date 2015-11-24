using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

    public GameObject Player;
    public GameObject Enemy;
    public float distance;
    public PlayerAttributes attributes;
    
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Player = GameObject.Find("Player");
        Enemy = GameObject.FindWithTag("Enemy");
        distance = Vector3.Distance(Player.transform.position, Enemy.transform.position);
        if (distance <= 3.5)
        {
            Enemy.GetComponent<Animation>().CrossFadeQueued("run",0.3f,QueueMode.PlayNow);
            Enemy.GetComponent<Animation>().CrossFade("attack_1");
            attributes.ApplyDamage(1);
            attributes.playerInCombat(1);
        }
        else if(distance <= 15 && distance > 3.5 ){
            Enemy.GetComponent<Animation>().CrossFadeQueued("attack_1", 0.3f, QueueMode.PlayNow);
            Enemy.GetComponent<Animation>().CrossFade("run");
            Enemy.transform.LookAt(Player.transform.position);
            Enemy.transform.position = Vector3.MoveTowards(Enemy.transform.position,Player.transform.position,0.3f);
            attributes.playerInCombat(0);
        }
        else
        {
            Enemy.GetComponent<Animation>().CrossFadeQueued("run", 0.3f, QueueMode.PlayNow);
            Enemy.GetComponent<Animation>().CrossFade("idle");
            attributes.playerInCombat(0);
        }
	}
}
