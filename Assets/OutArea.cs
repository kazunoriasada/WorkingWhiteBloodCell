using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutArea : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col) 
    {
        if(col.gameObject.tag == "WhiteBloodCell")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
