using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    public GameObject panelEndGameLose;
    public GameObject panelEndGameWin;
    public Save save;

    void Start()
    {
        EventsManager.GameOverLose += EndGameLose;
        EventsManager.GameOverWin += EndGameWin;

        panelEndGameWin = GameObject.FindGameObjectWithTag("panelEndGameWin").transform.GetChild(0).gameObject;
        panelEndGameLose = GameObject.FindGameObjectWithTag("panelEndGameLose").transform.GetChild(0).gameObject;

        save = GameObject.FindGameObjectWithTag("Save").GetComponent<Save>();
    }

    public void EndGameLose()
    {
        save = GameObject.FindGameObjectWithTag("Save").GetComponent<Save>();
        save.SavesDestroy();
        panelEndGameWin = GameObject.FindGameObjectWithTag("panelEndGameWin").transform.GetChild(0).gameObject;
        panelEndGameLose = GameObject.FindGameObjectWithTag("panelEndGameLose").transform.GetChild(0).gameObject;
        panelEndGameWin.SetActive(false);
        panelEndGameLose.SetActive(true);
    }

    public void EndGameWin()
    {
        save = GameObject.FindGameObjectWithTag("Save").GetComponent<Save>();
        save.SavesDestroy();
        panelEndGameWin = GameObject.FindGameObjectWithTag("panelEndGameWin").transform.GetChild(0).gameObject;
        panelEndGameLose = GameObject.FindGameObjectWithTag("panelEndGameLose").transform.GetChild(0).gameObject;
        panelEndGameLose.SetActive(false);
        panelEndGameWin.SetActive(true);
    }

    public void LoadSceneMenu()
    {
        save.SavesDestroy();
        SceneManager.LoadScene("menu", LoadSceneMode.Single);
    }
}