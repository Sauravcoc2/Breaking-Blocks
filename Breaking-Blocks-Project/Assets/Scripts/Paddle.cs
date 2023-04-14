using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float maxX = 15f;
    [SerializeField] float minX = 1f;

    //cached references
    GameSession theGameSession;
    Ball theBall;

    // Start is called before the first frame update
    void Start()
    {
        theGameSession = FindObjectOfType<GameSession>();
        theBall = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(mousePositionInUnits); // printing the position of the mouse as per screen width
   
        Vector2 paddlePosition = new Vector2(transform.position.x,transform.position.y); //positioning the mouse on 2d plane as in x-axis and y-axis.

        paddlePosition.x = Mathf.Clamp(GetXPos(),minX,maxX); //Limiting the movement of paddle not to go outside the screen.

        transform.position = paddlePosition; //Changing the position of paddle on the screen
    }

    private float GetXPos()
    {
        if (theGameSession.IsAutoPlayEnabled())
        {
            return theBall.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
