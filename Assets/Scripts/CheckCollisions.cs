using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using TMPro;

public class CheckCollisions : MonoBehaviour
{
    public int score;
    public Transform startPosition;
    public TextMeshProUGUI coinText;
    public GameObject speedBoostIcon;
                    


    PlayerController playerController;
                                
    void Start()
    {
        transform.position = startPosition.position;
        playerController = GetComponent<PlayerController>();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Coin"))
        {
            //Destroy(other.gameObject);
            AddCoin();
            other.gameObject.SetActive(false);
        }
        else if (other.CompareTag("SpeedBoost"))
        {
            StartCoroutine(SpeedBoostSequence());
        }
        else if (other.CompareTag("Bumper"))
        {
            StartCoroutine(BumperSequence());
        }
        else if (other.CompareTag("FinishPoint"))
        {
            playerController.Animator.SetBool("isRunning", false);
            playerController._runSpeed = 0;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            transform.position = startPosition.position;
        }
    }

    

    public void AddCoin()
    {
        score++;
        coinText.text = "Score: " + score.ToString();
    }

    IEnumerator SpeedBoostSequence()
    {
        playerController._runSpeed = 8;
        speedBoostIcon.SetActive(true);
        yield return new WaitForSeconds(4);
        playerController._runSpeed = 5;
        speedBoostIcon.SetActive(false);
    }

    IEnumerator BumperSequence()
    {
        playerController._runSpeed = 3;
        yield return new WaitForSeconds(4);
        playerController._runSpeed = 5;
    }
}
