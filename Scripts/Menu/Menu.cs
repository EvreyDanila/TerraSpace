using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class Menu : MonoBehaviour
{
    public Button continueGame;

    public Save save;

    private void Start()
    {   
        TextMeshProUGUI tmproContinueGame = continueGame.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        continueGame.interactable = false;
        tmproContinueGame.color = Color.gray;

        if (PlayerPrefs.HasKey("Continue"))
        {
            if (PlayerPrefs.GetInt("Continue") == 1)
            {
                continueGame.interactable = true;
                tmproContinueGame.color = Color.white;
            }
        }
    }
    
    public void NewGame()
    {
        save.SavesDestroy();
        PlayerPrefs.SetInt("Continue", 1);
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }
}