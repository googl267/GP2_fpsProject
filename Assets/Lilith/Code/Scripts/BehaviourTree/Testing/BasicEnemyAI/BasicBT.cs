using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class BasicBT : BTree { 
        // TREE VARIABLES
        public UnityEngine.Transform[] waypoints;

        public static float speed = 2f;
        public static float fovRange = 5f;
        public static float attackRange = 1f;

        protected override Node SetupTree() {
                // LOGIC TREE
                // Selectors - do one when priority switches, interrupt
                // Sequences - do one after another, chain
                // Closer to top of page = higher priority

                Node root = new Selector(new List<Node> {
                        new Sequence(new List<Node>{
                                new CheckEnemyInAttackRange(transform),
                                new TaskAttack(transform),
                        }),
                        new Sequence(new List<Node> {
                                new CheckEnemyInFOVRange(transform),
                                new TaskGoToTarget(transform),
                        }),
                        new TaskPatrol(transform, waypoints),
                });

                return root;
        }
}