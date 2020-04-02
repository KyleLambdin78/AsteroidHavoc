using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DamageManager : MonoBehaviour
{
    public GameObject[] damagedGlass;
    public int currGlass;
    public Text Health;
    public float currHealth;
    void Start()
    {
        Health.text = "Health" + currHealth;
        currGlass = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        currHealth -= 1;
        Health.text = "Health" + "  " + currHealth;

        if (currHealth <= 4 && currHealth > 0)
        {
            damagedGlass[currGlass].transform.position = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, damagedGlass[currGlass].transform.position.z);
            damagedGlass[currGlass].SetActive(true);
            currGlass += 1;
            other.gameObject.GetComponent<MoveAsteroid>().StartCoroutine("SetVariables");
        }
        if (currHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
