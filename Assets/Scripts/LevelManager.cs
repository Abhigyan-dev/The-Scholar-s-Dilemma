using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public int currScore = 0;
    //Time Bar
        // minScore = 0, maxScore = 100;
        // public ScoreBar scoreBar;
    public TimeBar timeBar;
    float currTime;
    public float totalTime = 60;

    // Students:
    string[] students_names = new string[] {"Liam", "Henry", "Sophia", "Olivia", "James"};
    int[] student_marks = new int[] {100, 50, 78, 69, 92};
    int[] student_prob = new int[] {20, 90, 50, 60, 80};
    
    // Text UI:
    public TextMeshProUGUI[] statText;

    void Start()
    {
        for(int i = 0; i < students_names.Length; i++)
            statText[i].text = students_names[i] + ' ' + student_marks[i] + ' ' + student_prob[i];
        
        // currScore = minScore;
        // scoreBar.SetMaxScore(maxScore);
        // scoreBar.SetMinScore(minScore);

        currTime = totalTime;
        timeBar.SetMaxTime(totalTime);
        timeBar.SetMinTime(0);
    }

    public void UpdateMarks(int marks)
    {
        Debug.Log("Reached Here");
        currScore += marks;
        Debug.Log("Curr Marks = " + currScore);
    }

    void Update()
    {
        currTime -= 1*Time.deltaTime;
        timeBar.setTime(currTime);
    }
}
