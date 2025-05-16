using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeMonkey.CSharpCourse.L2040_Enums {

    public class TurnBasedStrategy : MonoBehaviour {

        private enum PlayerAction {
            NoEnemy,
            NoPathToEnemy,
            MovingTowardEnemy,
            AttackingEnemy
        }

        private enum State {
            LookingForEnemy,
            MovingToEnemy,
            AttackingEnemy,
        }

        private enum TutorialStage {
            Stage_1,
            Stage_2,
            Stage_3,
            Stage_4,
        }

        private State state;


        private void Start() {
            PlayerAction playerAction = PlayerAction.NoPathToEnemy;
            Debug.Log((int)playerAction);

            {
                TutorialStage tutorialStage = TutorialStage.Stage_1;
                tutorialStage++;
                string tutorialStageString = tutorialStage.ToString();
                Debug.Log(Enum.Parse<TutorialStage>(tutorialStageString));
            }

            Debug.Log("-------");
            foreach (TutorialStage tutorialStage in Enum.GetValues(typeof(TutorialStage))) {
                Debug.Log(tutorialStage);
            }
        }

        private void HandleState() {
            switch (state) {
                case State.MovingToEnemy:
                    // Moving to enemy logic
                    break;
                case State.LookingForEnemy:
                    break;
                case State.AttackingEnemy:
                    break;
            }
        }

        private PlayerAction GetNextPlayerAction() {
            if (!PlayerHasEnemy()) {
                return PlayerAction.NoEnemy;
            }
            if (!HasPathToEnemy()) {
                return PlayerAction.NoPathToEnemy;
            }
            if (!PlayerWithinAttackDistance()) {
                return PlayerAction.MovingTowardEnemy;
            } else {
                return PlayerAction.AttackingEnemy;
            }
        }

        private bool PlayerHasEnemy() {
            return false;
        }

        private bool HasPathToEnemy() {
            return false;
        }

        private bool PlayerWithinAttackDistance() {
            return false;
        }


    }


}