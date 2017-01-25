using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

    public bool Wiggling = false; //wiggle anim
    public bool Smashing = false; //smash anim 
    public bool Stert = false; //has start been pressed
    public bool Bum = false;
    private Animator anim;
    public AudioSource sclip;
    public AudioSource wclip;
    public AudioSource something;
    public AudioSource DI;
    public AudioSource backMusic;
    public GameObject Fire;
    public GameObject Disco;
    public GameObject Ball;
    public GameObject F30;
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
    public GameObject KEY;
    public GameObject Me;
    public GameObject Beard;
    public ArrayList quotes = new ArrayList();
    private int fireyet = 0;
    private int successyet = 0;
    private bool youdidit = false;
    private bool morality = true;
    //private bool sinful = false;
    private int somethi = 0;

    void Start () {
        anim = gameObject.GetComponent<Animator>();
        quotes.Add(F30);
        quotes.Add(BAE);
        quotes.Add(BEG);
        quotes.Add(GUD);
        quotes.Add(JEB);
        //quotes.Add(MONUMENT);
        quotes.Add(NO);
        quotes.Add(NOOOO);
        quotes.Add(PLS);
        quotes.Add(STAHP);
        quotes.Add(UKNOW);
        quotes.Add(YE);
        quotes.Add(LERN);
    }

    void PlaySmash () //plays smash audioclip
    {
        sclip.time = (float)0.25 * sclip.clip.length;
        sclip.Play();
    }

    void PlayWiggle() //plays wiggle audioclip
    {
        if (!(wclip.isPlaying))
        {
            wclip.Play();
        }
    }

    void FireMore()
    {
        fireyet++;
        //print(fireyet);
    }

    void SuccessMore()
    {
        if(!Fire.activeInHierarchy)
            successyet++;
    }

    void Deactivate(ArrayList l)
    {
        foreach (GameObject g in l) 
        {
            g.SetActive(false);
        }
    }

    void Update () {
        //print(wclip.time);
        anim.SetBool("Wiggling", Wiggling);
        anim.SetBool("Smashing", Smashing);
        anim.SetBool("Stert", Stert);
        anim.SetBool("Success", youdidit);
        anim.SetBool("Bum", Bum);

        if (((wclip.time > .6) && (wclip.isPlaying) && !(Input.GetKey(KeyCode.W))) || (Input.GetKey(KeyCode.J)))
        {
            wclip.Stop();
            //print("stop");
        }
        if (Input.GetKey(KeyCode.K) && Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.Y))
        {
            KEY.SetActive(true);
            somethi = 0;
        }
        else
            KEY.SetActive(false);

        if (Input.GetKey(KeyCode.D))
        {
            if (!Disco.activeInHierarchy)
            {
                DI.Play();
                backMusic.Stop();
            }

            Disco.SetActive(true);
            Ball.SetActive(true);
            somethi = 0;
        }
        else
        {
            if (Disco.activeInHierarchy)
            {
                DI.Stop();
                backMusic.Play();
            }
            Disco.SetActive(false);
            Ball.SetActive(false);
        }

        if (Input.GetKey(KeyCode.C))
        {
            Beard.SetActive(true);
            somethi = 0;
        }
        else
            Beard.SetActive(false);

        if (Input.GetKey(KeyCode.P))
            Stert = true;
        if (Input.GetKey(KeyCode.Z) && Input.GetKey(KeyCode.T))
        {
            Me.transform.position = new Vector3((float)1.5, -3, 0);
            Me.transform.rotation = Quaternion.Euler(180, 180, 270);
            //if (Beard.activeInHierarchy)
            //{
            //    Beard.transform.position = new Vector3((float)0.1, (float)-2.95, 0);
            //    Beard.transform.rotation = Quaternion.Euler(180, 0, 0);
            //}
        }
        else if (Input.GetKey(KeyCode.Z))
        {
            Me.transform.position = new Vector3(0, -3, 0);
            Me.transform.rotation = Quaternion.Euler(180, 0, 0);
            if (Beard.activeInHierarchy)
            {
                Beard.transform.position = new Vector3((float)0.1, (float)-2.95, 0);
                Beard.transform.rotation = Quaternion.Euler(180, 0, 0);
            }
            somethi++;
            if (somethi >= 500)
            {
                something.Play();
                somethi = 0;
            }
        }
        else if (Input.GetKey(KeyCode.T))
        {
            Me.transform.position = new Vector3(2, 3, 0);
            Me.transform.rotation = Quaternion.Euler(0, 180, 0);
            if (Beard.activeInHierarchy)
            {
                Beard.transform.position = new Vector3((float)1.9, (float)2.95, 0);
                Beard.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            somethi = 0;
        }
        else
        {
            Me.transform.position = new Vector3(0, 0, 0);
            Me.transform.rotation = Quaternion.Euler(0, 0, 0);
            if (Beard.activeInHierarchy)
            {
                Beard.transform.position = new Vector3((float).1, (float)-.05, 0);
                Beard.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            somethi = 0;
        } 
         

        if (Input.GetKey(KeyCode.J) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.B))
        {
            Smashing = true;
            morality = false;
            somethi = 0;
            //print("is smashing");
        }
        else
            Smashing = false;

        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.J) && !Input.GetKey(KeyCode.B))
        {
            Wiggling = true;
            morality = true;
            somethi = 0;
            //print("is wiggling");
        }
        else
            Wiggling = false;
        if (Input.GetKey(KeyCode.B) && !youdidit)
        {
            if (!Bum)
                backMusic.Play();
            Bum = true;
            somethi = 0;
        }
        else
            Bum = false;

        if (!youdidit)
        {
            if (fireyet >= 1 && fireyet < 15 && !morality)
            {
                if (!NO.activeInHierarchy)
                {
                    Deactivate(quotes);
                    NO.SetActive(true);
                }
            }
            if (fireyet >= 15 && fireyet < 30 && !morality)
            {
                if (!PLS.activeInHierarchy)
                {
                    Deactivate(quotes);
                    PLS.SetActive(true);
                }
            }
            if (fireyet >= 30 && fireyet < 40 && !morality)
            {
                if (!STAHP.activeInHierarchy)
                {
                    Deactivate(quotes);
                    STAHP.SetActive(true);
                }
            }
            if (fireyet >= 55 && fireyet < 68 && !morality)
            {
                if (!BEG.activeInHierarchy)
                {
                    Deactivate(quotes);
                    BEG.SetActive(true);
                }
            }
            if (fireyet >= 68 && fireyet < 80 && !morality)
            {
                if (!NOOOO.activeInHierarchy)
                {
                    Deactivate(quotes);
                    NOOOO.SetActive(true);
                }
            }
            if (fireyet >= 100)
            {
                if (!MONUMENT.activeInHierarchy)
                {
                    Deactivate(quotes);
                    MONUMENT.SetActive(true);
                    //sinful = true;
                }
            }
        }
        if (fireyet >= 40 && fireyet < 55 && !morality)
        {
            if (!F30.activeInHierarchy)
            {
                Fire.SetActive(true);
                Deactivate(quotes);
                if(!youdidit)
                    F30.SetActive(true);
            }
        }
        if (!Fire.activeInHierarchy)
        {
            if (successyet >= 1 && successyet < 15 && morality)
            {
                if (!GUD.activeInHierarchy)
                {
                    Deactivate(quotes);
                    GUD.SetActive(true);
                }
            }
            if (successyet >= 15 && successyet < 33 && morality)
            {
                if (!UKNOW.activeInHierarchy)
                {
                    Deactivate(quotes);
                    UKNOW.SetActive(true);
                }
            }
            if (successyet >= 33 && successyet < 42 && morality)
            {
                if (!YE.activeInHierarchy)
                {
                    Deactivate(quotes);
                    YE.SetActive(true);
                }
            }
            if (successyet >= 42 && successyet < 58 && morality)
            {
                if (!JEB.activeInHierarchy)
                {
                    Deactivate(quotes);
                    JEB.SetActive(true);
                }
            }
            if (successyet >= 58 && successyet < 74 && morality)
            {
                if (!BAE.activeInHierarchy)
                {
                    Deactivate(quotes);
                    BAE.SetActive(true);
                }
            }
            if (successyet >= 100)
            {
                if (!LERNT.activeInHierarchy)
                {
                    Deactivate(quotes);
                    LERNT.SetActive(true);
                    youdidit = true;
                }
            }
        }
        //if (anim.GetCurrentAnimatorStateInfo(0).length == .183)
        //    Smashing = false;
        //if (wiggle.GetCurrentAnimatorStateInfo(0).IsName("wiggle"))
        //    Wiggling = false;*/
        //print(somethi);
    }

}
