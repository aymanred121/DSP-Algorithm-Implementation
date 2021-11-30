using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class DirectConvolution : Algorithm
    {
        public Signal InputSignal1 { get; set; }
        public Signal InputSignal2 { get; set; }
        public Signal OutputConvolvedSignal { get; set; }

        /// <summary>
        /// Convolved InputSignal1 (considered as X) with InputSignal2 (considered as H)
        /// </summary>
        public override void Run()
        {
            List<int> convIndcies = new List<int>();
            int lenH = InputSignal2.Samples.Count;
            int lenX = InputSignal1.Samples.Count;
            int indStart = InputSignal2.SamplesIndices[0] + InputSignal1.SamplesIndices[0];
            List<float> convSignale = new List<float>();
            int nConv = lenH + lenX - 1;
            int hStart, xStart, xEnd;

            for (int i = 0; i < nConv; i++)
            {
                float temp = 0;
                xStart = MAX(0, i - lenH + 1);
                xEnd = MIN(i + 1, lenX);
                hStart = MIN(i, lenH - 1);
                for (int j = xStart; j < xEnd; j++)
                {
                    temp += InputSignal2.Samples[hStart--] * InputSignal1.Samples[j];

                }
                if (i >= nConv - 1 && temp == 0) continue;
                convSignale.Add(temp);
            }



            for (int i = 0; i < convSignale.Count; i++)
            {
                convIndcies.Add(indStart);
                indStart++;
            }
            OutputConvolvedSignal = new Signal(convSignale.ToList(),convIndcies, false);

        }

        private int MIN(int v1, int v2)
        {
            if (v1 < v2)
                return v1;
            return v2;
        }

        private int MAX(int v1, int v2)
        {
            if (v1 > v2)
                return v1;
            return v2;
        }
    }
}
