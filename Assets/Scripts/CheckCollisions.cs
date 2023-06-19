using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using TMPro;

public class CheckCollisions : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI coinText;
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Coin"))
        {
            //Destroy(other.gameObject);
            AddCoin();
            other.gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Ayvayý yedin.");
        }
    }

    public void AddCoin()
    {
        score++;
        coinText.text = "Score: " + score.ToString();
    }
}
