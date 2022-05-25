
using UnityEngine;

public class IdleState : BaseState
{
	GameManager gameManager;
	public override void EnterState(PlayerController playerController) {
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}


	public override void UpdateState(PlayerController playerController) { }


	public override void OnTriggerEnter(PlayerController playerController, Collider2D other) {

		if (other.gameObject.tag == "Enemy")
		{
			Debug.Log("Damage");
			gameManager.RestartScene();
		}



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
