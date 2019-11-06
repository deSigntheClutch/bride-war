using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PRINCESS.Core
{
    // action switcher, switch state between move and fighter(attack)
    public class ActionScheduler : MonoBehaviour
    {
        CAction currentAction;
        public void StartAction(CAction action) {
            if (currentAction == action) return;
            if (currentAction != null) {
                currentAction.Cancel();
            }
            currentAction = action;
        }

        public void CancelCurrentAction() {
            StartAction(null);
        }
    }
}

