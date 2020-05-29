using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Esa clase entera permite la existencia de persistencia en las suculentas dentro del pietrarios
public class SucculentPersistance: MonoBehaviour {
    [SerializeField] GameObject succulent1;
    [SerializeField] GameObject succulent2;
    [SerializeField] GameObject succulent3;

    [SerializeField] GameObject buttonSucculent1;
    [SerializeField] GameObject buttonSucculent2;
    [SerializeField] GameObject buttonSucculent3;
    [SerializeField] GameObject buttonSucculentCopy1;
    [SerializeField] GameObject buttonSucculentCopy2;
    [SerializeField] GameObject buttonSucculentCopy3;
    [SerializeField] GameObject buttonGuardian;

    [SerializeField] Image live1;
    [SerializeField] Image live2;
    [SerializeField] Image live3;
    [SerializeField] Image mask1;
    [SerializeField] Image mask2;
    [SerializeField] Image mask3;
    [SerializeField] Text suc1;
    [SerializeField] Text suc2;
    [SerializeField] Text suc3;
    [SerializeField] Text sunLabel;
    [SerializeField] GameObject princiPietrario;
    [SerializeField] Image succulentLive1;
    [SerializeField] Image succulentLive2;
    [SerializeField] Image succulentLive3;
    [SerializeField] public Image sunLevel;
    float maxLive1 = 100, maxLive2 = 100, maxLive3 = 100, maxLight = 100;

    [SerializeField] public GameObject can1;
    [SerializeField] public GameObject can2;
    [SerializeField] public GameObject can3;
    [SerializeField] public GameObject noCan1;
    [SerializeField] public GameObject noCan2;
    [SerializeField] public GameObject noCan3;
    [SerializeField] public GameObject activator1;
    [SerializeField] public GameObject activator2;
    [SerializeField] public GameObject activator3;
    [SerializeField] public GameObject guardian1;
    [SerializeField] public GameObject guardian2;
    [SerializeField] public GameObject guardian3;
    private Pietrario pietrario;
    private GameObject succ1, succ2, succ3;
    private int conActivator1 = 4, conActivator2 = 4, conActivator3 = 4;
    private GameObject guardian;

    void Start() {
        pietrario = (Pietrario) PietrarioRepository.LoadPietrarios()[0];
        renderSucculent();
    }


    //Realiza una actualización cuando hay cambios en el estado de las suculentas
    private void Update() {

        if (pietrario != null) {
            if (pietrario.s1 != null) {
                updateS1wl();
            }
            if (pietrario.s2 != null) {
                updateS2wl();
            }
            if (pietrario.s3 != null) {
                updateS3wl();

            }

            if (pietrario.sunLightLevel > 0) {
                updateSunLight();
            }
        }
        renderSucculent();
    }
    //Actualiza el nivel de luz según se requiera
    public void updateSunLight() {
        long timeDelta = DateTime.Now.Ticks - pietrario.dtL;
        TimeSpan timePassed = new TimeSpan(timeDelta);

        float sunlightSnapshot = pietrario.getRealLightLevel();
        if (Math.Floor(timePassed.TotalSeconds) > 0) {
            pietrario.setLightLevel(sunlightSnapshot - pietrario.decaySunLightLevel * Convert.ToSingle(Math.Floor(timePassed.TotalSeconds)));
            sunLevel.fillAmount = sunlightSnapshot / maxLight;
            sunLabel.text = sunlightSnapshot.ToString();
        } else {
            if (sunlightSnapshot < 0) {
                pietrario.setLightLevel(0);
            }

        }
    }

    //Realiza la actualización en la suculenta 1
    public void updateS1wl() {
        long timeDelta = DateTime.Now.Ticks - pietrario.dtS1;
        TimeSpan timePassed = new TimeSpan(timeDelta);

        if (Math.Floor(timePassed.TotalSeconds) > 0 && pietrario.s1wl > 0) {

            pietrario.s1wl -= pietrario.s1.waterDecayIndex * Convert.ToSingle(Math.Floor(timePassed.TotalSeconds));
            succulentLive1.fillAmount = pietrario.s1wl / maxLive1;
            suc1.text = pietrario.s1wl.ToString();
            pietrario.dtS1 = DateTime.Now.Ticks;
            conActivator1 += 1;
        }

        if (pietrario.s1wl <= 0) {
            pietrario.s1 = null;

            pietrario.Save();
            this.renderSucculent();
        }

    }
    //Realiza la actualización en la suculenta 2

    public void updateS2wl() {

        long timeDelta = DateTime.Now.Ticks - pietrario.dtS2;
        TimeSpan timePassed = new TimeSpan(timeDelta);

        if (Math.Floor(timePassed.TotalSeconds) > 0 && pietrario.s2wl > 0) {

            pietrario.s2wl -= pietrario.s2.waterDecayIndex * Convert.ToSingle(Math.Floor(timePassed.TotalSeconds));


            succulentLive2.fillAmount = pietrario.s2wl / maxLive2;
            suc2.text = pietrario.s2wl.ToString();

            pietrario.dtS2 = DateTime.Now.Ticks;
            conActivator2 += 1;
        }
        if (pietrario.s2wl <= 0) {
            pietrario.s2 = null;

            pietrario.Save();
            this.renderSucculent();
        }
    }
    //Realiza la actualización en la suculenta 3

    public void updateS3wl() {
        long timeDelta = DateTime.Now.Ticks - pietrario.dtS3;
        TimeSpan timePassed = new TimeSpan(timeDelta);

        if (Math.Floor(timePassed.TotalSeconds) > 0 && pietrario.s3wl > 0) {
            pietrario.s3wl -= pietrario.s3.waterDecayIndex * Convert.ToSingle(Math.Floor(timePassed.TotalSeconds));
            succulentLive3.fillAmount = pietrario.s3wl / maxLive3;
            suc3.text = pietrario.s3wl.ToString();
            pietrario.dtS3 = DateTime.Now.Ticks;
            conActivator3 += 1;
        }
        if (pietrario.s3wl <= 0) {

            pietrario.s3 = null;

            pietrario.Save();
            this.renderSucculent();
        }
    }


    //Muestra, destruye o actualiza la suculenta según la que sea requerida y cómo sea requerido
    public void renderSucculent() {


        buttonSucculent1.SetActive(true);
        buttonSucculentCopy1.SetActive(true);
        live1.enabled = false;
        mask1.enabled = false;
        suc1.enabled = false;
        succulentLive1.enabled = false;

        buttonSucculent2.SetActive(true);
        buttonSucculentCopy2.SetActive(true);
        live2.enabled = false;
        mask2.enabled = false;
        suc2.enabled = false;
        succulentLive2.enabled = false;

        buttonSucculent3.SetActive(true);
        buttonSucculentCopy3.SetActive(true);
        live3.enabled = false;
        mask3.enabled = false;
        suc3.enabled = false;
        succulentLive3.enabled = false;

        can1.SetActive(false);
        can2.SetActive(false);
        can3.SetActive(false);
        noCan1.SetActive(true);
        noCan2.SetActive(true);
        noCan3.SetActive(true);

        activator1.SetActive(false);
        activator2.SetActive(false);
        activator3.SetActive(false);

        buttonGuardian.SetActive(true);

        if (pietrario.s1 != null) {
            if (pietrario.s1.persistentId == "SUC1" && succ1 == null) {
                succ1 = Instantiate(succulent1, new Vector3(162.8f, 647.2f, 447.8f), succulent1.transform.rotation);
                succ1.transform.parent = princiPietrario.transform;
                succ1.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            }
            if (pietrario.s1.persistentId == "SUC2" && succ1 == null) {
                succ1 = Instantiate(succulent2, new Vector3(162, 657.59f, 457.4f), succulent2.transform.rotation);
                succ1.transform.parent = princiPietrario.transform;
                succ1.transform.localScale = new Vector3(4f, 4f, 4f);
            }
            if (pietrario.s1.persistentId == "SUC3" && succ1 == null) {
                succ1 = Instantiate(succulent3, new Vector3(150.8f, 700f, 370.2f), succulent3.transform.rotation);

                succ1.transform.parent = princiPietrario.transform;
                succ1.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            }
            buttonSucculent1.SetActive(false);
            buttonSucculentCopy1.SetActive(false);
            activator1.SetActive(true);
            //Debug.Log(conActivator1);
            if (conActivator1 < 4) {
                live1.enabled = true;
                mask1.enabled = true;
                suc1.enabled = true;
                succulentLive1.enabled = true;
            }


            can1.SetActive(true);
            noCan1.SetActive(false);
        } else {
            Destroy(succ1);
        }
        if (pietrario.s2 != null) {
            if (pietrario.s2.persistentId == "SUC1" && succ2 == null) {

                succ2 = Instantiate(succulent1, new Vector3(312.120392f, 657.585912f, 359.38752f), succulent1.transform.rotation);
                succ2.transform.parent = princiPietrario.transform;
                succ2.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            }
            if (pietrario.s2.persistentId == "SUC2" && succ2 == null) {
                succ2 = Instantiate(succulent2, new Vector3(312.120392f, 657.585912f, 314.2f), succulent2.transform.rotation);
                succ2.transform.parent = princiPietrario.transform;
                succ2.transform.localScale = new Vector3(4f, 4f, 4f);
            }
            if (pietrario.s2.persistentId == "SUC3" && succ2 == null) {
                succ2 = Instantiate(succulent3, new Vector3(312.120392f, 657.585912f, 314.2f), succulent3.transform.rotation);
                succ2.transform.parent = princiPietrario.transform;
                succ2.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            }
            buttonSucculent2.SetActive(false);
            buttonSucculentCopy2.SetActive(false);
            activator2.SetActive(true);
            if (conActivator2 < 4) {
                live2.enabled = true;
                mask2.enabled = true;
                suc2.enabled = true;
                succulentLive2.enabled = true;
            }


            can2.SetActive(true);
            noCan2.SetActive(false);
        } else {
            Destroy(succ2);
        }

        if (pietrario.s3 != null) {
            if (pietrario.s3.persistentId == "SUC1" && succ3 == null) {
                succ3 = Instantiate(succulent1, new Vector3(493.2f, 679.2f, 387.8f), succulent1.transform.rotation);
                succ3.transform.parent = princiPietrario.transform;
                succ3.transform.localScale = new Vector3(0.4f, 0.4f, 04f);
            }
            if (pietrario.s3.persistentId == "SUC2" && succ3 == null) {

                succ3 = Instantiate(succulent2, new Vector3(479.4184f, 672.594472f, 347.8f), succulent2.transform.rotation);
                succ3.transform.parent = princiPietrario.transform;
                succ3.transform.localScale = new Vector3(4f, 4f, 4f);
            }
            if (pietrario.s3.persistentId == "SUC3" && succ3 == null) {
                succ3 = Instantiate(succulent3, new Vector3(503.6f, 672.594488f, 370.2f), succulent3.transform.rotation);
                succ3.transform.parent = princiPietrario.transform;
                succ3.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            }
            buttonSucculent3.SetActive(false);
            buttonSucculentCopy3.SetActive(false);
            activator3.SetActive(true);
            if (conActivator3 < 4) {
                live3.enabled = true;
                mask3.enabled = true;
                suc3.enabled = true;
                succulentLive3.enabled = true;
            }


            can3.SetActive(true);
            noCan3.SetActive(false);
        } else {
            Destroy(succ3);
        }

        if (pietrario.guardian != null) {
            buttonGuardian.SetActive(false);
            if (pietrario.guardian.id == "GUA1" && guardian == null) {
                guardian = Instantiate(guardian1);
                guardian.transform.parent = princiPietrario.transform;
            }
            if (pietrario.guardian.id == "GUA2" && guardian == null) {
                guardian = Instantiate(guardian2);
                guardian.transform.parent = princiPietrario.transform;
            }
            if (pietrario.guardian.id == "GUA3" && guardian == null) {
                guardian = Instantiate(guardian3);
                guardian.transform.parent = princiPietrario.transform;
            }

        }
    }
    //Activa la suculenta 1
    public void enableSucculent1(int i) {
        if (i == 0) {
            pietrario.s1 = SucculentRepository.find("SUC1");
            pietrario.s1wl = 100;
            succ1 = Instantiate(succulent1, new Vector3(162.8f, 647.2f, 447.8f), succulent1.transform.rotation);
            succ1.transform.parent = princiPietrario.transform;
            succ1.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);

        }

        if (i == 1) {
            pietrario.s1 = SucculentRepository.find("SUC2");
            pietrario.s1wl = 100;
            succ1 = Instantiate(succulent2, new Vector3(162, 657.59f, 457.4f), succulent2.transform.rotation);
            succ1.transform.parent = princiPietrario.transform;
            succ1.transform.localScale = new Vector3(4f, 4f, 4f);
        }
        if (i == 2) {
            pietrario.s1 = SucculentRepository.find("SUC3");
            pietrario.s1wl = 100;
            succ1 = Instantiate(succulent3, new Vector3(150.8f, 700f, 370.2f), succulent3.transform.rotation);
            succ1.transform.parent = princiPietrario.transform;
            succ1.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        }
        pietrario.dtS1 = DateTime.Now.Ticks;
        pietrario.Save();
        this.renderSucculent();

    }
    //Activa la suculenta 2
    public void enableSucculent2(int i) {

        if (i == 0) {
            pietrario.s2 = SucculentRepository.find("SUC1");
            pietrario.s2wl = 100;
            succ2 = Instantiate(succulent1, new Vector3(312.120392f, 657.585912f, 359.38752f), succulent1.transform.rotation);
            succ2.transform.parent = princiPietrario.transform;
            succ2.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);



        }

        if (i == 1) {
            pietrario.s2 = SucculentRepository.find("SUC2");
            pietrario.s2wl = 100;
            succ2 = Instantiate(succulent2, new Vector3(312.120392f, 657.585912f, 314.2f), succulent2.transform.rotation);
            succ2.transform.parent = princiPietrario.transform;
            succ2.transform.localScale = new Vector3(4f, 4f, 4f);

        }
        if (i == 2) {
            pietrario.s2 = SucculentRepository.find("SUC3");
            pietrario.s2wl = 100;
            succ2 = Instantiate(succulent3, new Vector3(312.120392f, 657.585912f, 314.2f), succulent3.transform.rotation);
            succ2.transform.parent = princiPietrario.transform;
            succ2.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);

        }
        pietrario.dtS2 = DateTime.Now.Ticks;
        pietrario.Save();
        this.renderSucculent();
    }
    //Activa la suculenta 3
    public void enableSucculent3(int i) {
        if (i == 0) {
            pietrario.s3 = SucculentRepository.find("SUC1");
            pietrario.s3wl = 100;
            succ3 = Instantiate(succulent1, new Vector3(493.2f, 679.2f, 387.8f), succulent1.transform.rotation);
            succ3.transform.parent = princiPietrario.transform;
            succ3.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        }

        if (i == 1) {
            pietrario.s3 = SucculentRepository.find("SUC2");
            pietrario.s3wl = 100;
            succ3 = Instantiate(succulent2, new Vector3(479.4184f, 672.594472f, 347.8f), succulent2.transform.rotation);
            succ3.transform.parent = princiPietrario.transform;
            succ3.transform.localScale = new Vector3(4f, 4f, 4f);
        }
        if (i == 2) {
            pietrario.s3 = SucculentRepository.find("SUC3");
            pietrario.s3wl = 100;
            succ3 = Instantiate(succulent3, new Vector3(503.6f, 672.594488f, 370.2f), succulent3.transform.rotation);
            succ3.transform.parent = princiPietrario.transform;
            succ3.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        }
        pietrario.dtS3 = DateTime.Now.Ticks;
        pietrario.Save();
        this.renderSucculent();
    }
    //Activa el guardian
    public void enableGuardian(int i) {
        if (i == 0) {
            pietrario.guardian = GuardianRepository.find("GUA1");
            guardian = Instantiate(guardian1);
            guardian.transform.parent = princiPietrario.transform;
        }
        if (i == 1) {
            pietrario.guardian = GuardianRepository.find("GUA2");
            guardian = Instantiate(guardian2);
            guardian.transform.parent = princiPietrario.transform;
        }
        if (i == 2) {
            pietrario.guardian = GuardianRepository.find("GUA3");
            guardian = Instantiate(guardian3);
            guardian.transform.parent = princiPietrario.transform;
        }
        pietrario.Save();
        renderSucculent();
    }

    //Permite llevar todo el control sobre el agua de cada suculenta
    public void updateWaterLevel(String suctype) {

        if (suctype == "SUC1") {
            pietrario.s1wl = 100f;
            renderSucculent();
            pietrario.Save();
        } else if (suctype == "SUC2") {
            pietrario.s2wl = 100f;
            renderSucculent();
            pietrario.Save();
        } else if (suctype == "SUC3") {
            pietrario.s3wl = 100f;
            renderSucculent();
            pietrario.Save();
        }
    }


//Permite activaciones en general
    public void Activator(int i) {
        if (i == 0) {
            conActivator1 = 0;
        }
        if (i == 1) {
            conActivator2 = 0;
        }
        if (i == 2) {
            conActivator3 = 0;
        }

    }
}