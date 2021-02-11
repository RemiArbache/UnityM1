using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    private string speakerName;
    private string speech;
    private int index = 0;
    [SerializeField] private DialogueScriptableObject _dialogueScriptableObject;
    [SerializeField] private TextMeshProUGUI nameTextBox = new TextMeshProUGUI();
    [SerializeField] private TextMeshProUGUI speechTextBox = new TextMeshProUGUI();

    [SerializeField] private Image girlSprite;  
    [SerializeField] private Image deitySprite;  
    
    // Start is called before the first frame update
    void Start()
    {
        nextLine(index);
        updateCharactersShown(index);
        index++;
    }

    private void nextLine(int i)
    {
        var tmp = _dialogueScriptableObject.dialogue[i].Split('#');
        var text = tmp[0];
        var name = tmp[1];
        nameTextBox.text = name; 
        speechTextBox.text = text;
    }

    private void updateCharactersShown(int i)
    {
        var tmp = _dialogueScriptableObject.shownCharacters[i].Split('#');
        if (int.Parse(tmp[0]) == 1)
        {
            girlSprite.color = Color.white;
        }
        else
        {
            
            girlSprite.color = Color.clear;
        }
        if (int.Parse(tmp[1]) == 1)
        {
            deitySprite.color = Color.white;
        }
        else
        {

            deitySprite.color = Color.clear;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if( (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0)) && index < _dialogueScriptableObject.dialogue.Length)
        {
            nextLine(index);
            updateCharactersShown(index);
            index++;
        }
    }
}
