using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class Adder : Algorithm
    {
        public List<Signal> InputSignals { get; set; }
        public Signal OutputSignal { get; set; }

        public override void Run()
        {
            List<float> samples=new List<float>();
           for(int i = 0; i < InputSignals[0].Samples.Count; i++)
            {
                float temp = 0;
                for (int j = 0; j < InputSignals.Count; j++)
                    temp += InputSignals[j].Samples[i];
                samples.Add(temp);
               
            }
            OutputSignal = new Signal(samples, InputSignals[0].Periodic);
            //  throw new NotImplementedException();
        }
    }
}