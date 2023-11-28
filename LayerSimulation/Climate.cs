using System;
namespace LayerSimulation
{
    public abstract class Climate
    {
        public abstract Gas ChangeGas(Gas gas, out double percent);

        public Layer? Alter(Layer layer)
        {

            Gas alteredGas = ChangeGas(layer.gas, out double percent);
            Layer alteredLayer = new Layer( alteredGas, layer.thickness * percent / 100);
            layer.thickness = layer.thickness * (1 - percent / 100);

            if (percent == 0)
            {
                return null;
            }
            else
            {
                return alteredLayer;
            }
        }

        public void Transform(Atmosphere atmosphere)
        {
            
            List<Layer> transformedLayers = new List<Layer>();

            Layer newLayer = null;

            for(int i = 0; i < atmosphere.layers.Count(); i++)
            {
                newLayer = Alter(atmosphere.layers[i]);
                if (newLayer != null)
                {
                    if (newLayer.Ascend(atmosphere, i))
                    {
                        transformedLayers.Insert(0, newLayer);
                        newLayer.gas.Increase();
                    }
                    if (atmosphere.layers[i].Perish())
                    {
                        atmosphere.layers[i].Ascend(atmosphere, i);
                        atmosphere.layers[i].gas.Decrease();
                        atmosphere.layers.RemoveAt(i);
                        
                        i--;
                    }
                }
                
            }
            transformedLayers.AddRange(atmosphere.layers);
            atmosphere.layers = transformedLayers;
        }
       
    }

    public class Thunderstorm : Climate
    {
        private static Thunderstorm instance = null;
        private Thunderstorm() : base() { }

        public override Gas ChangeGas(Gas gas, out double percent)
        {
            return gas.EffectByTS(out percent);
        }

        public static Thunderstorm Instance()
        {
            
            if (instance == null)
            {
                instance = new Thunderstorm();
            }
            return instance;
        }
    }

    public class Sunshine : Climate
    {
        private static Sunshine instance = null;
        private Sunshine() : base() { }

        public override Gas ChangeGas(Gas gas, out double percent)
        {
            return gas.EffectBySS(out percent);
        }


        public static Sunshine Instance()
        {
            
            if (instance == null)
            {
                instance = new Sunshine();
            }
            return instance;
        }
    }

    public class Other : Climate
    {
        private static Other instance = null;
        private Other() : base() { }

        public override Gas ChangeGas(Gas gas, out double percent)
        {
            return gas.EffectByOT(out percent);
        }

        public static Other Instance()
        {
            
            if (instance == null)
            {
                instance = new Other();
            }
            return instance;
        }
    }
}


