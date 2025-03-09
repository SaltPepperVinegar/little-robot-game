using UnityEngine;
using TMPro;

public abstract class BaseInteractable : MonoBehaviour
{
    public TextMeshProUGUI text;
    private bool inRange;
    protected GameObject player;

    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    protected virtual void Update()
    {
        if (player != null)
        {
            Vector3 playerPos = player.transform.position + new Vector3(0, 3, 0);
            text.transform.LookAt(playerPos);
            text.transform.Rotate(0, 180, 0);
        }

        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
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