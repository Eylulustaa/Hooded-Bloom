using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public GameObject Box;
    public GameObject Mark;
    public string[] sentences;
    public float typingSpeed = 0.05f;

    private int index = 0;
    private bool isTyping = false;

    private bool isEnded = false;

    void Start()
    {
        Box.SetActive(false);
        Mark.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartDialogue();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!isEnded)
            {
                EndDialogue();
                gameObject.SetActive(true);
                Box.SetActive(false);
                Mark.SetActive(true);
            }

        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (isTyping)
            {
                StopAllCoroutines();
                dialogueText.text = sentences[index];
                isTyping = false;
            }
            else
            {
                NextSentence();
            }
        }
    }

    void StartDialogue()
    {
        Mark.SetActive(false);
        Box.SetActive(true);
        isEnded = false;
        StartCoroutine(TypeSentence(sentences[index]));
    }

    void NextSentence()
    {
        if (index < sentences.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(TypeSentence(sentences[index]));
        }
        else
        {
            isEnded = true;
            EndDialogue();
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        isTyping = true;
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
    }

    void EndDialogue()
    {
        dialogueText.text = "";
        index = 0;
        gameObject.SetActive(false);
        Debug.Log("End of Dialogue");
    }
}
