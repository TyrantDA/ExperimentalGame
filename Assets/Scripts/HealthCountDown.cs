using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCountDown : MonoBehaviour
{
    // Start is called before the first frame update

    public float totalHealth;
    public float removeEachFrame;
    public float foodHeal;
    public HealthBar healthbar;
    public ItemListUI list;
    public ItemInfo food;

    private float maxHealth;

    void Start()
    {
        maxHealth = totalHealth;
        healthbar.SetMaxHealth(maxHealth);

        StartCoroutine(HealthDeacreaser());
    }

    private void OnDisable()
    {
        StopCoroutine(HealthDeacreaser());
    }

    private void OnEnable()
    {
        StartCoroutine(HealthDeacreaser());
    }

    private IEnumerator HealthDeacreaser()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();
            totalHealth -= (removeEachFrame * Time.deltaTime);
            healthbar.SetHealth(totalHealth);
        }
    }

    private void AddHealth()
    {
        if (totalHealth < maxHealth)
        {
            totalHealth += foodHeal;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (list.HasItem(food) == 0)
            {
                Debug.Log("not food");
            }
            else
            {
                AddHealth();
                list.AddItem(food, -1);
            }
        }
    }
}
