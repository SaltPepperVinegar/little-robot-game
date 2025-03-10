using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class ProgressManagement : MonoBehaviour
{   
    [Header("The order of the notes")]
    [SerializeField] private GameObject AnnoucementCanvas;
    private Camera mainCamera;

    public Camera thirdPersonCamera;
    public AudioSource Melody;
    private float BPM = 120f;
    
    private Note[] notes;

    private float[] quartersAfterEachNote;
    private MelodySet melodyChoosed;
    public MelodySet[] melodyToChooseFrom;
    public Base[] bases;
    private bool unlocked = false;
    bool matching = false;
    private bool checking = false;
    public GameObject door;
    void Start()
    {   
        
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        int j = Random.Range(0,melodyToChooseFrom.Length);
        Debug.Log(j + "choosed");
        melodyChoosed = melodyToChooseFrom[j];
        quartersAfterEachNote = melodyChoosed.quartersAfterEachNote;
        notes = melodyChoosed.Melody;
        BPM = melodyChoosed.BPM;
        for(int i=0; i<notes.Length; i++){
            bases[i].GetComponent<Base>().BaseNote = notes[i];
        }
    }
    void Update()
    {
    }

    public void CheckForMelody(){
        matching = true;

        if (!unlocked && !checking){
            foreach(Base basenote in bases)
            {
                if(! basenote.GetComponent<Base>().isMatching()){
                    matching = false;
                }
            } 

            StartCoroutine(StartChecking());
        }
        
    }
    private IEnumerator StartChecking()
    {   
        mainCamera.enabled = false;
        thirdPersonCamera.enabled = true;
        checking = true;
        yield return new WaitForSeconds(0.5f);

        for(int i=0; i<bases.Length; i++)
        {
            bases[i].GetComponent<Base>().PlayMatch();
            yield return new WaitForSeconds(quartersAfterEachNote[i]*60/BPM);
        } 
        if(matching){
            StartCoroutine(Annoucement());

        }
        yield return new WaitForSeconds(0.5f);

        mainCamera.enabled = true;
        thirdPersonCamera.enabled = false;
        checking = false;

    }

    private IEnumerator Annoucement()
    {   
        AnnoucementCanvas.SetActive(true);
        door.GetComponent<DoorOpen>().openDoor();
        yield return new WaitForSeconds(3f);
        AnnoucementCanvas.SetActive(false);
        unlocked = true;
        SceneManager.LoadScene(2);

    }

}
