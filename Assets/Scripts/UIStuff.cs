using UnityEngine;
using System.Collections;

public class UIStuff : MonoBehaviour {

    public GameObject StartUI;
    public GameObject Character;
    public GameObject Music;
    public GameObject DI;
    public GameObject Fire;
    public GameObject Disco;
    public GameObject Ball;
    public GameObject Four30;
    public GameObject BAE;
    public GameObject BEG;
    public GameObject GUD;
    public GameObject JEB;
    public GameObject MONUMENT;
    public GameObject NO;
    public GameObject NOOOO;
    public GameObject PLS;
    public GameObject STAHP;
    public GameObject UKNOW;
    public GameObject YE;
    public GameObject LERN;
    public GameObject LERNT;
    public GameObject Beard;
    public GameObject KEY;
    private bool started = false;

    void Start()
    {
        StartUI.SetActive(true);
        Character.SetActive(false);
        Music.SetActive(false);
        Fire.SetActive(false);
        Disco.SetActive(false);
        Ball.SetActive(false);
        Four30.SetActive(false);
        BAE.SetActive(false);
        BEG.SetActive(false);
        GUD.SetActive(false);
        JEB.SetActive(false);
        MONUMENT.SetActive(false);
        NO.SetActive(false);
        NOOOO.SetActive(false);
        PLS.SetActive(false);
        STAHP.SetActive(false);
        UKNOW.SetActive(false);
        YE.SetActive(false);
        KEY.SetActive(false);
        LERN.SetActive(false);
        LERNT.SetActive(false);
        Beard.SetActive(false);
        DI.SetActive(true);

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.P) && !started)
        {
            StartUI.SetActive(false);
            LERN.SetActive(true);
            Character.SetActive(true);
            Music.SetActive(true);
            started = true;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Application.LoadLevel(0);
        }
    }
}
