using UnityEngine;
using TMPro;

public abstract class BaseInteractable : MonoBehaviour
{
    public TextMeshProUGUI text;
    private bool inRange;
    protected GameObject player;
    public Canvas canvas;

    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    protected virtual void Update()
    {
        if (player != null)
        {
            Vector3 playerPos = player.transform.position + new Vector3(0, 3, 0);
            canvas.transform.LookAt(playerPos);
            canvas.transform.Rotate(0, 180, 0);
        }
      if (inRange )
        {
            canvas.enabled=true;
            if (Input.GetKeyDown(KeyCode.E)){
                Interact();

            }
        } else{
            canvas.enabled=false;

        }

    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            text.text = "Press E to Interact!";
            inRange = true;
        }
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            text.text = "";
            inRange = false;
        }
    }
    
    protected abstract void Interact();
}