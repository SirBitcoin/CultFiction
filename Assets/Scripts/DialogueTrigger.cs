﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    public Dialogues dialogues;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().DialogueStart(dialogues);
    }
}
