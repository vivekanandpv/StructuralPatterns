using System;
using System.Collections.Generic;

namespace Composite {
    class Program {
        static void Main(string[] args)
        {
            //  Section 4
            //  From client's perspective, node and container are both composites
            IGraphic line = new Line();
            IGraphic rectangle = new Rectangle();
            
            //  A container has composition management
            IGraphic picture = new Picture();
            picture.Add(1, line);
            picture.Add(2, rectangle);

            //  Structural delegation
            picture.Draw();
        }
    }

    //  Section 1
    //  Defining an interface that is common to node as well as container
    interface IGraphic {
        void Draw();

        //  Taking advantage of default methods
        //  May be better than abstract class structure
        void Add(int id, IGraphic graphic) {
            //  Since nodes do not implement manage container management
            //  we throw exceptions
            throw new NotImplementedException();
        }

        void Remove(int id) {
            throw new NotImplementedException();
        }

        IGraphic Get(int id) {
            throw new NotImplementedException();
        }
    }

    //  Section 2
    //  Node
    class Line : IGraphic
    {
        public void Draw()
        {
            Console.WriteLine("Draw: Line");
        }
    }

    class Rectangle : IGraphic {
        public void Draw() {
            Console.WriteLine("Draw: Rectangle");
        }
    }

    class Text : IGraphic {
        public void Draw() {
            Console.WriteLine("Draw: Text");
        }
    }

    //  Section 3
    //  Container
    class Picture : IGraphic {
        private readonly IDictionary<int, IGraphic> _graphics = new Dictionary<int, IGraphic>();

        public void Add(int id, IGraphic graphic)
        {
            _graphics.Add(id, graphic);
        }

        public void Remove(int id)
        {
            _graphics.Remove(id);
        }

        public IGraphic Get(int id)
        {
            return _graphics[id];
        }

        //  Delegating to the composed nodes
        public void Draw() {
            Console.WriteLine("Draw: Picture");
            foreach (var pair in _graphics)
            {
                pair.Value.Draw();
            }
        }
    }
}
