using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(1000)]
public class MenuUIManager : MonoBehaviour
{
    public TMP_InputField playerNameInput;
    private string playerName;

    public void StartGame()
    {
        playerName = playerNameInput.text;
        if (playerName == "")
        {
            // TODO Message about required name
            return;
        }

        StaticDataManager.Instance.PlayerName = playerName;
        SceneManager.LoadScene(1);
    }
}
