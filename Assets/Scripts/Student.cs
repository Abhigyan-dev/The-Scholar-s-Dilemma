using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Student : MonoBehaviour
{
    public LevelManager levelManager;
    public string students_name = "";
    public int student_marks = 0;
    public int student_prob = 0;
    bool triggerStay = false;
    bool interacted = false;

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
        TextMeshProUGUI text = GetComponentInChildren<TextMeshProUGUI>();
        text.enabled = false;
        sprites[1].enabled = false;
    }

    void OnTriggerEnter2D(Collider2D CollisionInfo)
    {
        if(CollisionInfo.gameObject.tag == "Player")
        {
            Debug.Log("Copying...");
            SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
            // TextMeshProUGUI text = GetComponentInChildren<TextMeshProUGUI>();
            // text.enabled = true;
            sprites[1].enabled = true;
            triggerStay = true;
        }
    }

    void OnTriggerExit2D(Collider2D CollisionInfo)
    {
        if(CollisionInfo.gameObject.tag == "Player")
        {
            Debug.Log("");
            SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
            // TextMeshProUGUI text = GetComponentInChildren<TextMeshProUGUI>();
            // text.enabled = false;
            sprites[1].enabled = false;
            triggerStay = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && triggerStay && !interacted)
        {
            Debug.Log("getting marks");
            int digit = Random.Range(1, 101);
            Debug.Log("Marks = " + student_marks + ", Prob = " + student_prob + ", digit = " + digit);
            if(digit <= student_prob)
            {
                Debug.Log("could have");
                levelManager.UpdateMarks(student_marks);
            }
            else 
            {
                Debug.Log("could not have");    
            }
            interacted = true;
        }
    }
}
