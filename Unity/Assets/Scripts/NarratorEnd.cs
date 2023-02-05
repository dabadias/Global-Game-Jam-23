using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NarratorEnd : MonoBehaviour
{
    public float textAnimSpeed = 0.2f;
    public AudioSource audioSource;
    public AudioClip typesound;

    TMP_Text t;
    // Start is called before the first frame update
    void Start()
    {
        t = gameObject.GetComponent<TMP_Text>();
        StartCoroutine(Co());
    }

    IEnumerator display(string str)
    {
        t.text = "";
        foreach (char c in str)
        {
            t.text += c.ToString();
            audioSource.PlayOneShot(typesound);
            yield return new WaitForSeconds(textAnimSpeed);
        }
    }

    /*
CREDITS:
Programming: Daniel Dias
Design/Audio: Rodrigo Mesquita
Art/Modeling: AntÃ³nio Canteiro
    */

    IEnumerator Co()
    {
        float wait = 0.5f;

        yield return new WaitForSeconds(0.2f);

        yield return display("CREDITS");
        yield return new WaitForSeconds(wait);

        t.color = new Color(255, 0, 0, 255);
        yield return display("DANIEL DIAS: PROGRAMMING");
        yield return new WaitForSeconds(wait);

        t.color = new Color(255, 0, 0, 255);
        yield return display("RODRIGO MESQUITA: DESIGN/AUDIO");
        yield return new WaitForSeconds(wait);

        t.color = new Color(255, 0, 0, 255);
        yield return display("ANTONIO CANTEIRO: ART/MODELLING");
        yield return new WaitForSeconds(wait);

        t.color = new Color(0, 255, 0, 255);
        yield return display("WE HAVE FOUND OUR ROOTS");
        yield return new WaitForSeconds(wait);
        yield return display("THANK YOU FOR PLAYING");
        yield return new WaitForSeconds(wait);
        yield return new WaitForSeconds(wait);

        Application.Quit();
    }

}
