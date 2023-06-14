using UnityEngine;
using UnityEngine.UI;

public class SetSettings : MonoBehaviour
{
    public Save save;

    public Slider sliderAudio;
    public Transform graphicTogles;

    public int quality;
    public float volume;

    private void Start()
    {
        Load();
        SetParameters();
    }

    public void Load()
    {
        save.LoadSettings();
        quality = save.quality;
        volume = save.volume;
    }

    public void SetParameters()
    {
        sliderAudio.value = volume;
        for (int i = 0; i < graphicTogles.childCount; i++)
        {
            if(i * 2 == quality) graphicTogles.GetChild(i).GetComponent<Toggle>().isOn = true;
        }
    }
}
