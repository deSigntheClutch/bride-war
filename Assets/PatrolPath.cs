using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PRINCESS.Controller
{
    public class PatrolPath : MonoBehaviour
    {
        const float patrolGizmosRadius = 0.5f;
        private void OnDrawGizmos()
        {
            for(int i = 0; i < transform.childCount; i++) {
                int j = GetNextIndex(i);
                Gizmos.DrawSphere(transform.GetChild(i).position, patrolGizmosRadius);
                Gizmos.DrawLine(GetPatrolPointPosition(i), GetPatrolPointPosition(j));     
            }
        }
        public int GetNextIndex(int i) {
            if (i + 1 >= transform.childCount) return 0;
            return i + 1;
        }
        public Vector3 GetPatrolPointPosition(int i) {
            return transform.GetChild(i).position;
        }
    }
}

