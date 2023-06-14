using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

public class Player : MonoBehaviour
{
    public float terraform = 0f;
    public float energy = 50f;
    public float resource = 50f;
    public float mechanism = 50f;
    public int people = 50;

    public Image imgEnergy;
    public Image imgResource;
    public Image imgMechanism;
    public Image imgTerraform;
    public Image imgPeople;

    public Save save;

    private void Start()
    {
        terraform = 0f;
        energy = 50f;
        resource = 50f;
        mechanism = 50f;
        people = 50;

        imgEnergy = GameObject.FindGameObjectWithTag("imgEnergy").GetComponent<Image>();
        imgResource = GameObject.FindGameObjectWithTag("imgResource").GetComponent<Image>();
        imgMechanism = GameObject.FindGameObjectWithTag("imgMechanism").GetComponent<Image>();
        imgTerraform = GameObject.FindGameObjectWithTag("imgTerraform").GetComponent<Image>();
        imgPeople = GameObject.FindGameObjectWithTag("imgPeople").GetComponent<Image>();

        Load();
        UpdateImage();
    }

    private void Load()
    {
        save.LoadGame();

        terraform = save.terraform;
        energy = save.energy;
        resource = save.resource;
        mechanism = save.mechanism;
        people = save.people;
    }

    public void UpdateImage()
    {
        imgEnergy = GameObject.FindGameObjectWithTag("imgEnergy").GetComponent<Image>();
        imgResource = GameObject.FindGameObjectWithTag("imgResource").GetComponent<Image>();
        imgMechanism = GameObject.FindGameObjectWithTag("imgMechanism").GetComponent<Image>();
        imgTerraform = GameObject.FindGameObjectWithTag("imgTerraform").GetComponent<Image>();
        imgPeople = GameObject.FindGameObjectWithTag("imgPeople").GetComponent<Image>();

        StartCoroutine(ImgSmoothly(imgEnergy, energy));
        StartCoroutine(ImgSmoothly(imgResource, resource));
        StartCoroutine(ImgSmoothly(imgMechanism, mechanism));
        StartCoroutine(ImgSmoothly(imgTerraform, terraform));
        StartCoroutine(ImgSmoothly(imgPeople, people * 2));
    }

    private IEnumerator ImgSmoothly(Image img, float howFill)
    {
        WaitForEndOfFrame wait = new();
        var fillNow = img.fillAmount;
        howFill /= 100f;

        if (fillNow - howFill > 0)
        {
            while (fillNow - howFill > 0)
            {
                img.fillAmount = fillNow;
                fillNow -= 0.1f;
                yield return wait;
            }
        }
        else
        {
            while (fillNow - howFill < 0)
            {
                img.fillAmount = fillNow;
                fillNow += 0.1f;
                yield return wait;
            }
        }
        img.fillAmount = howFill;
    }

    public void StatsDifferenceLeft(CardsItemScriptableObj card)
    {
        terraform += card.terraformDif.leftResp;
        mechanism += card.mechanismDif.leftResp;
        resource += card.resourceDif.leftResp;
        energy += card.energyDif.leftResp;
        people += card.peopleDif.leftResp;
        UpdateImage();

        CheckIsMaxValues();
    }

    public void StatsDifferenceRight(CardsItemScriptableObj card)
    {
        terraform += card.terraformDif.rightResp;
        mechanism += card.mechanismDif.rightResp;
        resource += card.resourceDif.rightResp;
        energy += card.energyDif.rightResp;
        people += card.peopleDif.rightResp;
        UpdateImage();

        CheckIsMaxValues();
    }

    private void CheckIsMaxValues()
    {
        if (mechanism >= 100) mechanism = 100f;
        if (resource >= 100) resource = 100f;
        if (energy >= 100) energy = 100f;
        if (people >= 50) people = 50;

        if (terraform >= 100)
        {
            terraform = 100f;
            EventsManager.OnGameOverWin();
        }

        if (mechanism <= 0)
        {
            mechanism = 0f;
            EventsManager.OnGameOverLose();
        }

        if (resource <= 0)
        {
            resource = 0f;
            EventsManager.OnGameOverLose();
        }

        if (energy <= 0)
        {
            energy = 0f;  
            EventsManager.OnGameOverLose();
        }

        if (people <= 0)
        {
            people = 0;
            EventsManager.OnGameOverLose();
        }
    }
}