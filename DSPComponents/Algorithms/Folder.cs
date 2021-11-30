using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class Folder : Algorithm
    {
        public Signal InputSignal { get; set; }
        public Signal OutputFoldedSignal { get; set; }

        public override void Run()
        {
            List<float> foldedSignal = InputSignal.Samples;
            List<int> foldedIndex = InputSignal.SamplesIndices;
            foldedSignal.Reverse();
            for(int i = 0; i < foldedIndex.Count; i++)
            {
                foldedIndex[i] = -foldedIndex[i];
            }
            foldedIndex.Reverse();
            OutputFoldedSignal = new Signal(foldedSignal,foldedIndex, InputSignal.Periodic, !InputSignal.folded);
        }
    }
}
