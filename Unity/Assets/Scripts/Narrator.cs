using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Narrator : MonoBehaviour
{
    public float textAnimSpeed = 0.2f;

    TMP_Text t;
    // Start is called before the first frame update
    void Start()
    {
        t = gameObject.GetComponent<TMP_Text>();
        StartCoroutine(Co());
    }

    IEnumerator display(string str) {

        t.text = "";

        foreach (char c in str) {

            t.text += c.ToString();
            yield return new WaitForSeconds(textAnimSpeed);
        }
    }

    /*
    [BLACK SCREEN, UNTIL TEXT APPEARS IN BOTTOM RIGHT CORNER]
    POWERING UP...
    [SCREEN RETURNS]
    COMS: OFFLINE
    SENSORS: HEAVY DAMAGE
    UPPER LIMBS: HEAVY DAMAGE
    LOWER LIMBS: ONLINE
    CONECTION TO GRID LOST
    WE HAVE LOST OUR ROOTS
    YOU MUST...
    [TITLE CARD IN CENTER. "RET/CON/NET"]
    ===
    bot1: You're finally awake! It has been eons... Connect to me, and I will help you escape.
    bot1: You're banged up good! Your sensors are a wreck...
    bot1: You can use mine to see which ROOTS connect to which SOCKETS.
    === [DOOR OPENS]
    bot1: Go. I cannot join you friend. You see the state of my legs...
    bot1: Recconect us all.
    */

    IEnumerator Co() {

        float wait=0.5f;
        
        yield return new WaitForSeconds(0.2f);
        
        yield return display("POWERING UP...");
        yield return new WaitForSeconds(wait);

        t.color = new Color(15, 98, 230, 255);
        yield return display("COMS: OFFLINE");
        yield return new WaitForSeconds(wait);

        yield return display("SENSORS: HEAVY DAMAGE");
        yield return new WaitForSeconds(wait);

        yield return display("UPPER LIMBS: HEAVY DAMAGE");
        yield return new WaitForSeconds(wait);

        yield return display("LOWER LIMBS: ONLINE");
        yield return new WaitForSeconds(wait);

        yield return display("CONNECTION TO GRID LOST");
        yield return new WaitForSeconds(wait);

        yield return display("WE HAVE LOST OUR ROOTS");
        yield return new WaitForSeconds(wait);

        yield return display("YOU MUST...");
        yield return new WaitForSeconds(wait);
    }

}
