using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EndLetterManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text letterText;
    string text1;
    void Start()
    {
        int loseTimes = PlayerPrefs.GetInt("LoseTimes");
        text1 =
            "Congratulations on your success of finding the way to school. \n \n" +
            "You lost the way " + loseTimes + " times during the six day of your journey.\n \n" +
            "You can retry as many times as you can to finally find the way. \n \n" +
            "However, for the students in some areas of Jiangxi, China, they have to " +
            "suffer from the dark and danger every day.\n \n";

        letterText.text = text1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
