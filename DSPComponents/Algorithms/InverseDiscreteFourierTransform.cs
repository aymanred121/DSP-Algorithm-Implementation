using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class InverseDiscreteFourierTransform : Algorithm
    {
        public Signal InputFreqDomainSignal { get; set; }
        public Signal OutputTimeDomainSignal { get; set; }

        public List<float> FrequenciesPhaseShifts;
        public List<float> outputFreq;
        public List<Complex> expValues;
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
            Initializer();
            ADFT();

        }

        private void Initializer()
        {
            FrequenciesPhaseShifts = new List<float>();
            outputFreq = new List<float>();
            expValues = new List<Complex>();
        }

        private void ADFT()
        {
            float nofSample = InputFreqDomainSignal.FrequenciesAmplitudes.Count;
            CalculateComplexList();
            for (int k = 0; k < nofSample; k++)
            {
                double RealxReal=0;
                double RealxImg=0;
                double ImgxImg=0;
                double ImgxReal=0;
                for(int n = 0; n < nofSample; n++)
                {
                    var exPower = (2 * n * k * Math.PI) / nofSample;
                    RealxReal += expValues[n].Real * Math.Cos(exPower);
                    RealxImg += expValues[n].Real * Math.Sin(exPower);
                    ImgxImg += (-1) * expValues[n].Imaginary * Math.Sin(exPower);
                    ImgxReal += expValues[n].Imaginary * Math.Cos(exPower);

                }
                Console.WriteLine(RealxReal + RealxImg + ImgxImg + ImgxReal);
                outputFreq.Add((float)(RealxReal+RealxImg+ImgxImg+ImgxReal)/nofSample);
            }
              OutputTimeDomainSignal = new Signal(outputFreq, false);
        }

        private void CalculateComplexList()
        {
            float nofSample = InputFreqDomainSignal.FrequenciesAmplitudes.Count;
   
            for (int k = 0; k < nofSample; k++)
            {
               
                var x = InputFreqDomainSignal.FrequenciesAmplitudes[k] * (float)Math.Cos(InputFreqDomainSignal.FrequenciesPhaseShifts[k]);
                var y = InputFreqDomainSignal.FrequenciesAmplitudes[k] * (float)Math.Sin(InputFreqDomainSignal.FrequenciesPhaseShifts[k]);
                expValues.Add(new Complex(x,y));
            }
        }

      
    }
}
