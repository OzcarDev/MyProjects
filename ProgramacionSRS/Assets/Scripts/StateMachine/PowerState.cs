
using UnityEngine;

public class PowerState : BaseState
{
	float contador = 5;
	public override void EnterState(PlayerController playerController) {
		
		playerController.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
		Debug.Log("Power");
	
	}
	
    public override void UpdateState(PlayerController playerController) {

		contador -= Time.deltaTime;

        if (contador <= 0)
        {
			playerController.SwitchState(playerController.idleState);
        }
	}


    public override void OnTriggerEnter(PlayerController playerController, Collider2D other) {

		if (other.gameObject.tag == "Enemy")
		{
			playerController.DestroyOther(other.gameObject);
		}

        if (other.gameObject.tag == "Time")
        {
			playerController.gameManager.time += 10;
        }
	}

	public override void OnCollisionEnter(PlayerController playerController, Collision2D col)
	{
		Debug.Log("Col");
		if (col.gameObject.tag == "MobilePlatform")
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
