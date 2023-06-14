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

        if (save.IsSaveGame())
        {
            continueGame.interactable = true;
            tmproContinueGame.color = Color.white;
        }
        else
        {
            continueGame.interactable = false;
            tmproContinueGame.color = Color.gray;
        }
    }
    
    public void NewGame()
    {
        save.SavesDestroy();
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }
}