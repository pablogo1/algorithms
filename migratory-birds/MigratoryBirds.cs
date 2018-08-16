
using System;
using System.Collections.Generic;

namespace MigratoryBirds
{
    public class MigratoryBirds
    {
        public int Solve(int[] inputArray) 
        {
            var birdSights = new Dictionary<int, int> {
                { 1, 0 },
                { 2, 0 },
                { 3, 0 },
                { 4, 0 },
                { 5, 0 }
            };
        
            foreach(var birdId in inputArray) {
                if(!birdSights.ContainsKey(birdId)) {
                    birdSights.Add(birdId, 0);
                }
                
                birdSights[birdId] = birdSights[birdId] + 1;
            }
            /*foreach(var item in birdSights) {
                Console.WriteLine("{0}: {1}", item.Key, item.Value);
            }*/
            //birdSight.s
            int maxCountBirdId = 0, maxCount = 0;
            foreach(var birdId in birdSights.Keys) {
                if(birdSights[birdId] > maxCount) {
                    maxCount = birdSights[birdId];
                    maxCountBirdId = birdId;
                    /*Console.WriteLine("maxCount = {0}", maxCount);
                    Console.WriteLine("birdId = {0}", birdId);
                    Console.WriteLine("maxCountBirdId = {0}", maxCountBirdId);*/
                    /*if(maxCountBirdId == 0 || maxCountBirdId > birdId) {
                        maxCountBirdId = birdId;
                    }*/
                    
                }
            }
            
            return maxCountBirdId;
        }
    }
}