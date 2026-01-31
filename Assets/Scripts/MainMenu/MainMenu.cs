using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //loads game scene
    public void loadGame()
    {
        Debug.Log("Play Game button clicked");
        SceneManager.LoadScene(1);//game scene

    }


    //quits the game
    public void quitGame()
    {
        Debug.Log("Quit Game button clicked");
        Application.Quit();
    }
}
