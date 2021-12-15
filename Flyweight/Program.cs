using System;
using System.Collections.Generic;

namespace Flyweight {
    internal class Program {
        static void Main(string[] args)
        {
            //  Prepare different contexts
            IDrawingContext contextOne = new WindowsDrawingContext(10, 11, 0);
            IDrawingContext contextTwo = new WindowsDrawingContext(14, 18, 0);
            IDrawingContext contextThree = new WindowsDrawingContext(19, 74, 0);

            //  Instantiate the factory and get the flyweights
            var factory = new CharacterFlyweightFactory();

            ICharacterFlyweight flyweightOne = factory.GetFlyweight(100);
            ICharacterFlyweight flyweightTwo = factory.GetFlyweight(103);

            //  We get a pooled flyweight here
            ICharacterFlyweight flyweightThree = factory.GetFlyweight(100);

            //  Flyweights work with contexts that are determined only at the runtime
            flyweightOne.Draw(contextOne);
            flyweightTwo.Draw(contextTwo);
            flyweightThree.Draw(contextThree);
        }
    }

    //  Section 2
    //  Abstraction for extrinsic state
    //  Can also be abstract class
    interface IDrawingContext {
        int X { get; }
        int Y { get; }
        int ZIndex { get; }
    }

    class WindowsDrawingContext : IDrawingContext {
        public int X { get; }
        public int Y { get; }
        public int ZIndex { get; }

        public WindowsDrawingContext(int x, int y, int zIndex) {
            X = x;
            Y = y;
            ZIndex = zIndex;
        }

        public override string ToString() {
            return $"X: {X}; Y: {Y}; Z-Index: {ZIndex}";
        }
    }

    //  Section 1
    //  Define the flyweight object interface
    //  Its intrinsic state is context-free
    //  Extrinsic state is passed by the context
    interface ICharacterFlyweight {
        
        int Key { get; }
        void Draw(IDrawingContext context);
    }

    class CharacterFlyweight : ICharacterFlyweight {
        //  intrinsic state
        public int Key { get; }

        public CharacterFlyweight(int key) {
            Key = key;
        }

        //  context is the extrinsic state passed by client
        public void Draw(IDrawingContext context) {
            Console.WriteLine($"Character >> {Key} -> Draw: {context}");
        }
    }

    //  Section 3
    //  Acts as a registry
    //  Main purpose is to reuse the flyweights and thus reduce the space footprint
    class CharacterFlyweightFactory {
        //  Usual technique to build a flyweight pool
        private readonly IDictionary<int, ICharacterFlyweight> _flyweights
            = new Dictionary<int, ICharacterFlyweight>();

        public ICharacterFlyweight GetFlyweight(int key) {
            if (_flyweights.ContainsKey(key)) {
                return _flyweights[key];
            }

            var freshFlyweight = new CharacterFlyweight(key);
            _flyweights.Add(key, freshFlyweight);
            return freshFlyweight;
        }
    }
}
