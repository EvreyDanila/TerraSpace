using UnityEngine;
using UnityEngine.EventSystems;

public class MoveCard : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public float speed = 100f;
    public int padingMidle = 300;

    public GameObject rightRequest;
    public GameObject leftRequest;


    private Vector3 startSpritePoint;

    private void Start()
    {
        startSpritePoint = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        var toucnMouse = Input.mousePosition;
        transform.position = Vector3.Lerp(transform.position, new Vector3(toucnMouse.x, transform.position.y, transform.position.z), Time.deltaTime * 5f);
        if (transform.position.x <= (Screen.width / 2) - padingMidle)
        {
            leftRequest.SetActive(true);
        }
        else if (transform.position.x >= (Screen.width / 2) + padingMidle)
        {
            rightRequest.SetActive(true);
        }
        else
        {
            rightRequest.SetActive(false);
            leftRequest.SetActive(false);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        rightRequest.SetActive(false);
        leftRequest.SetActive(false);

        if (transform.position.x <= (Screen.width / 2) - padingMidle)
        {
            EventsManager.OnUseCard("Left");
        }
        else if (transform.position.x >= (Screen.width / 2) + padingMidle)
        {
            EventsManager.OnUseCard("Right");
        }
        transform.position = startSpritePoint;
        EventsManager.OnMidlePointerCard();
    }
}