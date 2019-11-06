using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class readText : MonoBehaviour
{
    private static string[] texts;
    private int cur;
    public Text output = null;
    // Start is called before the first frame update
    void Start()
    {
        string text = System.IO.File.ReadAllText(@"Assets\startMenu\startMenu\level1tolevel2.txt");
        string[] separateFlag = { "[sep]" };
        texts = text.Split(separateFlag, System.StringSplitOptions.RemoveEmptyEntries);

        output.text = texts[0];
        cur = 0;

    }

    public void nextText() {
        if (cur + 1 < texts.Length) {
            output.text = texts[++cur];
        }
    }

    public void prevText() {
        if (cur - 1 >= 0) {
            output.text = texts[--cur];
        }
    }
}
