using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float health;
    public float maxHealth = 100;
    public Slider slider;
    public Image fill;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        slider = this.gameObject.GetComponentInChildren<Slider>();
        fill = slider.GetComponentInChildren<Image>();
        slider.maxValue = maxHealth;
        slider.value = health;
        fill.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
            Destroy(this.gameObject);
        else
        {
            slider.value = health;
            fill.color = new Color(1-health / maxHealth, health/maxHealth, 0, 1);
        }
    }
}
