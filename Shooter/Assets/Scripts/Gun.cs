using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float offset;
    public GameObject bullet;
    public Transform shotPoint;

    public Joystick joystick;

    private float timeBtwShots;
    public float startTimeBtwShots;

    private float rotZ;
    private Vector3 difference;
    private Player1 player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player1>();
        if(player.controlType == Player1.ControlType.PC)
        {
            joystick.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.controlType == Player1.ControlType.PC)
        {
            Vector3 diffetence = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rotZ = Mathf.Atan2(diffetence.y, diffetence.x) * Mathf.Rad2Deg;
        }
        else if(player.controlType == Player1.ControlType.Android)
        {
            rotZ = Mathf.Atan2(joystick.Vertical, joystick.Horizontal) * Mathf.Rad2Deg;
        }


        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if (timeBtwShots <= 0)
        {
            if (player.controlType == Player1.ControlType.PC)
            {
                if(Input.GetMouseButton(0))
                Shoot();
            }
            else if (player.controlType == Player1.ControlType.Android)
            {
                if (joystick.Vertical != 0 || joystick.Horizontal != 0) 
                {
                    Shoot();
                }
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

    }
    public void Shoot()
    {
        Instantiate(bullet, shotPoint.position, transform.rotation);
        timeBtwShots = startTimeBtwShots;
    }
}
