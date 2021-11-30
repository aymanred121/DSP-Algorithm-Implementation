using DSPAlgorithms.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPAlgorithms.Algorithms
{
    public class AccumulationSum : Algorithm
    {
        public Signal InputSignal { get; set; }
        public Signal OutputSignal { get; set; }
        public override void Run()
        {
            List<float> accmulatedSignal = new List<float>();
            float tempSignal = 0;
            for(int i = 0; i < InputSignal.Samples.Count; i++)
            {
                 tempSignal += InputSignal.Samples[i];
                accmulatedSignal.Add(tempSignal);
            }
            OutputSignal = new Signal(accmulatedSignal, false);

        }
    }
}