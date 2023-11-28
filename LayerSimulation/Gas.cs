using System;
namespace LayerSimulation
{
    public abstract class Gas
    {
        public string name { get; set; }
        public int quantity { get; set; }

        protected Gas(string Name)
        {
            this.name = Name;
            quantity = 0;
        }

        public abstract Gas EffectByTS(out double percent);
        public abstract Gas EffectBySS(out double percent);
        public abstract Gas EffectByOT(out double percent);

        
        public void Increase()
        { 
            quantity++;
        }
        public void Decrease()
        {
            quantity--;
        }

       
    }

    public class Ozone : Gas
    {
        private static Ozone instance = null;

        private Ozone(string name) : base(name) { }

        public static Ozone Instance()
        {
            if (instance == null)
            {
                instance = new Ozone("Ozone");
                
            }
            return instance;
        }


        public override Gas EffectByTS(out double percent)
        {
            percent = 0;
            return this;
        }
        public override Gas EffectBySS(out double percent)
        {
            percent = 0;
            return this;
        }
        public override Gas EffectByOT(out double percent)
        {
            percent = 5;
            return Oxygen.Instance();
        }
    }

    public class Oxygen : Gas
    {
        private static Oxygen instance = null;

        private Oxygen(string name) : base(name) { }

        public static Oxygen Instance()
        {
            if (instance == null)
            {
                instance = new Oxygen("Oxygen");
                
            }
            return instance;
        }

        public override Gas EffectByTS(out double percent)
        {
            percent = 50;
            return Ozone.Instance();
        }
        public override Gas EffectBySS(out double percent)
        {
            percent = 5;
            return Ozone.Instance();
        }
        public override Gas EffectByOT(out double percent)
        {
            percent = 10;
            return Carbon.Instance();
        }
    }

    public class Carbon : Gas
    {
        private static Carbon instance = null;

        private Carbon(string name) : base(name) { }

        public static Carbon Instance()
        {
            if (instance == null)
            {
                instance = new Carbon("Carbon");
               
            }
            return instance;
        }

        public override Gas EffectByTS(out double percent)
        {
            percent = 0;
            return this;
        }
        public override Gas EffectBySS(out double percent)
        {
            percent = 5;
            return Oxygen.Instance();
        }
        public override Gas EffectByOT(out double percent)
        {
            percent = 0;
            return this;
        }
    }
}
