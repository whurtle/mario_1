using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
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
        MouseClick();   
    }

    private void MouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                HandleHit(hit.collider);
            }
        }
    }

    private void HandleHit(Collider collider)
    {
        switch (collider?.gameObject?.tag)
        {
            case "Brick":
                Destroy(collider.gameObject);
                AddScore(100);
                break;
            case "Question":
                AddCoins(1);
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
        if(currCoins == 99)
        {
            return;
        } else
        {
            coins.text = "0x" + (currCoins + coin).ToString().PadLeft(2, '0');
        }
    }
}
