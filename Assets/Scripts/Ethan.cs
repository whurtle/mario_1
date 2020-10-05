using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ethan : MonoBehaviour
{
    public Text coins;
    public Text scoreBoard;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            HandleHit(collision.gameObject);
        }
    }

    public void HandleHit(GameObject gameObject)
    {
        switch (gameObject?.tag)
        {
            case "Brick":
                Destroy(gameObject);
                AddScore(100);
                break;
            case "Lava":
                GameOver();
                break;
            case "Coin":
                Destroy(gameObject);
                AddScore(100);
                AddCoins(1);
                break;
            case "Pole":
                Win();
                break;
            default:
                break;
        }
    }
    private void AddScore(int score)
    {
        int currScore = int.Parse(scoreBoard.text);
        scoreBoard.text = (currScore + score).ToString().PadLeft(6, '0');
    }
    private void AddCoins(int coin)
    {
        int currCoins = int.Parse(coins.text.Substring(2));
        if (currCoins == 99)
        {
            return;
        }
        else
        {
            coins.text = "0x" + (currCoins + coin).ToString().PadLeft(2, '0');
        }
    }

    private void GameOver()
    {
        Debug.Log("GAME OVER!");
    }

    private void Win()
    {
        Debug.Log("You win, unfortunately the princess is in another castle");
    }
}
