using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour {
    private Queue<string> sentences;
    public Text nameText;
    public Text dialogueText;
    public GameObject[] HiddenObjects;
    public GameObject box;
    public GameObject[] firstObjects;
	// Use this for initialization
	void Start () {
        sentences = new Queue<string>();
	}
	
    public void DialogueStart (Dialogues sentences)
    {
        box.SetActive(true);
        nameText.text = GameObject.Find("HomelessMan").GetComponent<Dialogues>().name;
        this.sentences.Clear();

       foreach(string sentence in sentences.sentences)
        {
            this.sentences.Enqueue(sentence);
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
        Debug.Log(sentence);
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        Debug.Log("We done now");
        for (int i = 0; i < HiddenObjects.Length; i++)
        {
            HiddenObjects[i].SetActive(true);
        }
        for (int i = 0; i < firstObjects.Length; i++)
        {
            firstObjects[i].SetActive(false);
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
