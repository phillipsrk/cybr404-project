using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryIntroduction : MonoBehaviour

{
    string [] storyLine = {"Living in your university’s dorms has allowed you to meet a lot of different people and spark friendships with a few. You befriend Noah, Matthew, and Sam from down the hall and Jennfier and Natalie from across the hall.", "Name: Noah\nAge: 18\nA dorky looking dude who tries his best to be the group's comedic relief.", "Name: Matthew\nAge: 20\nA musician that's nice but incredibly pretentious.", "Name: Sam\nAge: 19\nReserved, nerdy type who doesn't talk much in groups.", "Name: Natalie\nAge: 19\nSource of absolute chaos, very little critical thinking happens here.", "Name: Jennifer\nAge: 19\nA trustworthy friend that loves coffee, astrology, and deep conversations.","The group has a good variety of personalities and everyone has a different type of relationship with each other. As Halloween approaches, the group decides to do something a little more mysterious than what they normally do on the weekends.", "A staple of this small college town is the infamous Jones House located just down the block from campus. The history of this house is unknown, but there’s a variety of stories about what has happened here", "The reasons of why its empty range from it being the scene of a murder to it having a demonic spirit attached to it to its simply just rundown. Regardless of all the possibilities, you and your friends decide to investigate it at night.", "After a short walk from the dorms, you approach the dark, rundown house apprehensively. Matthew is the first to move inside the house and once everyone follows you are presented with a choice."};
    int index = 0;
    public Text mainText;
    public GameObject StoryIntro;
    public GameObject Choice;
    public GameObject Sam, Matthew, Noah, Natalie, Jennifer;
    //public Button continueBtn;
    //public Animator animator;

    public void nextText()
    {
       if (index < 10){
        mainText.text = storyLine[index];
        if(index == 0){
            Noah.GetComponent<Animation>().Play("noah_Down");
            Matthew.GetComponent<Animation>().Play("matthew_Down");
            Sam.GetComponent<Animation>().Play("sam_Down");
            Natalie.GetComponent<Animation>().Play("natalie_Down");
            Jennifer.GetComponent<Animation>().Play("jennifer_Down");
        }
        else if(index == 1){
            Noah.GetComponent<Animation>().Play("noah_up");
        }
        else if(index == 2){
            Matthew.GetComponent<Animation>().Play("matthew_Up");
        }
        else if(index == 3){
            Sam.GetComponent<Animation>().Play("sam_Up");
        }
        else if(index == 4){
            Natalie.GetComponent<Animation>().Play("natalie_Up");
        }
        else if(index == 5){
            Jennifer.GetComponent<Animation>().Play("jennifer_Up");
        }

        index = index + 1;
    }
        else {
            StoryIntro.SetActive(false);
            Choice.SetActive(true);
        }
    }
    
    public void movePersonDown(){
        if (index == 3){
            Noah.GetComponent<Animation>().Play("noah_Down");
        }
        else if(index == 4){
            Matthew.GetComponent<Animation>().Play("matthew_Down");
        }
        else if(index == 5){
            Sam.GetComponent<Animation>().Play("sam_Down");
        }
        else if(index == 6){
            Natalie.GetComponent<Animation>().Play("natalie_Down");
        }
        else if(index == 7){
            Jennifer.GetComponent<Animation>().Play("jennifer_Down");
        }
        }

}

