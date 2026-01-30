using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool playerOneEscaped = false;
    public bool playerTwoEscaped = false;

    [SerializeField] string nextLevelSceneName;

    public void PlayerEscape(int player)
    {
        print("here");
        if(player == 1) playerOneEscaped = true;
        else if(player == 2) playerTwoEscaped = true;

        if(playerOneEscaped && playerTwoEscaped)
        {
            SwitchLevel();
        }
    }

    private void SwitchLevel()
    {
        print("Escaped!");
        SceneManager.LoadScene(nextLevelSceneName);
    }

}
