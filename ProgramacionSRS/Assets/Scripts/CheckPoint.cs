using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckPoint : MonoBehaviour
{
    public int num;
    TMP_Text text;
     void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("HOLA");

        if(other.gameObject.tag == "Player")
        {
          text =  other.gameObject.GetComponentInChildren<TMP_Text>();
            
            text.text = "Checkpoint" + num;
            text.gameObject.GetComponent<Animator>().Play("ShowText");
            

        }
    }


}
