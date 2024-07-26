using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public Button rockButton;
    public Button paperButton;
    public Button scissorsButton;
    public Button shootButton;
    public Button replayButton;
    public TMP_Text resultText;

    private enum Choice { Rock, Paper, Scissors, None }
    private Choice playerChoice = Choice.None;
    private Choice computerChoice = Choice.None;

    private void Start()
    {
        rockButton.onClick.AddListener(() => PlayerMakesChoice(Choice.Rock));
        paperButton.onClick.AddListener(() => PlayerMakesChoice(Choice.Paper));
        scissorsButton.onClick.AddListener(() => PlayerMakesChoice(Choice.Scissors));
        shootButton.onClick.AddListener(() => DetermineWinner());
        replayButton.onClick.AddListener(ResetGame);
        replayButton.gameObject.SetActive(false);
    }

    private void PlayerMakesChoice(Choice choice)
    {
        playerChoice = choice;
        resultText.text = "Player chose: " + choice;
    }

    private void DetermineWinner()
    {
        if (playerChoice == Choice.None) return;

        computerChoice = (Choice)Random.Range(0, 3);
        resultText.text += "\nComputer chose: " + computerChoice;

        string result;
        if (playerChoice == computerChoice)
        {
            result = "It's a tie!";
        }
        else if ((playerChoice == Choice.Rock && computerChoice == Choice.Scissors) ||
                 (playerChoice == Choice.Scissors && computerChoice == Choice.Paper) ||
                 (playerChoice == Choice.Paper && computerChoice == Choice.Rock))
        {
            result = "Player wins!";
        }
        else
        {
            result = "Computer wins!";
        }

        resultText.text += "\nResult: " + result;
        replayButton.gameObject.SetActive(true);
        shootButton.interactable = false;
        shootButton.interactable = false;
        rockButton.interactable = false;
        paperButton.interactable = false;
        scissorsButton.interactable = false;
    }

    private void ResetGame()
    {
        playerChoice = Choice.None;
        computerChoice = Choice.None;
        resultText.text = "";
        replayButton.gameObject.SetActive(false);
        shootButton.interactable = true;
        rockButton.interactable = true;
        paperButton.interactable = true;
        scissorsButton.interactable = true;
    }
}
