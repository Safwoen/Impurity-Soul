using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public GameObject dialogueBox;
    
    public Animator animator;

    private Queue<string> sentences;
    public int currentSentence;
    void Start()
    {

        sentences = new Queue<string>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            currentSentence++;
            DisplayNextSentence();
            
        }
        if (currentSentence == 2)
        {
            dialogueBox.SetActive(false);
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        currentSentence = 0;
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }


        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;

        }

        
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }
}

