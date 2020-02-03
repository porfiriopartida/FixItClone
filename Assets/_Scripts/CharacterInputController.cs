using UnityEngine;

//Turn on if you are the character.
public class CharacterInputController : MonoBehaviour
{
    private CharacterController characterController;
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            //networkHandler.move(1);
            characterController.Move(1);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            //networkHandler.move(2);
            characterController.Move(2);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            //networkHandler.move(3);
            characterController.Move(3);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            //networkHandler.move(4);
            characterController.Move(4);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //networkHandler.move(4);
            characterController.Move(5);
        }
    }
}
