using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthCountDown : MonoBehaviour
{
    // Start is called before the first frame update

    public float totalHealth;
    public float removeEachFrame;
    public float foodHeal;
    public HealthBar healthbar;
    public ItemListUI list;
    public ItemInfo food;
    public GameObject top;
    public float runningSpeed;
    float normalSpeed;
    public TopDownCharacterMover move;

    private float maxHealth;

    void Start()
    {
        
        normalSpeed = move.getSpeed();
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

    private void death()
    {
        SceneManager.LoadScene("DeathScene");
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

        if(Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log("shift");
            totalHealth -= 10 * Time.deltaTime;
            move.setSpeed(runningSpeed);

        }
        else
        {
            move.setSpeed(normalSpeed);
        }

        if(top.transform.position.y <= 7.8f)
        {
            totalHealth -= 100 * Time.deltaTime;
        }

        if(totalHealth <= 0)
        {
            death();
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.gameObject.CompareTag("Enemy"))
        {
            death();
        }
    }
}
