using System;
using System.Collections.Generic;
using System.Linq;
using WeighingMarbles.ViewModels;

namespace WeighingMarbles.Services
{
    public class MarbleService
    {

        public List<Marble> GenerateMarbleList(int marbleCount, int heavyMarbleNumber)
        {
            var marbles = new List<Marble>();

            for (int i = 0; i < marbleCount; i++)
            {
                var itemNumber = i + 1;
                var marble = new Marble
                {
                    ItemNumber = itemNumber,
                    Weight = itemNumber == heavyMarbleNumber ? 1.5 : 1.0
                };

                marbles.Add(marble);
            }
            return marbles;
        }

        public List<MarbleWeighing> StartProcess(int marbleCount, int heavyMarbleNumber)
        {
            var marbles = GenerateMarbleList(marbleCount, heavyMarbleNumber);
            var results = new List<MarbleWeighing>();
            var currentList = new MarbleWeighing { StartingList = marbles };
            results.Add(currentList);
            do
            {
                var newList = ProcessList(currentList);
                results.Add(newList);
                currentList = newList;

            } while (currentList.StartingList.Count > 1);

            return results;

        }
        public MarbleWeighing ProcessList(MarbleWeighing marbles)
        {
            var marbleCount = marbles.StartingList.Count;
            double marblesPerGroup = Math.Ceiling(marbleCount / 3.0);
            var newMarbleList = new MarbleWeighing
            {
                Group1 = new List<Marble>(),
                Group2 = new List<Marble>(),
                Group3 = new List<Marble>(),
                StartingList = new List<Marble>()
            };

            var idx = 1;
            foreach (var marble in marbles.StartingList)
            {
                
                
                if (idx <= marblesPerGroup)
                {
                    newMarbleList.Group1.Add(marble);
                }
                else if (idx > marblesPerGroup && idx <= (marblesPerGroup * 2))
                {
                    newMarbleList.Group2.Add(marble);
                }
                else
                {
                    newMarbleList.Group3.Add(marble);
                }

                idx++;
            }

            marbles.Group1ListWeight = WeighMarbleList(newMarbleList.Group1);
            marbles.Group2ListWeight = WeighMarbleList(newMarbleList.Group2);
            marbles.Group3ListWeight = WeighMarbleList(newMarbleList.Group3);

            if (marbles.Group1ListWeight != marbles.Group2ListWeight)
            {
                newMarbleList.StartingList = marbles.Group1ListWeight > marbles.Group2ListWeight
                    ? newMarbleList.Group1
                    : newMarbleList.Group2;
            }
            else
            {
                newMarbleList.StartingList = newMarbleList.Group3;
            }


            return newMarbleList;
        }

        public double WeighMarbleList(List<Marble> marbles)
        {
            return marbles.Sum(marble => marble.Weight);
        }


    }
}