using System;
using static LayerSimulation.Gas;

namespace LayerSimulation
{
    public class Atmosphere
    {
        public List<Layer> layers = new List<Layer>();

        public Atmosphere(List<Layer> layers)
        {
            this.layers = layers;
        }

        public bool AboveSearch(Gas gas, int ind, out int i)
        {
            i = -1;
            for (int j = ind; j >= 0; j--)
            {
                if (layers[j].gas.name == gas.name)
                {
                    i = j;
                    return true;
                }
            }

            return false;
        }


        public int TotalLayer()
        {
            return Ozone.Instance().quantity + Oxygen.Instance().quantity + Carbon.Instance().quantity ;
        }

       
    }
}


