using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEditor;

public class Buttons : MonoBehaviour
{
    // Materials for every button color
    //[SerializeField] to view them in inspector
    private Material offButton;
    private Material offButtonHighlight;
    private Material onButton;
    private Material onButtonHighlight;

    // Personal Button Info
    private bool buttonOn = false;
    [SerializeField]
    private string buttonName = "";
    // Get child buttonPress Game Object
    private GameObject buttonPress;

    // Button Specific Items
    private AudioMixer masterMixer;

    // Each button type
    //private bool isMuted = false;
    //private bool viewHints = true;
    //private bool viewControllers = true;
    //private bool joystickMove = false;
    //private bool keepHighlights = false;

    // Start is called before the first frame update
    void Start()
    {
        // Assign the button press materials
        offButton = (Material)AssetDatabase.LoadAssetAtPath("Assets/Materials/ButtonPressOff.mat", typeof(Material));
        offButtonHighlight = (Material)AssetDatabase.LoadAssetAtPath("Assets/Materials/ButtonPressOff_Highlight.mat", typeof(Material));
        onButton = (Material)AssetDatabase.LoadAssetAtPath("Assets/Materials/ButtonPressOn.mat", typeof(Material));
        onButtonHighlight = (Material)AssetDatabase.LoadAssetAtPath("Assets/Materials/ButtonPressOn_Highlight.mat", typeof(Material));

        // Assign button specific items
        masterMixer = (AudioMixer)AssetDatabase.LoadAssetAtPath("Assets/Audio/Master.mixer", typeof(AudioMixer));

        // Assign specific button names to simplified name of gameobject
        buttonName = name.Substring(6);

        // Get child buttonPress to change material within script
        buttonPress = transform.GetChild(0).gameObject;

        // Automatically turn specific buttons on at start
        if (buttonName == "Hints" || buttonName == "Controllers") {
            buttonOn = true;
            displayHover();
        }
    }

    // Either add or remove highlight depending if hovering or not
    public void displayHover(bool hover=false)
    {
        Material[] oldMat = buttonPress.GetComponent<Renderer>().sharedMaterials;
        Material[] newMat = oldMat;

        if (buttonOn && hover) {
            newMat[0] = onButtonHighlight;
        } else if (buttonOn) {
            newMat[0] = onButton;
        } else if (hover) {
            newMat[0] = offButtonHighlight;
        } else {
            newMat[0] = offButton;
        }

        buttonPress.GetComponent<Renderer>().sharedMaterials = newMat;
    }

    // Toggles buttonOn
    public void toggleOnOff()
    {
        if (buttonOn){
            buttonOn = false;
        } else {
            buttonOn = true;
        }
        toggle();
    }

    private void toggle()
    {
        if (buttonName == "Mute") {
            mute();
        } else if (buttonName == "Hints") {
            hints();
        } else if (buttonName == "Controllers") {
            controllers();
        } else if (buttonName == "Joystick") {
            joystick();
        } else if (buttonName == "Highlights") {
            highlights();
        }
    }

    // Either mutes or unmutes the master volume [DOESN'T INCLUDE STEAMVR AUDIO]
    private void mute() {
        Debug.Log("Mute");
        if (buttonOn) {
            masterMixer.SetFloat("Vol", -80.0f);
        } else {
            masterMixer.ClearFloat("Vol");
        }
    }

    // Toggle display the controller hints
    private void hints() {
        Debug.Log("hint");
        if (buttonOn) {
            //show hints
        } else {
            //hide hints
        }
    }

    // Toggle display of the controllers
    private void controllers() {
        Debug.Log("controller");
        if (buttonOn) {
            //show controllers
        } else {
            //hide controllers
        }
    }

    // Toggles capability of movement through joystick
    private void joystick() {
        Debug.Log("joystick");
        if (buttonOn) {
            //enable joysticks
        } else {
            //disable joysticks
        }
    }

    // Toggles Highlights to permanently on
    private void highlights() {
        Debug.Log("highlights");
        if (buttonOn) {
            //enable permanent highlights
        } else {
            //disable permanent highlighting
        }
    }

    // Exit the game
    public void exitGame() {

    }

    // Restarts game
    public void restartGame() {

    }
}
