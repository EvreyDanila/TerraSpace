using UnityEngine;
using UnityEngine.UI;


public class Stars : MonoBehaviour
{
    public Sprite[] starsImgs;

    public float speed;

    private void Start()
    {
        
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform item = transform.GetChild(i);
            item.GetComponent<Image>().sprite = GetRandomStarImg();
        }
    }

    void Update()
    {
        transform.Rotate(0, 0, speed);
    }


    private Sprite GetRandomStarImg()
    {
        System.Random rand = new System.Random();
        return starsImgs[rand.Next(0, starsImgs.Length - 1)];
    }
}
