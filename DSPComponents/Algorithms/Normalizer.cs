using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class Normalizer : Algorithm
    {
        public Signal InputSignal { get; set; }
        public float InputMinRange { get; set; }
        public float InputMaxRange { get; set; }
        public Signal OutputNormalizedSignal { get; set; }

        public override void Run()
        {
            float minVal = InputSignal.Samples.Min();
            float maxVal = InputSignal.Samples.Max();
            float range = InputMaxRange - InputMinRange;

             List<float> samples = new List<float>();
                for (int i = 0; i < InputSignal.Samples.Count; i++)
                {
                    samples.Add(((range)*(InputSignal.Samples[i]-minVal)/(maxVal-minVal))+ InputMinRange);
                }
                OutputNormalizedSignal = new Signal(samples, InputSignal.Periodic);
            
          
        }
    }
}
