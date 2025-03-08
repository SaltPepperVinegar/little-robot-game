using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class ProgressManagement : MonoBehaviour
{   
    [Header("The order of the notes")]
    [SerializeField] private GameObject AnnoucementCanvas;

    public Note[] notes;


    public Base[] bases;
    private bool unlocked = false;

    void Start()
    {
        for(int i=0; i<notes.Length; i++){
            bases[i].GetComponent<Base>().BaseNote = notes[i];
        }
    }
    void Update()
    {
        CheckForMelody();
    }

    void CheckForMelody(){
        if (!unlocked){
            foreach(Base basenote in bases)
            {
                if(! basenote.GetComponent<Base>().isMatching()){
                    return;

                }

            } 
            StartCoroutine(Annoucement());
        }
        
    }

    private IEnumerator Annoucement()
    {   
        AnnoucementCanvas.SetActive(true);
        yield return new WaitForSeconds(3f);
        AnnoucementCanvas.SetActive(false);
        unlocked = true;
    }

}
