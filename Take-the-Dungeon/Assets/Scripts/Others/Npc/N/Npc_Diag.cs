using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc_Diag : MonoBehaviour
{

    public float dialogueRange;
    public LayerMask Player_Layer;

    bool playerHit;

    public Npc Dialogue;
    private List<string> sentences = new List<string>();

    private void Start()
    {
        GetNPCText();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerHit) {
            Dialogue_Control.instance.Speech(sentences.ToArray());
        }
    }

    void GetNPCText() {

        for (int i = 0; i<Dialogue.dialogues.Count; i++) {
            switch (Dialogue_Control.instance.language)
            {
                case Dialogue_Control.idion.pt:
                    sentences.Add(Dialogue.dialogues[i].sentence.portuguese);
                    break;
                case Dialogue_Control.idion.eng:
                    sentences.Add(Dialogue.dialogues[i].sentence.portuguese);
                    break;
                case Dialogue_Control.idion.spa:
                    sentences.Add(Dialogue.dialogues[i].sentence.portuguese);
                    break;
            }
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        ShowDialogue();
    }

    void ShowDialogue() {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, Player_Layer);

        if (hit == true)
        {
            playerHit = true;
        }
        else {
            playerHit = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
    }
}
