using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

/*
 * Author Brennan J.C Kersey
 * Script Purpose: To actively manage and diplay timer, handle input of player name, display scoreboard, and save scores for when game is shut off
 */

public class TimerScript : MonoBehaviour
{
    //public GameObject timeManger; 
    private GameObject player;
    public Text gameTimerText; // text where timer is continuously updated and displayed
    public GameObject menuButton; //button that takes the player to the main menu
    public GameObject nametaker; // reference object for Inputfield for player name
    //public Dictionary<float, string> myDictionary = new Dictionary<float, string>();
    public InputField playername; // place for player name input 
    public GameObject timeHolder; // reference object for holding the entire timer
    public GameObject boardHolder;// reference object for holding 
    public Text leaderBoardText; // text in which the leaderboard is displayed
    float gameTimer = 0f; // initial time for the game timer
    bool finished = false; // fboolean for telling when the player has died
    bool gameFinished = false; // boolean indicating game over
    float referenceToDelete; // float value of the score that needs to be removed 
    public float[] Leaderslots = new float[] { 0, 0, 0, 0, 0 }; // array of floats to indicate scores
    public List<Score> scoreList= new List<Score>();// a list for associating scores with player names
    

    public class Score                      // basic score class for holding player scores
        {
       
        public string playername;
        public float score;

        public Score(string playername, float score) // constructor for Score
        {
            this.playername = playername;
            this.score = score;
        }
    }

    void Start()
    {
        if(!Directory.Exists("C:\\Documents2")) // creates directory for save file if it does not already exist
        {
            Directory.CreateDirectory("C:\\Documents2");
            print("new directory made");
        }
        if (!File.Exists("C:\\Documents2\\Scoresheet.json")) // creates save file if it does not already exist
        {
            print("no such file exist but we can make one");
            using (StreamWriter writer = File.AppendText("C:\\Documents2\\Scoresheet.json"))
            {
                writer.WriteLine("{\"playername\":\"ZAC\",\"score\":5400.0}");
                writer.WriteLine("{\"playername\":\"VSH\",\"score\":3600.0}");
                writer.WriteLine("{\"playername\":\"MAT\",\"score\":2400.0}");
                writer.WriteLine("{\"playername\":\"SPE\",\"score\":2100.0}");
                writer.WriteLine("{\"playername\":\"BRE\",\"score\":3000.0}");
            }
        }
        else    // reads in the scores one by one in the save file as a json item and translates it into a Score object then adds to Score list
        {
            StreamReader file = new System.IO.StreamReader("C:\\Documents2\\Scoresheet.json");
            string[] lines = File.ReadAllLines("C:\\Documents2\\Scoresheet.json");
            for(int i=0;i<lines.Length;i++)
            {
                Score newScore = JsonUtility.FromJson<Score>(lines[i]);
                scoreList.Add(newScore);
            }

            foreach(Score score in scoreList)
            {
                addToLeaderSlots(score.score);
            }
            createLeaderBoard();
            file.Close();
        }
        finished = false;
        
    }
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
       //print("Player is " + player.name);
        if (player == null) // checks to see if player object is still alive if not initiates game over method
        {
            endGame();
        }
        if(finished==false) // conditional used to update timer string in game display
        {
            gameTimer += Time.deltaTime;

            int seconds = (int)(gameTimer % 60);
            int minutes = (int)(gameTimer / 60) % 60;
            int hours = (int)(gameTimer / 3600) % 24;

            string timerString = string.Format("{0:0}:{1:00}:{2:00}", hours, minutes, seconds);

            gameTimerText.text = timerString;
            //gameTimerText.text = gameTimer.ToString();
        }
        
        
            
        //}
        if(finished==true && playername.text.Length==3&& gameFinished==false) // checks to see if the newly made score made the high score board
        {
            nametaker.SetActive(false);
            bool newHighscore = newHighScore(gameTimer);
            if (newHighscore == true)
            {
                addToLeaderSlots(gameTimer);
                Score newScore = new Score(playername.text.ToUpper(),gameTimer);
                scoreList.Add(newScore);
            }
            printScoreList();
            print(playername.text);
            timeHolder.SetActive(false);
            displayLeaderboard(); // displays leaderboard to player
            gameFinished = true;
        }
       
    }

   public bool newHighScore(float score) // checks to see if new score is higher then first index(due to the nature of the score sorting logic the first index in the float array will always be the lowest player score)
    {
        if(score>Leaderslots[0])
        {
            return true;
        }

        return false;
    }

    public void printScoreList() // method used for debugging allows for checking of scores as added
    {
        string listOfScores = "This is scorelist: ";
        foreach(Score score in scoreList)
        {
            listOfScores += " Name: " + score.playername + "   " + "Score: " + score.score + ", ";
        }
        print(listOfScores);
    }

    public void addToLeaderSlots(float timescore) // method responsible for sortng the array of float scores
    {

        int indexofPlacement = returnPlacementIndex(timescore);
        

        if (indexofPlacement > -1)
        {
            referenceToDelete = Leaderslots[0];
            Score scoreToRemove = scoreList.Find(x=>x.score==referenceToDelete); // used to remove reference to uneeded score
            scoreList.Remove(scoreToRemove);
            for(int i=0;i<indexofPlacement;i++)
            {
              Leaderslots[i] = Leaderslots[i + 1];
            }
            Leaderslots[indexofPlacement]=timescore;
        }

        
    }

    public int returnPlacementIndex(float timescore) // method used to find the index where the score needs to placed in float array
    {
       for (int i = 0; i < Leaderslots.Length; i++)
        {
            //print("This is Leaderslot at "+i+": "+Leaderslots[i]);
            if ( ((int)timescore)>((int)Leaderslots[4]) ) //Leaderslots[4] == 0
            {
                return 4;
            }
            else if (  ((int)(Leaderslots[i])) > ((int)timescore))
            {
                return i - 1;
            }
            //else
           // {
                //print("nope");
            //}
        }
        return -10;

        //print("Timescore is " + timescore);
        
    }

    public void createLeaderBoard() // method to show scoreboard in console log
    {
        string LeaderBoard = "Leaderboard is: ";

        for (int i = 0; i < Leaderslots.Length; i++)
        {
            LeaderBoard += " Leaderboard[" + i + "]: " + Leaderslots[i] + ", ";
        }
        print(LeaderBoard);
    }
    public void displayLeaderboard() // method responsible for displaying the scoreboard to the player in game
    {
        timeHolder.SetActive(false);
        leaderBoardText.text = "Leaderboard"+ "\n"+ "___________"+"\n";
        for(int i=5; i>0;i--)
        {
            Score currentScore = scoreList.Find(x => x.score == Leaderslots[i - 1]);
            string result=currentScore.playername;
            //myDictionary.TryGetValue(Leaderslots[i-1], out result);
            int seconds = (int)(Leaderslots[i-1] % 60);
            int minutes = (int)(Leaderslots[i - 1] / 60) % 60;
            int hours = (int)(Leaderslots[i - 1] / 3600) % 24;

            string timerString = result+": "+string.Format("{0:0}:{1:00}:{2:00}", hours, minutes, seconds);

            leaderBoardText.text += (timerString + "\n");
        }
        boardHolder.SetActive(true);
        menuButton.SetActive(true);
        writeToJSON();
    }
    public void writeToJSON() // saves the current list to the json file
    {
        StreamWriter writer = new StreamWriter("C:\\Documents2\\Scoresheet.json");
        foreach (Score score in scoreList)
        {
            string toJSON = JsonUtility.ToJson(score);
            //print(toJSON);
            writer.WriteLine(toJSON);
        }
        writer.Close();
    }
    public void endGame()// method for  triggering game over sequence
    {
        finished = true;
        nametaker.SetActive(true);
    }
}
