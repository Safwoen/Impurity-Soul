using UnityEngine;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{
    public Dialogue dialogue;
    public DialogueManager dm;
    public GameObject box;

    private void Start()
    {
        dm = FindObjectOfType<DialogueManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            box.SetActive(true);
            dm.StartDialogue(dialogue);
            other.GetComponent<Charactercontroller>().collectablesCollected++;
            Destroy(gameObject);
        }
    }

  }
