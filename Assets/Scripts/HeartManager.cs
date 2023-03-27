using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public GameObject heart0, heart25, heart50, heart75, heart100;
    public Slider mySlider;
    
    void Start()
    {
        heart0.SetActive(false);
        heart25.SetActive(false);
        heart50.SetActive(false);
        heart75.SetActive(false);
        heart100.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mySlider.value >= 0 && mySlider.value <= 15)
        {
            heart0.SetActive(true);
            heart25.SetActive(false);
            heart50.SetActive(false);
            heart75.SetActive(false);
            heart100.SetActive(false);
        }else if (mySlider.value > 15 && mySlider.value <= (mySlider.maxValue / 100 * 25))
        {
            heart0.SetActive(false);
            heart25.SetActive(true);
            heart50.SetActive(false);
            heart75.SetActive(false);
            heart100.SetActive(false);
        }
        else if (mySlider.value > (mySlider.maxValue / 100 * 25) && mySlider.value <= (mySlider.maxValue / 100 * 70))
        {
            heart0.SetActive(false);
            heart25.SetActive(false);
            heart50.SetActive(true);
            heart75.SetActive(false);
            heart100.SetActive(false);
        }
        else if (mySlider.value > (mySlider.maxValue / 100 * 70) && mySlider.value <= (mySlider.maxValue / 100 * 90))
        {
            heart0.SetActive(false);
            heart25.SetActive(false);
            heart50.SetActive(false);
            heart75.SetActive(true);
            heart100.SetActive(false);
        }
        else if (mySlider.value > (mySlider.maxValue / 100 * 90) && mySlider.value <= 4999990)
        {
            heart0.SetActive(false);
            heart25.SetActive(false);
            heart50.SetActive(false);
            heart75.SetActive(false);
            heart100.SetActive(true);
        }
        else if (mySlider.value >= 4999990)
        {
            Debug.Log("!!");
            SceneManager.LoadScene("Win");
        }


    }
}
