using System;
using System.Collections.Generic;

namespace Composite {
    class Program {
        static void Main(string[] args)
        {
            IGraphic line = new Line();
            IGraphic rectangle = new Rectangle();
            
            IGraphic picture = new Picture();
            picture.Add(1, line);
            picture.Add(2, rectangle);

            picture.Draw();
        }
    }

    interface IGraphic {
        void Draw();

        void Add(int id, IGraphic graphic) {
            throw new NotImplementedException();
        }

        void Remove(int id) {
            throw new NotImplementedException();
        }

        IGraphic Get(int id) {
            throw new NotImplementedException();
        }
    }

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

        public void Draw() {
            Console.WriteLine("Draw: Picture");
            foreach (var pair in _graphics)
            {
                pair.Value.Draw();
            }
        }
    }
}
