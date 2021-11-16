using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class DiscreteFourierTransform : Algorithm
    {
        public Signal InputTimeDomainSignal { get; set; }
        public float InputSamplingFrequency { get; set; }
        public Signal OutputFreqDomainSignal { get; set; }
        public List<float> outputAmps;
        public List<float> outputFreq;
        public List<float> FrequenciesPhaseShifts;
        public List<Complex> sigmoidList;
        public float nofSample;
        public class Complex
        {
            public Complex()
            {
                Real = 0;
                Imaginary = 0;
            }
            public Complex(float real, float imaginary)
            {
                Real = real;
                Imaginary = imaginary;
            }

            public float Real { get; set; }
           public float Imaginary { get; set; }
       
        }

        public override void Run()
        {
            Initalizer();
            DFT();
            SaveToFile();


         
        }

        private void SaveToFile()
        {
            string fileName = @"C:\Users\ayman\Desktop\5th semster\DSP\DFT.txt";
            if (!File.Exists(fileName))
            {

                using (StreamWriter writer = File.CreateText(fileName))
                {
                   // writer.WriteLine(outputAmps.Count+" "+FrequenciesPhaseShifts.Count);
                    for(int i = 0; i < nofSample; i++)
                    {
                        writer.WriteLine(OutputFreqDomainSignal.FrequenciesAmplitudes[i] + " " + OutputFreqDomainSignal.FrequenciesPhaseShifts[i]);
                    }
                }
            }
        }

        private void Initalizer()
        {
            outputAmps = new List<float>();
            outputFreq = new List<float>();
            FrequenciesPhaseShifts = new List<float>();
            sigmoidList = new List<Complex>();
            nofSample = InputTimeDomainSignal.Samples.Count;
        }

        private void DFT()
        {
            float nofSample = InputTimeDomainSignal.Samples.Count;
            Complex c = new Complex();
            for (float k = 0; k < nofSample; k++)
            {
                c.Real = 0;
                c.Imaginary = 0;
                outputAmps.Add(k);
                for (int n = 0; n < nofSample; n++)
                {
                    var expPower = (2 * k * n) / nofSample;
                    c.Real += (float)(Math.Cos(expPower * Math.PI)) * InputTimeDomainSignal.Samples[n];
                    c.Imaginary += (float)(-1 * Math.Sin(expPower * Math.PI)) * InputTimeDomainSignal.Samples[n];
                }
                outputFreq.Add((float)Math.Sqrt(c.Real * c.Real + c.Imaginary * c.Imaginary));
                FrequenciesPhaseShifts.Add(CalFreqPhas(c));
                sigmoidList.Add(c);
            }
            OutputFreqDomainSignal = new Signal(false, outputAmps, outputFreq, FrequenciesPhaseShifts);
        }   
        private float CalFreqPhas(Complex c)
        {

            if (c.Real > 0)
               return((float)Math.Atan(c.Imaginary / c.Real));
            else if (c.Real < 0 && c.Imaginary >= 0)
                return((float)(Math.Atan(c.Imaginary / c.Real) + Math.PI));
            else if (c.Real < 0 && c.Imaginary < 0)
               return((float)(Math.Atan(c.Imaginary / c.Real) - Math.PI));
            return 0;
        }
    }
}
