using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using AssetsInputController;


namespace AssetsInputController
{
    public class AssetInput : MonoBehaviour
    {
        public bool run;
        public bool crouch;
        public bool interactuar;
        public bool use;
        public bool pause;
        public bool puzzle;
        public bool flashlight;
        public bool closePuzzle;
        public bool cambio;
        


        public void OnRun(InputValue value)
        {
            RunInput(value.isPressed);
        }
        public void OnCrouch(InputValue value)
        {
            CrouchInput(value.isPressed);
        }
        public void OnInteractuar(InputValue value)
        {
            InteractuarInput(value.isPressed);
        }
        public void OnUse(InputValue value)
        {
            UseInput(value.isPressed);
        }
        public void OnPause(InputValue value)
        {
            PauseInput(value.isPressed);
        }
        public void OnPuzzle(InputValue value)
        {
            PuzzleInput(value.isPressed);
        }

        public void OnFlashlight(InputValue value)
        {
            FlashlightInput(value.isPressed);
        }
        public void OnClosePuzzle(InputValue value)
        {
            ClosePuzzleInput(value.isPressed);
        }
        public void OnCambio(InputValue value)
        {
            CambioInput(value.isPressed);
        }


        public void RunInput(bool newRunState)
        {
            run = newRunState;
        }
        public void CrouchInput(bool newCrouchState)
        {
            crouch = newCrouchState;
        }
        public void InteractuarInput(bool newInteractuarState)
        {
            interactuar = newInteractuarState;
        }
        public void UseInput(bool newUseState)
        {
            use = newUseState;
        }

        public void PauseInput(bool newUseState)
        {
            pause = newUseState;
        }

        public void PuzzleInput(bool newUseState)
        {
            puzzle = newUseState;
        }

        public void FlashlightInput(bool newUseState)
        {
            flashlight = newUseState;
        }
        public void ClosePuzzleInput(bool newUseState)
        {
            closePuzzle = newUseState;
        }
        public void CambioInput(bool newUseState)
        {
            cambio = newUseState;
        }

    }

}
