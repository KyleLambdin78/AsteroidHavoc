using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DamageManager : MonoBehaviour
{
    public GameObject damagedGlass;
    public Text Health;
    public float currHealth;
    void Start()
    {
        Health.text = "Health" + currHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        currHealth -= 1;
        Health.text = "Health" + "  " + currHealth;

        if (currHealth <= 1)
        {
            damagedGlass.SetActive(true);
        }
        if (currHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
