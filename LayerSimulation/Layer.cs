using System;
namespace LayerSimulation
{
    public class Layer
    {
        public Gas gas { get; }
        public double thickness { get; set; }

        public Layer(Gas gas, double thickness)
        {
            this.gas = gas;
            this.thickness = thickness;
        }

        public void Engross(Layer layer)
        {
            thickness += layer.thickness;
        }

        public bool Perish()
        {
            return thickness <= 0.5;
        }

        public bool Ascend(Atmosphere atmosphere, int ind)
        {
            if (atmosphere.AboveSearch(gas, ind, out int i))
            {
                atmosphere.layers[i].Engross(this);
                return false;
            }
            else if (this.Perish())
            {
                return false;
            }
        
            return true;

        }
               
    }
}


