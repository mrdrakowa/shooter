using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class boots : MonoBehaviour
{
    public float cooldown;
    public bool IsCooldown;

    private Image bootsImage;
    private Player1 player;

    // Start is called before the first frame update
    void Start()
    {
        IsCooldown = true;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player1>();
        bootsImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsCooldown)
        {
            bootsImage.fillAmount -= 1 / cooldown * Time.deltaTime;
            player.speed = 16;
            if (bootsImage.fillAmount <= 0)
            {
                player.speed = 7;
                bootsImage.fillAmount = 1;
                IsCooldown = false;
                player.boots.SetActive(false);
                player.boot2.SetActive(false);
                gameObject.SetActive(false);
            }
        }

    }

    public void ResetTime()
    {
        bootsImage.fillAmount = 1;
    }
}
