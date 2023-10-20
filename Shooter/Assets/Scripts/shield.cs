using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shield : MonoBehaviour
{
    // Start is called before the first frame update
    public float cooldown;
    public bool isCooldown;

    private Image shieldImage;
    private Player1 player;
    void Start()
    {
        shieldImage = GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player1>();
        isCooldown = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isCooldown)
        {
            shieldImage.fillAmount -= 1/cooldown *Time.deltaTime;
            if(shieldImage.fillAmount <= 0 )
            {
                shieldImage.fillAmount = 1;
                isCooldown=false;
                player.shield.SetActive(false);
                gameObject.SetActive(false);
            }
        }
        
    }
    public void ResetTimer()
    {
        shieldImage.fillAmount = 1;
    }
}
