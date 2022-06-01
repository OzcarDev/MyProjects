using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
	GameManager gameManager;
	PlayerController player;
	public override void EnterState(PlayerController playerController) {
		player = playerController;
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		playerController.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
	}


	public override void UpdateState(PlayerController playerController) { }


	public override void OnTriggerEnter(PlayerController playerController, Collider2D other) {

		if (other.gameObject.tag == "Enemy")
		{
			Debug.Log("Damage");
			player.StartCoroutine(DeadSecuency());
			
		}

		if (other.gameObject.tag == "Power")
        {
			Debug.Log("ChangingPower");
			
			playerController.SwitchState(playerController.powerState);
        }


	}

	IEnumerator DeadSecuency()
    {
		player.deadSound.Play();
		player.deadAnimation.Play("Idle");

		yield return new WaitForSeconds(1.5f);
		gameManager.RestartScene();
	}

	public override void OnCollisionEnter(PlayerController playerController, Collision2D col)
	{
		Debug.Log("Col");
		if(col.gameObject.tag == "MobilePlatform")
		{
			playerController.transform.parent = col.transform;
		}
	}

	public override void OnCollisionExit(PlayerController playerController, Collision2D col)
	{
		if (col.gameObject.tag == "MobilePlatform")
		{
			playerController.transform.parent = null;
		}
	}
}
