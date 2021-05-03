using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

class StoryBlock{
    public string story;
    public string option1Text;
    public string option2Text;
    public StoryBlock option1Block;
    public StoryBlock option2Block;
   

    public StoryBlock(string story, string option1Text = "", string option2Text = "", StoryBlock option1Block = null, StoryBlock option2Block = null){
        this.story = story;
        this.option1Text = option1Text;
        this.option2Text = option2Text;
        this.option1Block = option1Block;
        this.option2Block = option2Block;
    }
}    

public class gameManager : MonoBehaviour
{

    public Text mainText;
    public Button option1;
    public Button option2;
    public Button basement;
    public Button kitchen;
    public Button upstairs;
    public GameObject startLevel;
    public GameObject playLevel;
    StoryBlock currentBlock;

    //UPSTAIRS
    static StoryBlock block17 = new StoryBlock("While there's no immediate consequences from tearing apart these photos, they set a curse on you for the next 7 years.", "", ">>>");
    static StoryBlock block16 = new StoryBlock("You end up finding old scrapbooks in the locked closet that Noah forced open. The more you look through them the more you think that the house isn't actually haunted just an abandoned home at the center of a big conspiracy story.", "", ">>>");
    static StoryBlock block15 = new StoryBlock("The uncomfortable aura of the room grows as you and Noah talk. Time passes and eventually you decide to leave and join the rest of the group in the kitchen.", "", "Go to the kitchen.");
    static StoryBlock block14 = new StoryBlock("The history of this house is pretty unknown but as you start investigating the bedroom, you uncover some old photos.", "Keep investigating the dressers in the room to try to uncover more information.", "Tear apart the pictures that you've already found.", block16, block17);
    static StoryBlock block13 = new StoryBlock("You're suprised at your strength and are able to punch him several times before you are slightly lifted out of your fog. Aware of what you need to do to save Noah and the rest of the group you kill yourself.", "", ">>>");
    static StoryBlock block12 = new StoryBlock("He doesn't react well and is completely disturbed by your comments. You remain locked in the house when he leaves and eventually you pass away, you spirit sticking around to haunt the house.", "", ">>>");
    static StoryBlock block11 = new StoryBlock("The fact that the voice is telling you to hurt your friend really freaks you out. You decide to leave the room in an attempt to escape the voice and head to the basement.", "", "Go to the basement.");
    static StoryBlock block10 = new StoryBlock("Something has overcome you and you feel like you need to hurt or even kill Noah in order to save yourself", "Try to explain what you're feeling to Noah with a hope that he'll understand and make sure nothing happens.", "You lunge at Noah.", block12, block13);
    static StoryBlock block8 = new StoryBlock("The door is locked and won't budge. The girl moves closer and her screams get louder. You aren't sure what happens after you pass out from the excruciating pain in your head.", "", ">>>");
    static StoryBlock block9 = new StoryBlock("Despite the broken glass around the window, you manage to climb out onto the roof. As Noah steps out after you he is dragged back into the room. You jump off the roof into some bushes and start running not looking back.", "", ">>>");
    static StoryBlock block7 = new StoryBlock("You've uspet the girl. A deafening scream comes from her mouth and her face shifts from innocent to demented. The door to the room slams shut, the windows shatter and the lights go out leaving you and Noah in pitch black.", "You and Noah try to find you way to the bedroom door.", "You go towards the shattered windows, the only source of any light.", block8, block9);
    static StoryBlock block6 = new StoryBlock("She meets your introduction with a smile and tells you that this is the house that she used to live in. You ask her what her name is and she responds with Jess. She asks you to help her leave the house and you're not sure how to break it to her that you don't know how to.", "", ">>>");
    static StoryBlock block5 = new StoryBlock("Still standing in the doorway you ask Noah if he heard the man telling you to go into the room. He says that its been silent this whole time. You continue to hear this disembodied voice, but it now tells you that Noah cannot be trusted and you have to hurt him in order to save yourself.", "You agree with the man, Noah can't be trusted.", "You refuse to turn your back on your best friend.", block10, block11);
    static StoryBlock block4 = new StoryBlock("You take a few steps into the room. Suddenly, the figure of a small girl appears in the room.", "Address the girl kindly and ask if she needs any help.", "Address the girl agressively.", block6, block7);
    static StoryBlock block3 = new StoryBlock("Once you're both sitting on the bed, you make small talk discussing what you think the rest of the group is doing in the living room.", "Change the subject to talk about the history of this house.", "Continue talking about your friends and other things going on in your life.", block14, block15);
    static StoryBlock block2 = new StoryBlock("As you're standing in the doorway you hear a disembodied voice demanding that you move into the bedroom.", "Listen to the voice and move into the room.", "Ignore the voice and stay standing in the doorway.", block4, block5);
    static StoryBlock block1 = new StoryBlock("Just you and Noah head upstairs. You follow Noah towards what seems to be a bedroom. As you start to enter the room, you feel something holding you back making you hesitant to enter the room.", "Stay standing in the doorway of the bedroom.", "Sit down on the bed in the room with Noah.", block2, block3);

    //KITCHEN
    static StoryBlock block32 = new StoryBlock("You head back to the entrance of the house. You, Noah, Matthew, and Natalie decide to try investigating the basement instead.", " ", "Go to the basement.");
    static StoryBlock block31 = new StoryBlock("The silence fills the room after the spirit box is turned off. Noah is the first to speak and suggests that the group call it a night. everyone agrees that they've had enough ghosts for one night and you head back to campus.", "", ">>>");
    static StoryBlock block30 = new StoryBlock("You open the cabinet to find a dead body. You assume it is the previous owner of the house, but are confused as to how he died and how he got here. The group calls the police and you leave the house spooked.", "", ">>>");
    static StoryBlock block29 = new StoryBlock("Jennifer tears up convinced that this spirit is her grandmother who recently passed. After asking more questions the rest of the group seems to agree. You spend the rest of the night sitting on the floor of the kitchen having a conversation with her grandma.", "", ">>>");
    static StoryBlock block28 = new StoryBlock("The man's voice sends chills down your spine. Jennifer flinches and says that she just got scratched. Three distinct scratches slowly appear on her arm. Her and the rest of the group are scared and decide to call it a night. You and Noah decide to keep investigating and head upstairs.", "", "Go upstairs.");
    static StoryBlock block27 = new StoryBlock("Although you don't know anything about this spirit you all insult it however you can. The spirit box bursts into flames and falls from Sam's hands. The fire quickly spreads and traps you in the kitchen. you and your friends die in the fire.", "", ">>>");
    static StoryBlock block26 = new StoryBlock("You ask the ghost what it's name is.", "Tts a man's voice. Tt sounds low and raspy, but you can't make out a name.", "Tt's a woman's voice. She states her name as Genivieve.", block28, block29);
    static StoryBlock block25 = new StoryBlock("Sam leads the investigation and receives aggressive answers through the spirit box.", "Match the energy of the ghost and insult it rather than ask questions.", "Try to deescalate the situation.", block27, block31);
    static StoryBlock block24 = new StoryBlock("You and your friends are unsure what to do as the blood quickly approaches you. Right before it reaches your feet it suddenly stops. You notice that only one cabinet remains closed; the original cabinet.", "Attempt to open the last cabinet.", "Retreat from the kitchen.", block30, block32);
    static StoryBlock block23 = new StoryBlock("You've failed to close the cabinets and you're now covered in the blood. It starts to burn your skin. Your skin blisters and you fall to the ground in excruciating pain. Your friends call for help but you succumb to your wounds before help arrives.", "", ">>>");
    static StoryBlock block22 = new StoryBlock("You ask the spirits to turn on one of your flashlights to prove their presence. Suddenly, Sam's flashflight switches on.", "You panic and turn off the spirit box cutting off communication.", "You continue communicating, now asking questions in an attempt to identify who this spirit is.", block31, block26);
    static StoryBlock block21 = new StoryBlock("As you approach the cabinet containing the blood the rest of the cabinets swing open. What you assume to be blood begins pouring out of every cabinet.", "You attempt to close the cabinets that swung open.", "You back away from the cabinets and cower in the corner of the kitchen with your friends.", block23, block24);
    static StoryBlock block20 = new StoryBlock("You and the group start asking questions as the static of the spirit box fills the room.", "Take the lead and ask the spirits some of your own questions.", "Let the others lead the investigation.", block22, block25);
    static StoryBlock block19 = new StoryBlock("You start a conversation full of small talk which seems to ease everyone's nerves. The conversation continues until Natalie notices blood dripping from one of the kitchen cabinets.", "You investigate the cabinet.", "You choose to leave the cabinet alone.", block21, block20);
    static StoryBlock block18 = new StoryBlock("Your group goes into the kitchen. Its filthy and has an uncomfortable energy.", "You try to make conversation with your friends to avoid why you're really here.", "You turn on the spirit box in an attempt to communicate with the ghosts.", block19, block20);

    //BASEMENT
    static StoryBlock block46 = new StoryBlock("He won't let go so Matthew hits him over the head with a wooden board from the basement. Everyone believes that it really was Noah that was possessed and you leave disturbed.", "", ">>>");
    static StoryBlock block45 = new StoryBlock("You believe Noah but Natalie sides with Matthew. They lock the both of you in the basement and as you and Noah talk you deduce that it was actually Matthew who was possessed", "", ">>>");
    static StoryBlock block44 = new StoryBlock("He begins to punch you and Noah pulls him off of you. Noah tries to talk him out of it, but to no avail. He punches Matthew until he's unconcscious giving the rest of you an opportunity to leave.", "", ">>>");
    static StoryBlock block43 = new StoryBlock("He's able to fight off the possession long enough to let Natalie go and for you to open the door at the top of the stairs. You all leave and immediately take Matthew to a church.", "", ">>>");
    static StoryBlock block42 = new StoryBlock("You back away from Noah and he's shocked that you think its him thats possessed. He grabs onto your shoulders, begging.", "Hear him out as he tries to convince you.", "Fight with all your energy to get away from him.", block45, block46);
    static StoryBlock block41 = new StoryBlock("You back yourself into a corner with Noah and Natalie separating yourself from Matthew. Matthew becomes angry and grabs Natalie throwing her to the ground.", "Try to talk Matthew out of it.", "Pull him off of Natalie, shifting his attention to you.", block43, block44);
    static StoryBlock block40 = new StoryBlock("You try to open the door but it remains shut. You watch as the demon kills Noah and heads for Natalie. You try your best to fight off the demon once you realize the door wont open but its pointless.", "", ">>>");
    static StoryBlock block39 = new StoryBlock("The demon shifts its attention to you and suddenly you're unable to breathe. Matthew is the only one to try to help you as Natalie and Noah run to the stairs. As you and Matthew struggle with the demon, Natalie and Noah are able to escape.", "", ">>>");
    static StoryBlock block38 = new StoryBlock("The group agrees with you and doubts that the basement is as haunted as people say it is. You decide to head back upstairs.", "", "Go to the kitchen.");
    static StoryBlock block37 = new StoryBlock("This aggression sets off the spirit and a demon physically manifests itself in front of you. The door at the top of the stairs slams shut. The demon attacks Noah.", "Run to try and help Noah.", "Run towards the stairs.", block39, block40);
    static StoryBlock block36 = new StoryBlock("When you start playing you aren't getting any responses so you begin to doubt that this house is haunted.", "You start to interect with the spirits more aggresively in an attempt to get any response.", "You continue playing the ouija board the same way.", block37, block38);
    static StoryBlock block35 = new StoryBlock("Your friends start communicating and make contact with a spirit. The conversation continues and everyone begins to feel untrustworthy towards each other. Someone in the group has been possessed.", "It seems like Matthew is possessed.", "It seems like Noah is possessed.", block41, block42);
    static StoryBlock block34 = new StoryBlock("You feel anxious but Noah, Matthew, and Natalie show no indications of fear. Matthew pulls a ouija board from his backpack.", "You decide to sit this one out and just watch.", "You join in on the game.", block35, block36);
    static StoryBlock block33 = new StoryBlock("You head down the stairs into the basement with Noah, Natalie, and Matthew. This is rumored to be where satanic rituals took place and as you reach the botton of the stairs you see a faint pentagram on the floor.", "Sit on the pentagram with the rest of the group.", "Stay standing at the botton of the stairs while the rest of the group sits on the floor.", block34, block35);


    public Animator animator;
    public Animator musicChanger;
    private int levelToLoad = 0;

    public void FadeToLevel(int LevelName){
        levelToLoad = LevelName;
        Debug.Log(levelToLoad);
        animator.SetTrigger("FadeOut");
        musicChanger.SetTrigger("FadeOut");
        StartCoroutine(ExecuteAfterTime(2));
        Debug.Log(levelToLoad);
    }

    IEnumerator ExecuteAfterTime(float time)
    {
     yield return new WaitForSeconds(time);
        SceneManager.LoadScene(levelToLoad);
    }

    public void upstairsChosen(){
        FadeToLevel(1);
    }

    public void kitchenChosen(){
        FadeToLevel(2);
    }

    public void basementChosen(){
        FadeToLevel(3);
    }
    
    public GameObject Sam, Matthew, Noah, Natalie, Jennifer;

    public void continuestory(){

        startLevel.SetActive(false);
        playLevel.SetActive(true);
        
        if ((SceneManager.GetActiveScene().buildIndex) == 1){
            DisplayBlock(block1);
            Noah.GetComponent<Animation>().Play("noah_up");
        }
        else if((SceneManager.GetActiveScene().buildIndex) ==2){
            DisplayBlock(block18);
            Noah.GetComponent<Animation>().Play("noah_up");
            Matthew.GetComponent<Animation>().Play("matthew_Up");
            Sam.GetComponent<Animation>().Play("sam_Up");
            Natalie.GetComponent<Animation>().Play("natalie_Up");
            Jennifer.GetComponent<Animation>().Play("jennifer_Up");
        }
        else if((SceneManager.GetActiveScene().buildIndex) == 3){
            DisplayBlock(block33);
            Noah.GetComponent<Animation>().Play("noah_up");
            Matthew.GetComponent<Animation>().Play("matthew_Up");
            Natalie.GetComponent<Animation>().Play("natalie_Up");
        }
    }

    void DisplayBlock(StoryBlock block) {
        mainText.text = block.story;
        option1.GetComponentInChildren<Text>().text = block.option1Text;
        option2.GetComponentInChildren<Text>().text = block.option2Text;
        currentBlock = block;
    }

    public void Button1Clicked() {
        DisplayBlock(currentBlock.option1Block);
    }

    public void Button2Clicked(){
         if(currentBlock.option2Text == "Go to the kitchen."){
            option2.GetComponent<Button>().onClick.AddListener(delegate {FadeToLevel(2); });
        }
        else if(currentBlock.option2Text == "Go to the basement."){
            option2.GetComponent<Button>().onClick.AddListener(delegate() {FadeToLevel(3); });
        }
        else if(currentBlock.option2Text == "Go upstairs."){
            option2.GetComponent<Button>().onClick.AddListener(delegate() {FadeToLevel(1); });
        }
        else if(currentBlock.option2Text == ">>>"){
            option2.GetComponent<Button>().onClick.AddListener(delegate() {FadeToLevel(4); });
        }
        else{
            DisplayBlock(currentBlock.option2Block);
        }

    }

    public void playAgain(){
        FadeToLevel(0);
    }

    public void QuitGame(){
       Application.Quit();
       Debug.Log("QUIT!");
   }
}


