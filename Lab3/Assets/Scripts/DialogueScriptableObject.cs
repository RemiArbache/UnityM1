using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue", order = 1)]
public class DialogueScriptableObject : ScriptableObject
{
    public string[] dialogue = new string[]
    {
        "It's the first day at school, a stressful day for most students. # Narrator",
        "I really don't like going to school, I wish I could escape it # Little Girl",
        "Your heart is pure, and I have been summoned # Ḍ̵̛͓̺͋͋̋͒̅E̴̹̝͚̓̔̏I̴̱̮̯̺̔̈́́̚͝T̸̘̰͍̟̻̒̃Y̴̻͉̓̾",
        "Express your true wish and it shall be realized # Ḍ̵̛͓̺͋͋̋͒̅E̴̹̝͚̓̔̏I̴̱̮̯̺̔̈́́̚͝T̸̘̰͍̟̻̒̃Y̴̻͉̓̾",
        "uuuuuuuuh, I'd like to skip school ?# Little Girl",
        "That is amenable # Ḍ̵̛͓̺͋͋̋͒̅E̴̹̝͚̓̔̏I̴̱̮̯̺̔̈́́̚͝T̸̘̰͍̟̻̒̃Y̴̻͉̓̾",
        "... #  Ḍ̵̛͓̺͋͋̋͒̅E̴̹̝͚̓̔̏I̴̱̮̯̺̔̈́́̚͝T̸̘̰͍̟̻̒̃Y̴̻͉̓̾",
        "And so it is. #  Ḍ̵̛͓̺͋͋̋͒̅E̴̹̝͚̓̔̏I̴̱̮̯̺̔̈́́̚͝T̸̘̰͍̟̻̒̃Y̴̻͉̓̾",
        "The end # ."
    };

    
    public string[] shownCharacters = new string[]
    {
        "0#0",
        "1#0",
        "1#1",
        "1#1",
        "1#1",
        "1#1",
        "0#1",
        "0#1",
        "0#0"
    };
}
