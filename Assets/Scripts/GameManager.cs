using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;
public class GameManager : MonoBehaviour
{
    private int totalBlueInHouse, totalRedInHouse, totalGreenInHouse, totalYellowInHouse;// will count the number of player in the house
    int[] TotalInHouse;
    public GameObject frameRed, frameGreen, frameBlue, frameYellow;
    public GameObject[] Frames;
    // game object for every player
    public GameObject redPlayerI_Border, redPlayerII_Border, redPlayerIII_Border, redPlayerIV_Border;
    public GameObject greenPlayerI_Border, greenPlayerII_Border, greenPlayerIII_Border, greenPlayerIV_Border;
    public GameObject bluePlayerI_Border, bluePlayerII_Border, bluePlayerIII_Border, bluePlayerIV_Border;
    public GameObject yellowPlayerI_Border, yellowPlayerII_Border, yellowPlayerIII_Border, yellowPlayerIV_Border;
    public GameObject[] RedBorders;
    public GameObject[] GreenBorders;
    public GameObject[] BlueBorders;
    public GameObject[] YellowBorders;

    //possition of every player
    public Vector3 redPlayerI_Pos, redPlayerII_Pos, redPlayerIII_Pos, redPlayerIV_Pos;
    public Vector3 greenPlayerI_Pos, greenPlayerII_Pos, greenPlayerIII_Pos, greenPlayerIV_Pos;
    public Vector3 bluePlayerI_Pos, bluePlayerII_Pos, bluePlayerIII_Pos, bluePlayerIV_Pos;
    public Vector3 yellowPlayerI_Pos, yellowPlayerII_Pos, yellowPlayerIII_Pos, yellowPlayerIV_Pos;
    public Vector3[] RedPos;
    public Vector3[] GreenPos;
    public Vector3[] BluePos;
    public Vector3[] YellowPos;


    //buttons to pick a players
    public Button RedPlayerI_Button, RedPlayerII_Button, RedPlayerIII_Button, RedPlayerIV_Button;
    public Button GreenPlayerI_Button, GreenPlayerII_Button, GreenPlayerIII_Button, GreenPlayerIV_Button;
    public Button BluePlayerI_Button, BluePlayerII_Button, BluePlayerIII_Button, BluePlayerIV_Button;
    public Button YellowPlayerI_Button, YellowPlayerII_Button, YellowPlayerIII_Button, YellowPlayerIV_Button;

    public Vector3[] RedStartingPoints;
    public Vector3[] GreenStartingPoints;
    public Vector3[] BlueStartingPoints;
    public Vector3[] YellowStartingPoints;

    public Button[] RedButtons;
    public Button[] GreenButtons;
    public Button[] BlueButtons;
    public Button[] YellowButtons;


    public Transform diceRoll;
    public Button DiceRollButton;
    public Transform redDiceRollPos, greenDiceRollPos, blueDiceRollPos, yellowDiceRollPos;
    public Transform[] DicePositions;


    public GameObject blueScreen, greenScreen, redScreen, yellowScreen;
    public GameObject[] Screens;  
    public Text blueRankText, greenRankText, redRankText, yellowRankText;

    private string playerTurn = "RED";
    private string currentPlayer = "none";
    private string currentPlayerName;

    //Player movment controlers
    public GameObject redPlayerI, redPlayerII, redPlayerIII, redPlayerIV;
    public GameObject greenPlayerI, greenPlayerII, greenPlayerIII, greenPlayerIV;
    public GameObject bluePlayerI, bluePlayerII, bluePlayerIII, bluePlayerIV;
    public GameObject yellowPlayerI, yellowPlayerII, yellowPlayerIII, yellowPlayerIV;

    public GameObject[] RedPlayers;
    public GameObject[] GreenPlayers;
    public GameObject[] BluePlayers;
    public GameObject[] YellowPlayers;

    // player steps on his path
     int redPlayerI_Steps, redPlayerII_Steps, redPlayerIII_Steps, redPlayerIV_Steps ;
     int greenPlayerI_Steps, greenPlayerII_Steps, greenPlayerIII_Steps, greenPlayerIV_Steps ;
     int bluePlayerI_Steps, bluePlayerII_Steps, bluePlayerIII_Steps, bluePlayerIV_Steps ;
     int yellowPlayerI_Steps, yellowPlayerII_Steps, yellowPlayerIII_Steps, yellowPlayerIV_Steps ;


     int[] RedPlayer_Steps;
     int[] GreenPlayer_Steps;
     int[] BluePlayer_Steps;
     int[] YellowPlayer_Steps;

    // Dice resulte
    private int selectDiceNumAnimation;
    //--------------- Dice Animations------
    public GameObject dice1_Roll_Animation;
    public GameObject dice2_Roll_Animation;
    public GameObject dice3_Roll_Animation;
    public GameObject dice4_Roll_Animation;
    public GameObject dice5_Roll_Animation;
    public GameObject dice6_Roll_Animation;
    public GameObject[] diceRollAnimations;


    // Players movement corenspoding to blocks...
    public List<GameObject> redMovementBlocks = new List<GameObject>();
    public List<GameObject> greenMovementBlocks = new List<GameObject>();
    public List<GameObject> yellowMovementBlocks = new List<GameObject>();
    public List<GameObject> blueMovementBlocks = new List<GameObject>();

    // Random generation of dice numbers...
    private System.Random randoNo;
    public GameObject confirmScreen;
    public GameObject gameCompletedScreen;

    public void deactivateAllPlayerButton(Button[] Red, Button[] Green, Button[] Blue, Button[] Yellow)
    {
        for (int i = 0; i < Red.Length; i++)
        {
            Red[i].interactable = false;
            Green[i].interactable = false;
            Blue[i].interactable = false;
            Yellow[i].interactable = false;

        }
    }
    public void deactivateAllPlayerBorders(GameObject[] Red, GameObject[] Green, GameObject[] Blue, GameObject[] Yellow)
    {
        for (int i = 0; i < Red.Length; i++)
        {
            Red[i].SetActive(false);
            Green[i].SetActive(false);
            Blue[i].SetActive(false);
            Yellow[i].SetActive(false);

        }
    }
    public void activateAllPlayerButton(Button[] Red, Button[] Green, Button[] Blue, Button[] Yellow)
    {
        for (int i = 0; i < Red.Length; i++)
        {
            Red[i].interactable = true;
            Green[i].interactable = true;
            Blue[i].interactable = true;
            Yellow[i].interactable = true;

        }
    }
    public void activateAllPlayerBorders(GameObject[] Red, GameObject[] Green, GameObject[] Blue, GameObject[] Yellow)
    {
        for (int i = 0; i < Red.Length; i++)
        {
            Red[i].SetActive(true);
            Green[i].SetActive(true);
            Blue[i].SetActive(true);
            Yellow[i].SetActive(true);

        }
    }


    public void deactivatePlayerButton(Button[] obj)
    {
        for (int i = 0; i < obj.Length; i++)
        {
            if (obj[i] != null)
            {
                obj[i].interactable = false;
            }
        }
    }
    public void activatePlayerButton(Button[] obj)
    {
        for (int i = 0; i < obj.Length; i++)
        {
            if (obj[i] != null)
            {
                obj[i].interactable = true;
            }
        }
    }
    public void deactivatePlayerBorders(GameObject[] obj)
    {
        for (int i = 0; i < obj.Length; i++)
        {
            if (obj[i] != null)
            {
                obj[i].SetActive(false);
            }
        }
    }
    public void activatePlayerBorders(GameObject[] obj)
    {
        for (int i = 0; i < obj.Length; i++)
        {
            if (obj[i] != null)
            {
                obj[i].SetActive(true);
            }
        }
    }
    // initialize Players steps arrays 
    private void InitializePlayerSteps()
    {
        RedPlayer_Steps = new int[] { redPlayerI_Steps, redPlayerII_Steps, redPlayerIII_Steps, redPlayerIV_Steps };
        GreenPlayer_Steps = new int[] { greenPlayerI_Steps, greenPlayerII_Steps, greenPlayerIII_Steps, greenPlayerIV_Steps };
        BluePlayer_Steps = new int[] { bluePlayerI_Steps, bluePlayerII_Steps, bluePlayerIII_Steps, bluePlayerIV_Steps };
        YellowPlayer_Steps = new int[] { yellowPlayerI_Steps, yellowPlayerII_Steps, yellowPlayerIII_Steps, yellowPlayerIV_Steps };
        TotalInHouse = new int[] {  totalRedInHouse, totalGreenInHouse, totalBlueInHouse,  totalYellowInHouse };
    }
    /// <summary>
    /// checks if after player movment his possition is the same possition of another player in the bord , 
    /// if so the other player will move back to his starting point
    /// </summary>
    /// <param name="PlayerNewPosition"></param>
    /// <param name="playerTurn"></param>
    void CheckCollisions(Vector3 PlayerNewPosition, String playerTurn)
    {
        for (int i = 0; i < RedPlayers.Length; i++)
        {
            switch (playerTurn)
            {
                case "RED":
                    if (PlayerNewPosition.Equals(GreenPos[i]))
                    {
                        GreenPlayers[i].transform.position = GreenStartingPoints[i];
                        GreenPos[i] = GreenStartingPoints[i];
                        GreenPlayer_Steps[i] = 0;
                    }
                    else if (PlayerNewPosition.Equals(BluePos[i]))
                    {
                        BluePlayers[i].transform.position = BlueStartingPoints[i];
                        BluePos[i] = BlueStartingPoints[i];

                        BluePlayer_Steps[i] = 0;
                    }
                    else if (PlayerNewPosition.Equals(YellowPos[i]))
                    {
                        YellowPlayers[i].transform.position = YellowStartingPoints[i];
                        YellowPos[i] = YellowStartingPoints[i];

                        YellowPlayer_Steps[i] = 0;
                    }
                    break; // Add break statement here

                case "BLUE":
                    if (PlayerNewPosition.Equals(GreenPos[i]))
                    {
                        GreenPlayers[i].transform.position = GreenStartingPoints[i];
                        GreenPos[i] = GreenStartingPoints[i];
                        GreenPlayer_Steps[i] = 0;

                    }
                    else if (PlayerNewPosition.Equals(RedPos[i]))
                    {
                        RedPlayers[i].transform.position = RedStartingPoints[i];
                        RedPos[i] = RedStartingPoints[i];

                        RedPlayer_Steps[i] = 0;

                    }
                    else if (PlayerNewPosition.Equals(YellowPos[i]))
                    {
                        YellowPlayers[i].transform.position = YellowStartingPoints[i];
                        YellowPos[i] = YellowStartingPoints[i];

                        YellowPlayer_Steps[i] = 0;

                    }
                    break; // Add break statement here

                case "GREEN":
                    if (PlayerNewPosition.Equals(BluePos[i]))
                    {
                        BluePlayers[i].transform.position = BlueStartingPoints[i];
                        BluePos[i] = BlueStartingPoints[i];

                        BluePlayer_Steps[i] = 0;

                    }
                    else if (PlayerNewPosition.Equals(RedPos[i]))
                    {
                        RedPlayers[i].transform.position = RedStartingPoints[i];
                        RedPos[i] = RedStartingPoints[i];
                        RedPlayer_Steps[i] = 0;

                    }
                    else if (PlayerNewPosition.Equals(YellowPos[i]))
                    {
                        YellowPlayers[i].transform.position = YellowStartingPoints[i];
                        YellowPos[i] = YellowStartingPoints[i];
                        YellowPlayer_Steps[i] = 0;

                    }
                    break; // Add break statement here

                case "YELLOW":
                    if (PlayerNewPosition.Equals(BluePos[i]))
                    {
                        BluePlayers[i].transform.position = BlueStartingPoints[i];
                        BluePlayer_Steps[i] = 0;
                        BluePos[i] = BlueStartingPoints[i];


                    }
                    else if (PlayerNewPosition.Equals(RedPos[i]))
                    {
                        RedPlayers[i].transform.position = RedStartingPoints[i];
                        RedPos[i] = RedStartingPoints[i];

                        RedPlayer_Steps[i] = 0;

                    }
                    else if (PlayerNewPosition.Equals(GreenPos[i]))
                    {
                        GreenPlayers[i].transform.position = GreenStartingPoints[i];
                        GreenPos[i] = GreenStartingPoints[i];

                        GreenPlayer_Steps[i] = 0;

                    }
                    break; // Add break statement here
            }
        }
    }

    //===== UI Button ===================
    public void yesGameCompleted()
    {
        SoundManagerScript.buttonAudioSource.Play();
        SceneManager.LoadScene("Lucky");
    }

    public void noGameCompleted()
    {
        SoundManagerScript.buttonAudioSource.Play();
        SceneManager.LoadScene("MainScene");
    }

    public void yesMethod()
    {
        SoundManagerScript.buttonAudioSource.Play();
        SceneManager.LoadScene("MainScene");
    }

    public void noMethod()
    {
        SoundManagerScript.buttonAudioSource.Play();
        confirmScreen.SetActive(false);
    }

    public void ExitMethod()
    {
        SoundManagerScript.buttonAudioSource.Play();
        confirmScreen.SetActive(true);
    }

    //========= Activations functions =========================
   

    // -============== GAME COMPLETED ROUTINE ==========================================================
    IEnumerator GameCompletedRoutine()
    {
        yield return new WaitForSeconds(1.5f);
        gameCompletedScreen.SetActive(true);
    }


    /// <summary>
    /// determain the place of the dice and in case that any of the players has reached the house with all characters
    /// his winning screen will be activated
    /// </summary>
    void InitializeDice()
    {
        //=========== Turning the wining player screen ================
        for (int i = 0; i < TotalInHouse.Length; i++)
        {
            if (TotalInHouse[i] > 3 )
            {
                Screens[i].SetActive(true); 
            }
        }
        DiceRollButton.interactable = true;
        for (int i = 0; i < diceRollAnimations.Length; i++)
        {
            diceRollAnimations[i].SetActive(false);
        }
  
        switch (MainMenuScript.howManyPlayers)
        {
            case 2:
                if (playerTurn == "RED")
                {
                    diceRoll.position = redDiceRollPos.position;
                    for (int i = 0; i < Frames.Length; i++)
                    {
                        if (i == 0) Frames[i].SetActive(true);
                        else Frames[i].SetActive(false);
                    }
          
                }
                if (playerTurn == "GREEN")
                {
                    diceRoll.position = greenDiceRollPos.position;
                    for (int i = 0; i < Frames.Length; i++)
                    {
                        if (i == 1) Frames[i].SetActive(true);
                        else Frames[i].SetActive(false);
                    }
    
                }
                deactivateAllPlayerBorders(RedBorders, GreenBorders, BlueBorders, YellowBorders);
                deactivateAllPlayerButton(RedButtons, GreenButtons, BlueButtons, YellowButtons);

                break;

            case 3:
                if (playerTurn == "RED")
                {
                    diceRoll.position = redDiceRollPos.position;
                    for (int i = 0; i < Frames.Length; i++)
                    {
                        if (i == 0) Frames[i].SetActive(true);
                        else Frames[i].SetActive(false);
                    }
                }
                if (playerTurn == "YELLOW")
                {
                    diceRoll.position = yellowDiceRollPos.position;
                    for (int i = 0; i < Frames.Length; i++)
                    {
                        if (i == 3) Frames[i].SetActive(true);
                        else Frames[i].SetActive(false);
                    }
                }
                if (playerTurn == "BLUE")
                {
                    diceRoll.position = blueDiceRollPos.position;

                    for (int i = 0; i < Frames.Length; i++)
                    {
                        if (i == 2) Frames[i].SetActive(true);
                        else Frames[i].SetActive(false);
                    }
                }
                deactivateAllPlayerBorders(RedBorders, GreenBorders, BlueBorders, YellowBorders);
                deactivateAllPlayerButton(RedButtons, GreenButtons, BlueButtons, YellowButtons);


                break;

            case 4:
                if (playerTurn == "RED")
                {
                    diceRoll.position = redDiceRollPos.position;
                    for (int i = 0; i < Frames.Length; i++)
                    {
                        if (i == 0) Frames[i].SetActive(true);
                        else Frames[i].SetActive(false);
                    }
                }
                if (playerTurn == "GREEN")
                {
                    diceRoll.position = greenDiceRollPos.position;

                    for (int i = 0; i < Frames.Length; i++)
                    {
                        if (i == 1) Frames[i].SetActive(true);
                        else Frames[i].SetActive(false);
                    }
                }
                if (playerTurn == "BLUE")
                {
                    diceRoll.position = blueDiceRollPos.position;

                    for (int i = 0; i < Frames.Length; i++)
                    {
                        if (i == 2) Frames[i].SetActive(true);
                        else Frames[i].SetActive(false);
                    }
                }
                if (playerTurn == "YELLOW")
                {
                    diceRoll.position = yellowDiceRollPos.position;

                    for (int i = 0; i < Frames.Length; i++)
                    {
                        if (i == 3) Frames[i].SetActive(true);
                        else Frames[i].SetActive(false);
                    }
                }

               
                deactivateAllPlayerBorders(RedBorders,GreenBorders,BlueBorders, YellowBorders);
                deactivateAllPlayerButton(RedButtons,GreenButtons, BlueButtons, YellowButtons);   

                break;
        }


    }

    // Click on Roll Button on Dice UI 
    public void DiceRoll()
    {
        SoundManagerScript.diceAudioSource.Play();
        DiceRollButton.interactable = false;

        selectDiceNumAnimation = randoNo.Next(1, 7);

        diceRollAnimations[selectDiceNumAnimation - 1].SetActive(true);
       

        StartCoroutine("PlayersNotInitialized");
    }
    IEnumerator PlayersNotInitialized()
    {
        Debug.Log("dice anomation = " + selectDiceNumAnimation);
        yield return new WaitForSeconds(0.8f);
        // Game Start Initial position of each player (Red, Green, Blue, Yellow)
        switch (playerTurn)
        {



            case "RED":

                for (int i = 0; i < RedPlayers.Length; i++)
                {
                    if ((redMovementBlocks.Count - RedPlayer_Steps[i]) >= selectDiceNumAnimation && RedPlayer_Steps[i] > 0 && (redMovementBlocks.Count > RedPlayer_Steps[i]))
                    {
                        RedBorders[i].SetActive(true);
                        RedButtons[i].interactable = true;
                    }
                    else if (selectDiceNumAnimation == 6 && RedPlayer_Steps[i] == 0)//the player never moved
                    {

                        RedBorders[i].SetActive(true);
                        RedButtons[i].interactable = true;
                    }
                    else
                    {
                        RedBorders[i].SetActive(false);
                        RedButtons[i].interactable = false;
                    }


                }

                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////              
                //====================== PLAYERS DON'T HAVE ANY MOVES ,SWITCH TO NEXT TURN===============================
                if (!redPlayerI_Border.activeInHierarchy && !redPlayerII_Border.activeInHierarchy &&
                   !redPlayerIII_Border.activeInHierarchy && !redPlayerIV_Border.activeInHierarchy)
                {
                    deactivatePlayerButton(RedButtons);

                    switch (MainMenuScript.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "GREEN";
                            InitializeDice();
                            break;

                        case 3:
                            playerTurn = "BLUE";
                            InitializeDice();
                            break;

                        case 4:
                            playerTurn = "BLUE";
                            InitializeDice();
                            break;
                    }
                }
                break;

            case "BLUE":
                Debug.Log("blue??");
                for (int i = 0; i < BluePlayers.Length; i++)
                {
                    if ((blueMovementBlocks.Count - BluePlayer_Steps[i]) >= selectDiceNumAnimation && BluePlayer_Steps[i] > 0 && (blueMovementBlocks.Count > BluePlayer_Steps[i]))
                    {
                        BlueBorders[i].SetActive(true);
                        BlueButtons[i].interactable = true;
                    }
                    else if (selectDiceNumAnimation == 6 && BluePlayer_Steps[i] == 0)//the player never moved
                    {

                        BlueBorders[i].SetActive(true);
                        BlueButtons[i].interactable = true;
                    }
                    else
                    {
                        BlueBorders[i].SetActive(false);
                        BlueButtons[i].interactable = false;
                    }


                }


                //====================== PLAYERS DON'T HAVE ANY MOVES ,SWITCH TO NEXT TURN===============================
                if (!bluePlayerI_Border.activeInHierarchy && !bluePlayerII_Border.activeInHierarchy &&
                    !bluePlayerIII_Border.activeInHierarchy && !bluePlayerIV_Border.activeInHierarchy)
                {
                    deactivatePlayerButton(BlueButtons);

                    switch (MainMenuScript.howManyPlayers)
                    {
                        case 2:
                            //BLUE PLAYER NOT AVAILABLE
                            break;

                        case 3:
                            playerTurn = "YELLOW";
                            InitializeDice();
                            break;

                        case 4:
                            playerTurn = "GREEN";
                            InitializeDice();
                            break;
                    }
                }
                break;

            case "GREEN":
                Debug.Log("Green???");
                //==================== CONDITION FOR BORDER GLOW ========================
                for (int i = 0; i < GreenPlayers.Length; i++)
                {
                    
                
                    if ((greenMovementBlocks.Count - GreenPlayer_Steps[i]) >= selectDiceNumAnimation && GreenPlayer_Steps[i] > 0 && (greenMovementBlocks.Count > GreenPlayer_Steps[i]))
                    {
                        GreenBorders[i].SetActive(true);
                        GreenButtons[i].interactable = true;
                    }
                    else if (selectDiceNumAnimation == 6 && GreenPlayer_Steps[i] == 0)//the player never moved
                    {

                        GreenBorders[i].SetActive(true);
                        GreenButtons[i].interactable = true;
                    }
                    else
                    {
                        GreenBorders[i].SetActive(false);
                        GreenButtons[i].interactable = false;
                    }

                }
                

                //====================== PLAYERS DON'T HAVE ANY MOVES ,SWITCH TO NEXT TURN===============================
                if (!greenPlayerI_Border.activeInHierarchy && !greenPlayerII_Border.activeInHierarchy &&
                    !greenPlayerIII_Border.activeInHierarchy && !greenPlayerIV_Border.activeInHierarchy)
                {
                    deactivatePlayerButton(GreenButtons);

                    switch (MainMenuScript.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "RED";
                            InitializeDice();
                            break;

                        case 3:
                            //GREEN PLAYER IS NOT AVAILABLE
                            break;

                        case 4:
                            playerTurn = "YELLOW";
                            InitializeDice();
                            break;
                    }
                }
                break;

            case "YELLOW":
                Debug.Log("Yellow???");
                //==================== CONDITION FOR BORDER GLOW ========================
                for (int i = 0; i < YellowPlayers.Length; i++)
                {


                    if ((yellowMovementBlocks.Count - YellowPlayer_Steps[i]) >= selectDiceNumAnimation && YellowPlayer_Steps[i] > 0 && (yellowMovementBlocks.Count > YellowPlayer_Steps[i]))
                    {
                        YellowBorders[i].SetActive(true);
                        YellowButtons[i].interactable = true;
                    }
                    else if (selectDiceNumAnimation == 6 && YellowPlayer_Steps[i] == 0)//the player never moved
                    {

                        YellowBorders[i].SetActive(true);
                        YellowButtons[i].interactable = true;
                    }
                    else
                    {
                        YellowBorders[i].SetActive(false);
                        YellowButtons[i].interactable = false;
                    }

                }

                //====================== PLAYERS DON'T HAVE ANY MOVES ,SWITCH TO NEXT TURN===============================
                if (!yellowPlayerI_Border.activeInHierarchy && !yellowPlayerII_Border.activeInHierarchy &&
                    !yellowPlayerIII_Border.activeInHierarchy && !yellowPlayerIV_Border.activeInHierarchy)
                {
                    deactivatePlayerButton(YellowButtons);

                    switch (MainMenuScript.howManyPlayers)
                    {
                        case 2:
                            //yellow PLAYER NOT AVAILABLE
                            break;

                        case 3:
                            playerTurn = "RED";
                            InitializeDice();
                            break;

                        case 4:
                            playerTurn = "RED";
                            InitializeDice();
                            break;
                    }
                }
                break;
        }
    }

    //=============================== RED PLAYERS MOVEMENT ===========================================================
    /// <summary>
    /// All players UI are the same , deals with the player movment across the mapp
    /// only the Red player is documented but it is the same for all other players
    /// </summary>
    /// <param name="index"></param>
    public void RedPlayersUI(int index)
    {
        SoundManagerScript.playerAudioSource.Play();
        deactivatePlayerBorders(RedBorders);
        deactivatePlayerButton(RedButtons);

        // if the player steps acording to the dice roll is not bigger the the movement blocks
        if (playerTurn == "RED" && (redMovementBlocks.Count - RedPlayer_Steps[index]) > selectDiceNumAnimation) // 4 > 4
        {
            // if the player has allrady left the starting point
            if (RedPlayer_Steps[index] > 0)
            {
                Vector3[] redPlayer_Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    redPlayer_Path[i] = redMovementBlocks[RedPlayer_Steps[index] + i].transform.position;
                }

                RedPlayer_Steps[index] += selectDiceNumAnimation;

                if (selectDiceNumAnimation == 6)
                {
                    playerTurn = "RED";
                }
                else
                {
                    switch (MainMenuScript.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "GREEN";
                            break;

                        case 3:
                            playerTurn = "BLUE";
                            break;

                        case 4:
                            playerTurn = "BLUE";
                            break;
                    }
                }


                currentPlayerName = "RED PLAYER "+(index+1);

                if (redPlayer_Path.Length > 1)
                {
                    iTween.MoveTo(RedPlayers[index], iTween.Hash("path", redPlayer_Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                    RedPos[index] = redPlayer_Path[redPlayer_Path.Length-1];
                }

                else
                {
                    iTween.MoveTo(RedPlayers[index], iTween.Hash("position", redPlayer_Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                    RedPos[index] = redPlayer_Path[0];
                }
                //after moving check if the player moved to other player possition
                CheckCollisions(RedPos[index], "RED");


            }
            else
            {
                // if the player is still in the starting point and the dice roll is "6"
                if (selectDiceNumAnimation == 6 && RedPlayer_Steps[index] == 0)
                {
                    Vector3[] redPlayer_Path = new Vector3[selectDiceNumAnimation];
                    redPlayer_Path[0] = redMovementBlocks[RedPlayer_Steps[index]].transform.position;
                    RedPlayer_Steps[index] += 1;
                    playerTurn = "RED";
                    currentPlayerName = "RED PLAYER "+(index+1);
                    iTween.MoveTo(RedPlayers[index], iTween.Hash("position", redPlayer_Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                    RedPos[index] = redPlayer_Path[0];

               
                }
            }
        }
        else
        {
            // Condition when Player Coin is reached successfully in House....(Actual Number of required moves to get into the House)
            if (playerTurn == "RED" && (redMovementBlocks.Count - RedPlayer_Steps[index]) == selectDiceNumAnimation)
            {
                Vector3[] redPlayer_Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    redPlayer_Path[i] = redMovementBlocks[RedPlayer_Steps[index] + i].transform.position;
                }

                RedPlayer_Steps[index] += selectDiceNumAnimation;

                playerTurn = "RED";


                if (redPlayer_Path.Length > 1)
                {
                    iTween.MoveTo(RedPlayers[index], iTween.Hash("path", redPlayer_Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                    RedPos[index] = redPlayer_Path[redPlayer_Path.Length-1];


                }
                else
                {
                    iTween.MoveTo(RedPlayers[index], iTween.Hash("position", redPlayer_Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                    RedPos[index] = redPlayer_Path[0];

                }
                CheckCollisions(RedPos[index], "RED");


                totalRedInHouse += 1;
                Debug.Log("Cool !!");
                RedButtons[index].enabled = false;
            }
            else
            {
                // if the dice roll is biger then the player steps left to get to the house 
                Debug.Log("You need " + (redMovementBlocks.Count - RedPlayer_Steps[index]).ToString() + " to enter into the house.");
                int count = 0;
                for (int i = 0; i < RedPlayer_Steps.Length; i++)
                {
                    
                    if(index != i)
                    {
                        count += RedPlayer_Steps[i];
                    }
                }
                if (count == 0 && selectDiceNumAnimation != 6)
                {
                    switch (MainMenuScript.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "GREEN";
                            break;

                        case 3:
                            playerTurn = "BLUE";
                            break;

                        case 4:
                            playerTurn = "BLUE";
                            break;
                    }
                    InitializeDice();
                }
            }
        }
    }
 
    //==================================== GREEN PLAYERS MOVEMENT =================================================================

    public void GreenPlayersUI(int index)
    {
        SoundManagerScript.playerAudioSource.Play();
        deactivatePlayerBorders(GreenBorders);
        deactivatePlayerButton(GreenButtons);


        if (playerTurn == "GREEN" && (greenMovementBlocks.Count - GreenPlayer_Steps[index]) > selectDiceNumAnimation) // 4 > 4
        {
            if (GreenPlayer_Steps[index] > 0)
            {
                Vector3[] greenPlayer_Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    greenPlayer_Path[i] = greenMovementBlocks[GreenPlayer_Steps[index] + i].transform.position;
                }

                GreenPlayer_Steps[index] += selectDiceNumAnimation;

                if (selectDiceNumAnimation == 6)
                {
                    playerTurn = "GREEN";
                }
                else
                {
                    switch (MainMenuScript.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "RED";
                            break;

                        case 3:
                            //player is not available
                            break;

                        case 4:
                            playerTurn = "YELLOW";
                            break;
                    }
                }


                currentPlayerName = "GREEN PLAYER " + (index + 1);

                if (greenPlayer_Path.Length > 1)
                {
                    iTween.MoveTo(GreenPlayers[index], iTween.Hash("path", greenPlayer_Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                    GreenPos[index] = greenPlayer_Path[greenPlayer_Path.Length - 1];

                }
                else
                {
                    iTween.MoveTo(GreenPlayers[index], iTween.Hash("position", greenPlayer_Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                    GreenPos[index] = greenPlayer_Path[0];

                }
                CheckCollisions(GreenPos[index], "GREEN");

            }
            else
            {
                if (selectDiceNumAnimation == 6 && GreenPlayer_Steps[index] == 0)
                {
                    Vector3[] greenPlayer_Path = new Vector3[selectDiceNumAnimation];
                    greenPlayer_Path[0] = greenMovementBlocks[GreenPlayer_Steps[index]].transform.position;
                    GreenPlayer_Steps[index] += 1;
                    playerTurn = "GREEN";
                    currentPlayerName = "GREEN PLAYER " + (index + 1);
                    iTween.MoveTo(GreenPlayers[index], iTween.Hash("position", greenPlayer_Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                    GreenPos[index] = greenPlayer_Path[0];

                }

            }
        }
        else
        {
            // Condition when Player Coin is reached successfully in House....(Actual Number of required moves to get into the House)
            if (playerTurn == "GREEN" && (greenMovementBlocks.Count - GreenPlayer_Steps[index]) == selectDiceNumAnimation)
            {
                Vector3[] greenPlayer_Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    greenPlayer_Path[i] = greenMovementBlocks[GreenPlayer_Steps[index] + i].transform.position;
                }

                GreenPlayer_Steps[index] += selectDiceNumAnimation;

                playerTurn = "GREEN";


                if (greenPlayer_Path.Length > 1)
                {
                    iTween.MoveTo(GreenPlayers[index], iTween.Hash("path", greenPlayer_Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                    GreenPos[index] = greenPlayer_Path[greenPlayer_Path.Length - 1];

                }
                else
                {
                    iTween.MoveTo(GreenPlayers[index], iTween.Hash("position", greenPlayer_Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                    GreenPos[index] = greenPlayer_Path[0];
                }
                CheckCollisions(GreenPos[index], "GREEN");


                totalRedInHouse += 1;
                Debug.Log("Cool !!");
                GreenButtons[index].enabled = false;
            }
            else
            {
                Debug.Log("You need " + (greenMovementBlocks.Count - GreenPlayer_Steps[index]).ToString() + " to enter into the house.");
                int count = 0;
                for (int i = 0; i < GreenPlayer_Steps.Length; i++)
                {

                    if (index != i)
                    {
                        count += GreenPlayer_Steps[i];
                    }
                }
                if (count == 0 && selectDiceNumAnimation != 6)
                {
                    switch (MainMenuScript.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "RED";
                            break;

                        case 3:
                            //player is not available
                            break;

                        case 4:
                            playerTurn = "YELLOW";
                            break;
                    }
                    InitializeDice();
                }
            }
        }
    }

        //==================================== BLUE PLAYERS MOVEMENT =================================================================

    public void BluePlayersUI(int index)
    {
        SoundManagerScript.playerAudioSource.Play();
        deactivatePlayerBorders(BlueBorders);
        deactivatePlayerButton(BlueButtons);


        if (playerTurn == "BLUE" && (blueMovementBlocks.Count - BluePlayer_Steps[index]) > selectDiceNumAnimation) // 4 > 4
        {
            if (BluePlayer_Steps[index] > 0)
            {
                Vector3[] bluePlayerPath = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    bluePlayerPath[i] = blueMovementBlocks[BluePlayer_Steps[index] + i].transform.position;
                }

                BluePlayer_Steps[index] += selectDiceNumAnimation;

                if (selectDiceNumAnimation == 6)
                {
                    playerTurn = "BLUE";
                }
                else
                {
                    switch (MainMenuScript.howManyPlayers)
                    {
                        case 2:
                            //Player is not available
                            break;

                        case 3:
                            playerTurn = "YELLOW";
                            break;

                        case 4:
                            playerTurn = "GREEN";
                            break;
                    }
                }


                currentPlayerName = "BLUE PLAYER " + (index + 1);

                if (bluePlayerPath.Length > 1)
                {
                    iTween.MoveTo(BluePlayers[index], iTween.Hash("path", bluePlayerPath, "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                    BluePos[index] = bluePlayerPath[bluePlayerPath.Length - 1];

                }
                else
                {
                    iTween.MoveTo(BluePlayers[index], iTween.Hash("position", bluePlayerPath[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                    BluePos[index] = bluePlayerPath[0];

                }
                CheckCollisions(BluePos[index], "BLUE");

            }
            else
            {
                if (selectDiceNumAnimation == 6 && BluePlayer_Steps[index] == 0)
                {
                    Vector3[] bluePlayerPath = new Vector3[selectDiceNumAnimation];
                    bluePlayerPath[0] = blueMovementBlocks[BluePlayer_Steps[index]].transform.position;
                    BluePlayer_Steps[index] += 1;
                    playerTurn = "BLUE";
                    currentPlayerName = "Blue PLAYER " + (index + 1);
                    iTween.MoveTo(BluePlayers[index], iTween.Hash("position", bluePlayerPath[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                    BluePos[index] = bluePlayerPath[0];

                }
            }
        }
        else
        {
            // Condition when Player Coin is reached successfully in House....(Actual Number of required moves to get into the House)
            if (playerTurn == "BLUE" && (blueMovementBlocks.Count - BluePlayer_Steps[index]) == selectDiceNumAnimation)
            {
                Vector3[] bluePlayerPath = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    bluePlayerPath[i] = blueMovementBlocks[BluePlayer_Steps[index] + i].transform.position;
                }

                BluePlayer_Steps[index] += selectDiceNumAnimation;

                playerTurn = "BLUE";


                if (bluePlayerPath.Length > 1)
                {
                    iTween.MoveTo(BluePlayers[index], iTween.Hash("path", bluePlayerPath, "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                    BluePos[index] = bluePlayerPath[bluePlayerPath.Length - 1];
                }

                else
                {
                    iTween.MoveTo(BluePlayers[index], iTween.Hash("position", bluePlayerPath[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                    BluePos[index] = bluePlayerPath[0];

                }
                CheckCollisions(BluePos[index], "BLUE");


                totalRedInHouse += 1;
                Debug.Log("Cool !!");
                BlueButtons[index].enabled = false;
            }
            else
            {
                Debug.Log("You need " + (blueMovementBlocks.Count - BluePlayer_Steps[index]).ToString() + " to enter into the house.");
                int count = 0;
                for (int i = 0; i < BluePlayer_Steps.Length; i++)
                {

                    if (index != i)
                    {
                        count += BluePlayer_Steps[i];
                    }
                }
                if (count == 0 && selectDiceNumAnimation != 6)
                {
                    switch (MainMenuScript.howManyPlayers)
                    {
                        case 2:
                            //Player is not available
                            break;

                        case 3:
                            playerTurn = "YELLOW";
                            break;

                        case 4:
                            playerTurn = "GREEN";
                            break;
                    }
                    InitializeDice();
                }
            }
        }
    }

    //==================================== YELLOW PLAYERS MOVEMENT =============================================================

    public void YellowPlayersUI(int index)
    {
        SoundManagerScript.playerAudioSource.Play();
        deactivatePlayerBorders(YellowBorders);
        deactivatePlayerButton(YellowButtons);


        if (playerTurn == "YELLOW" && (yellowMovementBlocks.Count - YellowPlayer_Steps[index]) > selectDiceNumAnimation) // 4 > 4
        {
            if (YellowPlayer_Steps[index] > 0)
            {
                Vector3[] yellowPlayerPath = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    yellowPlayerPath[i] = yellowMovementBlocks[YellowPlayer_Steps[index] + i].transform.position;
                }

                YellowPlayer_Steps[index] += selectDiceNumAnimation;

                if (selectDiceNumAnimation == 6)
                {
                    playerTurn = "YELLOW";
                }
                else
                {
                    switch (MainMenuScript.howManyPlayers)
                    {
                        case 2:
                            //Player is not available
                            break;

                        case 3:
                            playerTurn = "RED";
                            break;

                        case 4:
                            playerTurn = "RED";
                            break;
                    }
                }


                currentPlayerName = "YELLOW PLAYER " + (index + 1);

                if (yellowPlayerPath.Length > 1)
                {
                    iTween.MoveTo(YellowPlayers[index], iTween.Hash("path", yellowPlayerPath, "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                    YellowPos[index] = yellowPlayerPath[yellowPlayerPath.Length - 1];
                }
                else
                {
                    iTween.MoveTo(YellowPlayers[index], iTween.Hash("position", yellowPlayerPath[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                    YellowPos[index] = yellowPlayerPath[0];

                }
                CheckCollisions(YellowPos[index], "YELLOW");

            }
            else
            {
                if (selectDiceNumAnimation == 6 && YellowPlayer_Steps[index] == 0)
                {
                    Vector3[] yellowPlayerPath = new Vector3[selectDiceNumAnimation];
                    yellowPlayerPath[0] = yellowMovementBlocks[YellowPlayer_Steps[index]].transform.position;
                    YellowPlayer_Steps[index] += 1;
                    playerTurn = "YELLOW";
                    currentPlayerName = "YELLOW PLAYER " + (index + 1);
                    iTween.MoveTo(YellowPlayers[index], iTween.Hash("position", yellowPlayerPath[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                    YellowPos[index] = yellowPlayerPath[0];

                }
            }
        }
        else
        {
            // Condition when Player Coin is reached successfully in House....(Actual Number of required moves to get into the House)
            if (playerTurn == "YELLOW" && (yellowMovementBlocks.Count - YellowPlayer_Steps[index]) == selectDiceNumAnimation)
            {
                Vector3[] yellowPlayerPath = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    yellowPlayerPath[i] = yellowMovementBlocks[YellowPlayer_Steps[index] + i].transform.position;
                }

                YellowPlayer_Steps[index] += selectDiceNumAnimation;

                playerTurn = "YELLOW";


                if (yellowPlayerPath.Length > 1)
                {
                    iTween.MoveTo(YellowPlayers[index], iTween.Hash("path", yellowPlayerPath, "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                    YellowPos[index] = yellowPlayerPath[yellowPlayerPath.Length - 1];
                }
                else
                {
                    iTween.MoveTo(YellowPlayers[index], iTween.Hash("position", yellowPlayerPath[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                    YellowPos[index] = yellowPlayerPath[0];

                }
                CheckCollisions(YellowPos[index], "YELLOW");


                totalRedInHouse += 1;
                Debug.Log("Cool !!");
                YellowButtons[index].enabled = false;
            }
            else
            {
                Debug.Log("You need " + (yellowMovementBlocks.Count - YellowPlayer_Steps[index]).ToString() + " to enter into the house.");
                int count = 0;
                for (int i = 0; i < YellowPlayer_Steps.Length; i++)
                {

                    if (index != i)
                    {
                        count += YellowPlayer_Steps[i];
                    }
                }
                if (count == 0 && selectDiceNumAnimation != 6)
                {
                    switch (MainMenuScript.howManyPlayers)
                    {
                        case 2:
                            //Player is not available
                            break;

                        case 3:
                            playerTurn = "RED";
                            break;

                        case 4:
                            playerTurn = "RED";
                            break;
                    }
                    InitializeDice();
                }
            }
        }
    }
   
        private void Start()
        {
        InitializePlayerSteps();

        DicePositions = new Transform[] { redDiceRollPos, greenDiceRollPos, blueDiceRollPos, yellowDiceRollPos };

        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 30;

        randoNo = new System.Random();
        //deactivating the dice animations
        for (int i = 0; i < diceRollAnimations.Length; i++)
        {
            diceRollAnimations[i].SetActive(false);
        }
        // initializing the players possition and starting points arrays
        for (int i = 0; i < RedPlayers.Length; i++)
        {
            RedPos[i] = RedPlayers[i].transform.position;
            GreenPos[i] = GreenPlayers[i].transform.position;
            BluePos[i] = BluePlayers[i].transform.position;
            YellowPos[i] = YellowPlayers[i].transform.position;
            RedStartingPoints[i] = RedPlayers[i].transform.position;
            GreenStartingPoints[i] = GreenPlayers[i].transform.position;
            BlueStartingPoints[i] = BluePlayers[i].transform.position;
            YellowStartingPoints[i] = YellowPlayers[i].transform.position;

        }


        for (int i = 0; i <RedBorders.Length; i++)
        {
            RedBorders[i].SetActive(false);
            GreenBorders[i].SetActive(false);
            BlueBorders[i].SetActive(false);
            YellowBorders[i].SetActive(false);  
        }
        
        redScreen.SetActive(false);
        greenScreen.SetActive(false);
        yellowScreen.SetActive(false);
        blueScreen.SetActive(false);

        // Initilaizing players here....
        switch (MainMenuScript.howManyPlayers)
        {
            case 2:
                playerTurn = "RED";

                for (int i = 0; i < Frames.Length; i++)
                {
                    if (i == 0) Frames[i].SetActive(true);
                    else Frames[i].SetActive(false);
                }
             
                diceRoll.position = redDiceRollPos.position;
                for (int i = 0; i < BluePlayers.Length; i++)
                {
                    BluePlayers[i].SetActive(false);
                    YellowPlayers[i].SetActive(false);  
                }
           
                break;

            case 3:
                playerTurn = "RED";
                for (int i = 0; i < Frames.Length; i++)
                {
                    if (i == 0) Frames[i].SetActive(true);
                    else Frames[i].SetActive(false);
                }
         

                diceRoll.position = redDiceRollPos.position;
                for (int i = 0; i < GreenPlayers.Length; i++)
                {
                    GreenPlayers[i].SetActive(false);
                }
   
                break;

            case 4:
                playerTurn = "RED";
                for (int i = 0; i < Frames.Length; i++)
                {
                    if (i == 0) Frames[i].SetActive(true);
                    else Frames[i].SetActive(false);
                }

                diceRoll.position = redDiceRollPos.position;
                break;
        }
        Time.timeScale = 1;
    }

    void Update()
    {
        
    }

}



