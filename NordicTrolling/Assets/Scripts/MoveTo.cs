using UnityEngine;
using UnityEngine.AI;

namespace Movement
{
    public class MoveTo : MonoBehaviour
    {
        #region Fields
        [SerializeField]
        private Transform goal;

        private NavMeshAgent agent;
        #endregion

        #region Unity Methods
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if (goal == null) return;
            agent.destination = goal.position; //new Vector3(goal.position.x, 0, goal.position.z);
        }

        #endregion

        #region Public Methods
        public void SetGoal(GameObject gameObject)
        {
            goal = gameObject.transform;
        }
        #endregion
    }
}
