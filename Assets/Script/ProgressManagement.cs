using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class ProgressManagement : MonoBehaviour
{   
    [Header("The order of the notes")]
    [SerializeField] private GameObject AnnoucementCanvas;

    public AudioSource Melody;
    public float[] delayAfterEachNotes;

    public Note[] notes;


    public Base[] bases;
    private bool unlocked = false;
    bool matching = false;

    void Start()
    {
        for(int i=0; i<notes.Length; i++){
            bases[i].GetComponent<Base>().BaseNote = notes[i];
        }
    }
    void Update()
    {
    }

    public void CheckForMelody(){
        matching = true;
        if (!unlocked){
            foreach(Base basenote in bases)
            {
                if(! basenote.GetComponent<Base>().isMatching()){
                    matching = false;
                }
            } 
            if(matching){
                StartCoroutine(Annoucement());

            }
            //StartCoroutine(StartChecking());
        }
        
    }
    private IEnumerator StartChecking()
    {   
        Melody.Play();
        yield return new WaitForSeconds(3f);
        Melody.Stop();

        for(int i=0; i<bases.Length; i++)
        {
            bases[i].GetComponent<Base>().linkedItem.GetComponent<Item>().notesAudio.Play();
            yield return new WaitForSeconds(delayAfterEachNotes[i]);
        } 
        if(matching){
            StartCoroutine(Annoucement());

        }

    }

    private IEnumerator Annoucement()
    {   
        AnnoucementCanvas.SetActive(true);
        yield return new WaitForSeconds(3f);
        AnnoucementCanvas.SetActive(false);
        unlocked = true;
        SceneManager.LoadScene(2);

    }

}
