using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CommandPattern.RebineKey
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private MoveTheCube cudeThatMove;

        private Command buttonW;
        private Command buttonA;
        private Command buttonS;
        private Command buttonD;

        private Stack<Command> undoCommands = new Stack<Command>();
        private Stack<Command> redoCommands = new Stack<Command>();

        private bool isReplaying = false;

        private Vector3 startPos;

        private const float Replay_Pause_Timer = 0.5f;

        private void Start()
        {

            buttonW = new MoveForwardCommand(cudeThatMove);
            buttonA = new MoveLeftCommand(cudeThatMove);
            buttonS = new MoveBackwardCommand(cudeThatMove);
            buttonD = new MoveRightCommand(cudeThatMove);

            startPos = cudeThatMove.transform.position;

        }

        private void Update()
        {
            if (isReplaying)
            {
                return;
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                ExecuteNewCommand(buttonW);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                ExecuteNewCommand(buttonA);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                ExecuteNewCommand(buttonS);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                ExecuteNewCommand(buttonD);
            }
            else if (Input.GetKeyDown(KeyCode.U))
            {
                if (undoCommands.Count == 0)
                {
                    Debug.Log("Can't undo because we are back where we start");
                }
                else
                {
                    Command lastCommand = undoCommands.Pop();
                    lastCommand.Undo();
                    redoCommands.Push(lastCommand);
                }
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                if (redoCommands.Count == 0)
                {
                    Debug.Log("Can't redo because we are at the end");
                }
                else
                {
                    Command nextCommand = redoCommands.Pop();
                    nextCommand.Execute();
                    undoCommands.Push(nextCommand);
                }
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SwapKeys(ref buttonA, ref buttonD);
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                StartCoroutine(Replay());
                isReplaying = true;
            }

        }

        private void ExecuteNewCommand(Command commandButton)
        {
            commandButton.Execute();

            undoCommands.Push(commandButton);

            redoCommands.Clear();
        }

        private void SwapKeys(ref Command key1, ref Command key2)
        {
            Command temp = key1;

            key1 = key2;

            key2 = temp;
        }

        private IEnumerator Replay()
        {
            cudeThatMove.transform.position = startPos;

            yield return new WaitForSeconds(Replay_Pause_Timer);

            Command[] oldCommands = undoCommands.ToArray();

            for (int i = oldCommands.Length - 1; i >= 0; i--)
            {
                Command currentCommand = oldCommands[i];

                currentCommand.Execute();

                yield return new WaitForSeconds(Replay_Pause_Timer);
            }

            isReplaying = false;
        }

    }
}