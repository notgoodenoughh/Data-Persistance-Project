using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDataUI : MonoBehaviour
{
    public TMP_Text highscoreText;
    public TMP_InputField inputField;

    private PlayerPersistance.PlayerData playerData;

    private void Start()
    {
        playerData = PlayerPersistance.Instance.LoadData();
        if (playerData != null )
        {
            inputField.text = playerData.name;
            highscoreText.text = "Best Score - " + playerData.name + ": " + playerData.highscore.ToString();
        }
        else
        {
            highscoreText.text = "Best Score - " + "no player" + ": " + "0";
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        PlayerPersistance.Instance.playerName = inputField.text;
    }
}