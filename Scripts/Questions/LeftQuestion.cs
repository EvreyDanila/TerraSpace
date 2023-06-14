using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LeftQuestion : MonoBehaviour
{
    public TextMeshProUGUI textQuestion;

    private void Start()
    {
        EventsManager.LeftSwipeCard += Show;
        EventsManager.MidlePointerCard += Back;
        EventsManager.UseCard += UseCardBack;
    }

    public void Show()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void Back()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    public void UseCardBack(string _)
    {
        Back();
    }
}