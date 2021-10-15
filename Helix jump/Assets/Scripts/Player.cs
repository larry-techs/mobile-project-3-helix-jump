using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody playerRB;
    public float bounceForce = 6;

    private AudioManager audioManager;


    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }


    void OnCollisionEnter (Collision collision)
    {
        audioManager.Play("bounce");
        playerRB.velocity = new Vector3(playerRB.velocity.x, bounceForce, playerRB.velocity.z);

        string materialName = collision.transform.GetComponent<MeshRenderer>().material.name;

            if (materialName == "Safe (Instance)")
              {
                //ball safe;
              }
            else if (materialName == "Unsafe (Instance)")
              {
              audioManager.Play("game over");
                GameManager.gameOver = true;
                Debug.Log("Game Over");
              }
           else if (materialName == "Last Ring (Instance)" && !GameManager.levelCompleted)
              {
               audioManager.Play("won");
               GameManager.levelCompleted = true;
               Debug.Log("Level Completed");
              }

    }
    
}
