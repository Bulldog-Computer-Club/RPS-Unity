using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    void OnMouseEnter()
    {
        transform.localScale += new Vector3(0.35f, 0.35f, 0f);
    }

    void OnMouseExit()
    {
        transform.localScale -= new Vector3(0.35f, 0.35f, 0f);
    }

    void OnMouseDown()
    {
        SceneManager.LoadScene("Main");
    }
}
