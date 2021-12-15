using System;

namespace Proxy {
    class Program {
        static void Main(string[] args) {
            //  Section 4
            //  Client deals with the common interface shared by real and proxy both
            //  Client, in a way doesn't know/care for the implementation
            IFile fileHandle = new ProxyFile("foo.mp4");

            //  This will set off the sequence
            fileHandle.Open();
        }
    }

    //  Section 1
    //  Client relies on an interface

    interface IFile {
        string Name { get; }
        void Open();
    }

    //  Section 2
    //  Real implementation
    class RealFile : IFile {
        public string Name { get; }

        public RealFile(string name) {
            Name = name;
        }

        public void Open() {
            Console.WriteLine($"Opening: {Name}");
        }
    }

    //  Section 3
    //  Proxy implementation
    //  Proxy behaves exactly like the real entity
    class ProxyFile : IFile {
        //  Proxy keeps a reference to the real object
        private IFile _realFile;

        public string Name { get; }

        public ProxyFile(string name) {
            Name = name;
        }

        //  Client invokes this method
        //  Proxy in turn invokes the real object's method
        public void Open() {
            //  Example of deferred initialization (virtual proxy)
            //  Other examples are: remote proxy, protection proxy, smart reference
            Console.WriteLine("Instantiating the real file");
            _realFile = new RealFile(Name);

            //  proxy pass
            _realFile.Open();
        }
    }
}
