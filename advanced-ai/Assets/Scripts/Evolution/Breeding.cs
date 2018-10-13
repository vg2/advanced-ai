﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Evolution
{
    class Breeding
    {
        internal static OrigamiRobot crossover(OrigamiRobot parent1, OrigamiRobot parent2)
        {
            var child = new OrigamiRobot(parent1.GetTeam(), parent1.GetNumParts(), parent1.GetRobotTransformProperties());

            var parents = new List<OrigamiRobot> {parent1, parent2};

            var childProps = new Triangle[parent1.GetNumParts()];

            for (var i = 0; i < childProps.Length; i++)
            {
                var selectedParent = PickRandomParent(parents);
                childProps[i] = selectedParent.getBody()[i];
            }

            child.SetBody(childProps);

            return child;
        }

        private static OrigamiRobot PickRandomParent(List<OrigamiRobot> origamiRobots)
        {
            var randomGenerator = new Random();

            var numRobots = origamiRobots.Count;

            var randomIndex = randomGenerator.Next(0, numRobots);

            return origamiRobots[randomIndex];
        }
    }
}
