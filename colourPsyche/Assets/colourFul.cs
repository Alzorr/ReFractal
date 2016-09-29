using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class colourFul : MonoBehaviour
{
    public int winnerColour;
    public Color winner;
    public string[] winnerName;
    public Text answerText;
    public Image answer;
    public Canvas screen;
    public Color[] colours;
    public Button[] buttons;
    public float timer;
    public Scrollbar clock;
    public Button retry;
    public Text retryText;
    public int maxTime;

    public Queue<Button> targetQueue = new Queue<Button>();

    // Use this for initialization
    void Start ()
    {
        answerText.enabled = false;
        screen = this.gameObject.GetComponent<Canvas>();
        retry.GetComponent<Image>().enabled = false;
        retryText.enabled = false;
        timer = maxTime;
        colours = new Color[7];
        colours[0] = Color.red;
        colours[1] = Color.magenta;
        colours[2] = Color.blue;
        colours[3] = Color.yellow;
        colours[4] = Color.green;
        colours[5] = Color.cyan;
        colours[6] = Color.black;

        colourLevel();
        winningColour();

    }
	
	// Update is called once per frame
	void Update ()
    {
        timer = timer - Time.smoothDeltaTime;
        clock.GetComponent<Scrollbar>().size = clock.GetComponent<Scrollbar>().size - Time.smoothDeltaTime/maxTime;
        if (timer > 0.0f)
        {
            retry.GetComponent<Image>().enabled = false;
        }
        if (timer <= 0.0f)
        {
            retry.GetComponent<Image>().enabled = true;
            retryText.enabled = true;
            retryText.text = "Retry?";         
        }
	}

    public void restartLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void winningColour()
    {
       
        switch(Random.Range(0,6))
        {
            case 0:
                answerText.enabled = true;
                winner = colours[0];
                winnerColour = 0;
                answer.color = colours[Random.Range(1, 6)];
                answerText.text = winnerName[0].ToString();
                answerText.color = colours[Random.Range(1, 6)];
                while(answerText.color == answer.color)
                {
                    answerText.color = colours[Random.Range(1, 6)];
                }
                break;

            case 1:
                answerText.enabled = true;
                winner = colours[1];
                winnerColour = 1;
                answer.color = colours[Random.Range(0,6)];
                answerText.text = winnerName[1].ToString();
                answerText.color = colours[Random.Range(0,6)];
                while (answerText.color == winner)
                {
                    answerText.color = colours[Random.Range(0, 6)];
                }
                while (answer.color == winner)
                {
                    answer.color = colours[Random.Range(0, 6)];
                }
                break;

            case 2:
                answerText.enabled = true;
                winner = colours[2];
                winnerColour = 2;
                answer.color = colours[Random.Range(0, 6)];
                answerText.text = winnerName[2].ToString();
                answerText.color = colours[Random.Range(0, 6)];
                while (answerText.color == winner)
                {
                    answerText.color = colours[Random.Range(0, 6)];
                }
                while (answer.color == winner)
                {
                    answer.color = colours[Random.Range(0, 6)];
                }
                break;

            case 3:
                answerText.enabled = true;
                winner = colours[3];
                winnerColour = 3;
                answer.color = colours[Random.Range(0, 6)];
                answerText.text = winnerName[3].ToString();
                answerText.color = colours[Random.Range(0, 6)];
                while (answerText.color == winner)
                {
                    answerText.color = colours[Random.Range(0, 6)];
                }
                while (answer.color == winner)
                {
                    answer.color = colours[Random.Range(0, 6)];
                }
                break;

            case 4:
                answerText.enabled = true;
                winner = colours[4];
                winnerColour = 4;
                answer.color = colours[Random.Range(0, 6)];
                answerText.text = winnerName[4].ToString();
                answerText.color = colours[Random.Range(0, 6)];
                while (answerText.color == winner)
                {
                    answerText.color = colours[Random.Range(0, 6)];
                }
                while (answer.color == winner)
                {
                    answer.color = colours[Random.Range(0, 6)];
                }
                break;

            case 5:
                answerText.enabled = true;
                winner = colours[5];
                winnerColour = 5;
                answer.color = colours[Random.Range(0, 6)];
                answerText.text = winnerName[5].ToString();
                answerText.color = colours[Random.Range(0, 6)];
                while (answerText.color == winner)
                {
                    answerText.color = colours[Random.Range(0, 6)];
                }
                while (answer.color == winner)
                {
                    answer.color = colours[Random.Range(0, 6)];
                }
                break;

            case 6:
                answerText.enabled = true;
                winner = colours[6];
                winnerColour = 6;
                answer.color = colours[Random.Range(0, 6)];
                answerText.text = winnerName[6].ToString();
                answerText.color = colours[Random.Range(0, 6)];
                while (answerText.color == winner)
                {
                    answerText.color = colours[Random.Range(0, 6)];
                }
                while (answer.color == winner)
                {
                    answer.color = colours[Random.Range(0, 6)];
                }
                break;
        }

        for (int button=0; button< buttons.Length; button++)
        {
            if (buttons[button].GetComponent<reFract>().colourID == winnerColour)
            {
                buttons[button].GetComponent<reFract>().isTarget = true;
                targetQueue.Enqueue(buttons[button]);
                targetQueue.Peek().GetComponent<reFract>().currentTarget = true;
            }
        }

    }
    public void colourLevel()
    {
        //For each colours in the array, place two blocks
        for (int colour = 0; colour <= colours.Length; colour++)
        {
            colourBlock(colour);
            colourBlock(colour);
        }
        //fill the rest randomly
        fillRandom();
    }

    private int blockSize = 0;
    private int boardWidth = 8;
    public int tileCount = 80;

    private void colourBlock(int colour)
    {
        //Choose a random position, check it isn't coloured.
        int chosenPosition = Random.Range(0, buttons.Length);
        if (buttons[chosenPosition].GetComponent<reFract>().coloured == false)
        {
            blockSize = 5;
          //  buttons[chosenPosition].GetComponent<reFract>().colourID = colour;
            colourTile(chosenPosition, colour);

            //Tap neighbouring blocks, up to 4 times.
            //RIGHT
            if (chosenPosition + 1 < buttons.Length)
            {
                if (blockSize > 0 && buttons[chosenPosition + 1].GetComponent<reFract>().coloured == false)
                    colourTile(chosenPosition + 1, colour);
            }
            //LEFT
            if (chosenPosition - 1 >= 0)
            {
                if (blockSize > 0 && buttons[chosenPosition - 1].GetComponent<reFract>().coloured == false && chosenPosition - 1 >= 0)
                    colourTile(chosenPosition - 1, colour);
            }
            //UP
            if (chosenPosition - boardWidth >= 0)
            {
                if (blockSize > 0 && buttons[chosenPosition - boardWidth].GetComponent<reFract>().coloured == false && chosenPosition - boardWidth >= 0)
                    colourTile(chosenPosition - boardWidth, colour);
            }
            //DIAGONAL ABOVE
            if (chosenPosition - boardWidth - 1 >= 0)
            {
                if (blockSize > 0 && buttons[chosenPosition - boardWidth + 1].GetComponent<reFract>().coloured == false && chosenPosition - boardWidth + 1 >= 0)
                    colourTile(chosenPosition - boardWidth + 1, colour);
                if (blockSize > 0 && buttons[chosenPosition - boardWidth - 1].GetComponent<reFract>().coloured == false && chosenPosition - boardWidth - 1 >= 0)
                    colourTile(chosenPosition - boardWidth - 1, colour);
            }
            //DOWN
            if (chosenPosition + boardWidth < buttons.Length)
            {
                if (blockSize > 0 && buttons[chosenPosition + boardWidth].GetComponent<reFract>().coloured == false && chosenPosition + boardWidth < buttons.Length)
                    colourTile(chosenPosition + boardWidth, colour);
            }
            //DIAGONAL BELOW
            if (chosenPosition + boardWidth + 1 < buttons.Length)
            {
                if (blockSize > 0 && buttons[chosenPosition + boardWidth + 1].GetComponent<reFract>().coloured == false && chosenPosition + boardWidth + 1 < buttons.Length)
                    colourTile(chosenPosition + boardWidth + 1, colour);
                if (blockSize > 0 && buttons[chosenPosition + boardWidth - 1].GetComponent<reFract>().coloured == false && chosenPosition + boardWidth - 1 < buttons.Length)
                    colourTile(chosenPosition + boardWidth - 1, colour);
            }
        }
        //if it's already coloured, try again
        else if (tileCount >0)
            colourBlock(colour);
    }

    private void fillRandom()
    {
        //Fill any uncoloured tiles with random colours
        for (int button = 0; button <= buttons.Length-1; button++)
        {
            if (buttons[button].GetComponent<reFract>().coloured == false)
                buttons[button].GetComponent<reFract>().colourID = Random.Range(0, colours.Length);
        }
    }

    private void colourTile(int position, int colour)
    {
        buttons[position].GetComponent<reFract>().colourID = colour;
        blockSize -= 1;
        tileCount -= 1;
    }

    public void findNextTarget()
    {
        Debug.Log("you got it");
        targetQueue.Dequeue();
        if (targetQueue.Count == 0)
            Debug.Log("you won!");
        else
            targetQueue.Peek().GetComponent<reFract>().currentTarget = true;

        for (int button = 0; button < buttons.Length; button++)
            buttons[button].GetComponent<reFract>().coloured = false;

        nextLevel();

       //colourLevel();
      //  winningColour();
    }

    public void gameOver()
    {
        retry.GetComponent<Image>().enabled = true;
        retryText.enabled = true;
        retryText.text = "Retry?";
    }

    public void nextLevel()
    {
        for (int button = 0; button < buttons.Length; button++)
            buttons[button].GetComponent<reFract>().colourID = 99;

        colourLevel();
        winningColour();
        Debug.Log ("new Level");

        //add 1 to score.
    }
}
