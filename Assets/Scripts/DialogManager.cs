using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

    //Queue uses FIFO, so first in first out, usefull for....well a dialog system
    private Queue<string> sentences;

    public Text textElement;

    public Animator animator;

	// Use this for initialization
	void Start () {
        sentences = new Queue<string>();
	}

    public void StartDialog(Dialog dialog)
    {
        animator.SetBool("isOpen", true);
        sentences.Clear();

        //Add all sentences from the dialog object to the queue
        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        //No more sentencse in the queue remaining
        if (sentences.Count == 0)
        {
            EndDialog();
            return;
        }

        string currentSentence = sentences.Dequeue();
        //Stop if user skips sentences too fast
        StopAllCoroutines();
        StartCoroutine(TypeSentence(currentSentence));
    }

    //Make the text appear letter by letter
    IEnumerator<string> TypeSentence (string sentence)
    {
        textElement.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            textElement.text += letter;
            yield return null;
        }
    }

    void EndDialog()
    {
        animator.SetBool("isOpen", false);
    }
}