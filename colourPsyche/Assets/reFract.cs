using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class reFract : MonoBehaviour
{
    //ON TILE
    public Image me;
    public Button myself;
    public bool coloured = false;
    public int colourID = 99;
    public colourFul gameManager;
    public bool currentTarget = false;
    public bool isTarget = false;

    void Start()
    {
        myself = GetComponent<Button>();
        myself.onClick.AddListener(OnClick);
    }

    void Update()
    {
        if (colourID <= gameManager.colours.Length -1)
        {
            me = this.gameObject.GetComponent<Image>();
            me.color = gameManager.colours[colourID];
            coloured = true;
        }
        else coloured = false;
    }

    public void OnClick()
    {
        Debug.Log("click");
        if (!currentTarget && !isTarget)
            gameManager.gameOver();

        else
        {
            gameManager.findNextTarget();
          //  gameManager.nextLevel();
        }
            

  //      if(isTarget == true)


     /*   if (currentTarget)
        {
            currentTarget = false;
            gameManager.findNextTarget();
        }*/
      //  else Debug.Log("wrong");
    }

}
