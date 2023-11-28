using System.Reflection.PortableExecutable;
using LayerSimulation;
using TextFile;
using static LayerSimulation.Gas;

internal class Program
{
    static void Main(string[] args)
    {
        TextFileReader reader = new TextFileReader("input.txt");
        List<Layer> layers = new List<Layer>();
        Atmosphere atmosphere = new Atmosphere(layers);
        List<Climate> climates = new List<Climate>();

        //populating gas
        reader.ReadInt(out int orglayers);
        char token;
        Gas gas = null;
        double thickness;
        int i;
        for (i = 0; i < orglayers; i++)
        {
            reader.ReadChar(out token);
            switch (token)
            {
                case ('Z'): gas = Ozone.Instance(); break;
                case ('X'): gas = Oxygen.Instance(); break;
                case ('C'): gas = Carbon.Instance(); break;
            }
            reader.ReadDouble(out thickness);
            Layer layer = new Layer(gas, thickness);
            gas.Increase();
            layers.Add(layer);
        }

        //populating climate
        string str = reader.ReadString();

        Climate climate = null;

        int j;
        for (j = 0; j < str.Length; j++) 
        {
            token = str[j];
            switch (token)
            {
                case ('T'): climate = Thunderstorm.Instance(); break;
                case ('S'): climate = Sunshine.Instance(); break;
                case ('O'): climate = Other.Instance(); break;
            }
            climates.Add(climate);
            
        }

        //simulation
        try
        {
            i = 0;
            j = 0;
            int k = 1;
            while (!(atmosphere.TotalLayer() < 3 || atmosphere.TotalLayer() == (orglayers * 3)))
            {
                j = i % climates.Count();
                climates[j].Transform(atmosphere);
                i++;

                Console.WriteLine($"Round:{k++}");
                foreach (Layer layer in atmosphere.layers)
                {

                    Console.WriteLine($"{layer.gas.name} {layer.thickness}");
                  
                }
                Console.WriteLine();
            }
        }
        catch (System.IO.FileNotFoundException)
        {
            Console.WriteLine("The file is not found.");
        }
    }



}