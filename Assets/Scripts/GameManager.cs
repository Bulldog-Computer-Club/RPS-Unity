using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text title;
    public Text playerChoiceLabel;
    public Text aiChoiceLabel;
    public GameObject aiChoiceSprite;
    public bool troll = false;

    private bool wasClicked = false;
    private string playerChoice;
    private string outcome;
    private string weaponChoice;
    private (string, string)[] counters = {("Rock", "Scissors"), ("Scissors", "Paper"), ("Paper", "Rock")};

    public void MainRPS(string choice)
    {
        playerChoice = choice;
        title.GetComponent<Animator>().SetTrigger("Fadeout");
        if(troll) TrollGame();
        if(!troll) NormalGame();
    }

    private void TrollGame()
    {

    }

    private void NormalGame()
    {
        float rOutcome = Mathf.Round(UnityEngine.Random.value * 2.49f);

        switch (rOutcome)
        {
            case 0:
                outcome = "Tie.";
                weaponChoice = playerChoice;
                break;
            case 1:
                outcome = "Win!";
                weaponChoice = Array.Find(counters, c => c.Item1 == playerChoice).Item2;
                break;
            case 2:
                outcome = "Lose :/";
                weaponChoice = Array.Find(counters, c => c.Item2 == playerChoice).Item1;
                break;
            default:
                Debug.Log("ERROR - Out of bounds");
                break;
        }

        playerChoiceLabel.text = playerChoice;
        playerChoiceLabel.GetComponent<Animator>().SetTrigger("Fadein");
        Invoke("UIUpdate", 1f);

        Debug.Log(outcome);
        Debug.Log(weaponChoice);
    }

    private void UIUpdate()
    {
        aiChoiceSprite.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>($"{weaponChoice}-rps");
        aiChoiceSprite.GetComponent<Animator>().SetTrigger("Fadein");
        aiChoiceLabel.text = weaponChoice;
        aiChoiceLabel.GetComponent<Animator>().SetTrigger("Fadein");
        title.text = outcome;
        Invoke("UpdateTitle", 1f);
    }

    private void UpdateTitle()
    {
        title.GetComponent<Animator>().SetTrigger("Fadein");
    }
    
    // Get - Set

    public bool getWasClicked()
    {
        return wasClicked;
    }

    public void setWasClicked(bool newBool)
    {
        wasClicked = newBool;
    }
}
