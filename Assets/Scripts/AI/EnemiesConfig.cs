using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using Platformer.Views;

namespace Platformer.AI
{
    [Serializable]
    public struct AIConfig
    {
        public float speed;
        public float minDistanceToTarget;
        public Transform[] waypoints;
        internal float minSqrDistanceToTarget;
    }

    public class EnemiesConfig : MonoBehaviour
    {
        [Header("Simple AI")]
        [SerializeField] private AIConfig _simplePatrolAIConfig;
        [SerializeField] private EnemyView _simplePatrolAIView;

        [Header("Stalker AI")]
        [SerializeField] private AIConfig _stalkerAIConfig;
        [SerializeField] private EnemyView _stalkerAIView;
        [SerializeField] private Seeker _stalkerAISeeker;
        [SerializeField] private Transform _stalkerAITarget;

        [Header("Protector AI")]
        [SerializeField] private EnemyView _protectorAIView;
        [SerializeField] private AIDestinationSetter _protectorAIDestinationSetter;
        [SerializeField] private AIPatrolPath _protectorAIPatrolPath;
        [SerializeField] private LevelObjectTrigger _protectedZoneTrigger;
        [SerializeField] private Transform[] _protectorWaypoints;
        
        private SimplePatrolAI _simplePatrolAI;
        private StalkerAI _stalkerAI;
        private ProtectorAI _protectorAI;
        private ProtectedZone _protectedZone;

        private void Start()
        {
            if (_simplePatrolAIView != null)
                _simplePatrolAI = new SimplePatrolAI(_simplePatrolAIView, new SimplePatrolModel(_simplePatrolAIConfig));

            if (_stalkerAIView != null)
            {
                _stalkerAI = new StalkerAI(_stalkerAIView, new StalkerAIModel(_stalkerAIConfig), _stalkerAISeeker,
                    _stalkerAITarget);
                InvokeRepeating(nameof(RecalculateAIPath), 0.0f, 1.0f);
            }

            if (_protectorAIView != null)
            {
                _protectorAI = new ProtectorAI(_protectorAIView, new PatrolAIModel(_protectorWaypoints),
                    _protectorAIDestinationSetter, _protectorAIPatrolPath);
                _protectorAI.Init();

                _protectedZone = new ProtectedZone(_protectedZoneTrigger, new List<IProtector> {_protectorAI});
                _protectedZone.Init();
            }
        }

        private void FixedUpdate()
        {
            if (_simplePatrolAI != null) _simplePatrolAI.FixedUpdate();
            if (_stalkerAI != null) _stalkerAI.FixedUpdate();
        }

        private void OnDestroy()
        {
            _protectorAI?.Deinit();
            _protectedZone?.Deinit();
        }

        private void RecalculateAIPath()
        {
            _stalkerAI?.RecalculatePath();
        }
    }
}
