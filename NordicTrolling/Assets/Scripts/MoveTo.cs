using UnityEngine;
using UnityEngine.AI;

namespace Movement
{
    public class MoveTo : MonoBehaviour
    {
        #region Fields
        [SerializeField]
        private Transform goal;
        private Vector3 goalPos;

        private NavMeshAgent agent;
        #endregion

        #region Unity Methods
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if (CheckIfGoalIsNull()) return;
            if( goal != null )
                agent.destination = goal.position; //new Vector3(goal.position.x, 0, goal.position.z);
            else if( goalPos != Vector3.zero )
                agent.destination = goalPos;

            if (CheckIfInEndPosition())
            {
                DisableGoalPosition();
            }
        }

        #endregion

        #region Public Methods
        public void SetGoal(GameObject gameObject)
        {
            goal = gameObject.transform;
        }

        public void SetGoal( Vector3 pos ) {
            goalPos = pos;
        }

        public void SetGoal(Transform transform)
        {
            goal = transform;
        }

        public void DisableGoal()
        {
            goal = null;
        }

        public void DisableGoalPosition()
        {
            goalPos = Vector3.zero;
        }

        public bool CheckIfInEndPosition()
        {
            if (agent.pathPending) return false;
            if (!(agent.remainingDistance <= agent.stoppingDistance)) return false;
            return !agent.hasPath || agent.velocity.sqrMagnitude == 0f;
        }

        public bool CheckIfGoalIsNull()
        {
            return goal == null && goalPos == Vector3.zero;
        }
        #endregion
    }
}
