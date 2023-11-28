using LayerSimulation;
using static LayerSimulation.Gas;

namespace SimulationTest;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestOzone_Thunderstorm()
    {
        List<Layer> layers = new List<Layer>();
        layers.Add(new Layer(Ozone.Instance(), 2));
        Atmosphere atmosphere = new Atmosphere(layers);

        
        List<Climate> climate = new List<Climate>();
        climate.Add(Thunderstorm.Instance());

        climate[0].Transform(atmosphere);

        Assert.AreEqual("Ozone", atmosphere.layers[0].gas.name);
        Assert.AreEqual(2, atmosphere.layers[0].thickness);
    }

    [TestMethod]
    public void TestOzone_Sunshine()
    {
        List<Layer> layers = new List<Layer>();
        layers.Add(new Layer(Ozone.Instance(), 5));
        Atmosphere atmosphere = new Atmosphere(layers);


        List<Climate> climate = new List<Climate>();
        climate.Add(Sunshine.Instance());

        climate[0].Transform(atmosphere);

        Assert.AreEqual("Ozone", atmosphere.layers[0].gas.name);
        Assert.AreEqual(5, atmosphere.layers[0].thickness);
    }

    [TestMethod]
    public void TestOzone_Other()
    {
        List<Layer> layers = new List<Layer>();
        layers.Add(new Layer(Ozone.Instance(), 100));
        Atmosphere atmosphere = new Atmosphere(layers);


        List<Climate> climate = new List<Climate>();
        climate.Add(Other.Instance());

        climate[0].Transform(atmosphere);

        Assert.AreEqual("Oxygen", atmosphere.layers[0].gas.name);
        Assert.AreEqual(5, atmosphere.layers[0].thickness);
        Assert.AreEqual("Ozone", atmosphere.layers[1].gas.name);
        Assert.AreEqual(95, atmosphere.layers[1].thickness);
    }

    [TestMethod]
    public void TestCarbonDioxide_Thunderstorm()
    {
        List<Layer> layers = new List<Layer>();
        layers.Add(new Layer(Carbon.Instance(), 1));
        Atmosphere atmosphere = new Atmosphere(layers);


        List<Climate> climate = new List<Climate>();
        climate.Add(Thunderstorm.Instance());

        climate[0].Transform(atmosphere);

        Assert.AreEqual("Carbon", atmosphere.layers[0].gas.name);
        Assert.AreEqual(1, atmosphere.layers[0].thickness);
    }

    [TestMethod]
    public void TestCarbonDioxide_Sunshine()
    {
        List<Layer> layers = new List<Layer>();
        layers.Add(new Layer(Carbon.Instance(), 100));
        Atmosphere atmosphere = new Atmosphere(layers);


        List<Climate> climate = new List<Climate>();
        climate.Add(Sunshine.Instance());

        climate[0].Transform(atmosphere);

        Assert.AreEqual("Oxygen", atmosphere.layers[0].gas.name);
        Assert.AreEqual(5, atmosphere.layers[0].thickness);
        Assert.AreEqual("Carbon", atmosphere.layers[1].gas.name);
        Assert.AreEqual(95, atmosphere.layers[1].thickness);
    }

    [TestMethod]
    public void TestCarbonDioxide_Other()
    {
        List<Layer> layers = new List<Layer>();
        layers.Add(new Layer(Carbon.Instance(), 12));
        Atmosphere atmosphere = new Atmosphere(layers);


        List<Climate> climate = new List<Climate>();
        climate.Add(Other.Instance());

        climate[0].Transform(atmosphere);

        Assert.AreEqual("Carbon", atmosphere.layers[0].gas.name);
        Assert.AreEqual(atmosphere.layers[0].thickness, 12);
    }

    [TestMethod]
    public void TestOxygen_Thunderstorm()
    {
        List<Layer> layers = new List<Layer>();
        layers.Add(new Layer(Oxygen.Instance(), 2));
        Atmosphere atmosphere = new Atmosphere(layers);

        List<Climate> climate = new List<Climate>();
        climate.Add(Thunderstorm.Instance());

        climate[0].Transform(atmosphere);

        Assert.AreEqual("Ozone", atmosphere.layers[0].gas.name);
        Assert.AreEqual(1, atmosphere.layers[0].thickness);
        Assert.AreEqual("Oxygen", atmosphere.layers[1].gas.name);
        Assert.AreEqual(1, atmosphere.layers[1].thickness);
    }

    [TestMethod]
    public void TestOxygen_Sunshine()
    {
        List<Layer> layers = new List<Layer>();
        layers.Add(new Layer(Oxygen.Instance(), 10));
        Atmosphere atmosphere = new Atmosphere(layers);

        List<Climate> climate = new List<Climate>();
        climate.Add(Sunshine.Instance());

        climate[0].Transform(atmosphere);

        Assert.AreEqual("Oxygen", atmosphere.layers[0].gas.name);
        Assert.AreEqual(9.5, atmosphere.layers[0].thickness);
    }

    [TestMethod]
    public void TestOxygen_Other()
    {
        List<Layer> layers = new List<Layer>();
        layers.Add(new Layer(Oxygen.Instance(), 10));
        Atmosphere atmosphere = new Atmosphere(layers);

        List<Climate> climate = new List<Climate>();
        climate.Add(Other.Instance());

        climate[0].Transform(atmosphere);

        Assert.AreEqual("Carbon", atmosphere.layers[0].gas.name);
        Assert.AreEqual(atmosphere.layers[0].thickness, 1);
        Assert.AreEqual("Oxygen", atmosphere.layers[1].gas.name);
        Assert.AreEqual(9, atmosphere.layers[1].thickness);
    }

    
    [TestMethod]
    public void TestEndOfSimulation()
    {
        List<Climate> climates = new List<Climate>();
        climates.Add(Thunderstorm.Instance());

        List<Layer> layers = new List<Layer>();
        Layer layer1 = new Layer(Ozone.Instance(), 4.2);
        Layer layer2 = new Layer(Carbon.Instance(), 3.7);
        Layer layer3 = new Layer(Oxygen.Instance(), 0.5);

        layers.Add(layer1);
        layers.Add(layer2);
        layers.Add(layer3);

        Atmosphere atmosphere = new Atmosphere(layers);
        climates[0].Transform(atmosphere);

        Assert.AreEqual(2, atmosphere.layers.Count());

        CollectionAssert.Contains(atmosphere.layers, layer1);
        CollectionAssert.Contains(atmosphere.layers, layer2);
        CollectionAssert.DoesNotContain(atmosphere.layers, layer3, "Layer 3 should not be present.");


    }

}


