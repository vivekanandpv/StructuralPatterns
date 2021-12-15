using System;

namespace Adapter {
    class Program {
        static void Main(string[] args)
        {
            //  Section 4
            //  Regular conforming object
            IK8sService minikube = new Minikube();

            //  Adapted through delegation
            IK8sService eksVariant1 = new ObjectAdapter(new ElasticK8sService());
            
            //  Adapted through subclassing
            IK8sService eksVariant2 = new ClassAdapter();

            //  Client carries on with the business
            minikube.Start();
            minikube.Stop();

            eksVariant1.Start();
            eksVariant1.Stop();

            eksVariant2.Start();
            eksVariant2.Stop();
        }
    }

    //  Section 1
    //  The primary interface used by the client
    interface IK8sService {
        void Start();
        void Stop();
    }

    class Minikube : IK8sService {
        public void Start() {
            Console.WriteLine("Minikube starts");
        }

        public void Stop() {
            Console.WriteLine("Minikube stops");
        }
    }

    class ElasticK8sService {
        public virtual void Run() {
            Console.WriteLine("EKS starts running");
        }

        public virtual void Halt() {
            Console.WriteLine("EKS halts");
        }
    }

    //  Section 2
    //  Implementing an object-adapter
    //  The choice is adapting by delegation (through composition)
    //  This may be a better design in many cases
    class ObjectAdapter : IK8sService
    {
        //  Delegated object
        //  This doesn't implement the client's primary interface
        private readonly ElasticK8sService _eks;

        //  Better to abstractly represent the delegated object
        public ObjectAdapter(ElasticK8sService eks)
        {
            _eks = eks;
        }

        //  Conforming to the client's interface requirements
        public void Start()
        {
            _eks.Run();
        }

        public void Stop()
        {
            _eks.Halt();
        }
    }

    //  Section 3
    //  Implementing a class adapter
    //  The choice here is adapting by inheritance
    //  Somewhat rigid in the sense that specialization requires subclassing
    class ClassAdapter: ElasticK8sService, IK8sService
    {
        public void Start()
        {
            Run();
        }

        public void Stop()
        {
            Halt();
        }

        //  Provided the superclass (ElasticK8sService) allows this
        public override void Run()
        {
            base.Run();
        }

        public override void Halt()
        {
            base.Halt();
        }
    }
}
