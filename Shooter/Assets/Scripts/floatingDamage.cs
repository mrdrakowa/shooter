using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatingDamage : MonoBehaviour
{
    public float damage;
    public TextMesh textMesh;
    void Start()
    {
        textMesh = GetComponent<TextMesh>();
        textMesh.text = "-" + damage;
    }
    private void OnAnimatorOver()
    {
       Destroy(gameObject);
    }
}
