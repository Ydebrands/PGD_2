using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class DialogueManager : MonoBehaviour
{

	public TextMeshProUGUI nameText;
	public TextMeshProUGUI dialogueText;
	public GameObject dialogueScreen;


	private Queue<string> sentences;

	// Use this for initialization
	void Start()
	{
		sentences = new Queue<string>();
	}
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
			DisplayNextSentence();
        }
        
    }

    public void StartDialogue(Dialogue dialogue)
	{
		dialogueScreen.SetActive(true);

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
			yield return null;
		}
	}

	void EndDialogue()
	{
		dialogueScreen.SetActive(false);
	}

}