using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool playerOneEscaped = false;
    public bool playerTwoEscaped = false;

    [SerializeField] string nextLevelSceneName;

    public void PlayerAtEscape(int player)
    {
        print("here");
        if(player == 1) playerOneEscaped = true;
        else if(player == 2) playerTwoEscaped = true;

        if(playerOneEscaped && playerTwoEscaped)
        {
            SwitchLevel();
        }
    }

    public void PlayerLeaveEscape(int player)
    {
        if (player == 1) playerOneEscaped = false;
        else if (player == 2) playerTwoEscaped = false;
    }

    private void SwitchLevel()
    {
        print("Escaped!");
        SceneManager.LoadScene(nextLevelSceneName);
    }

}
