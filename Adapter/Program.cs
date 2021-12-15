using System;

namespace Adapter {
    class Program {
        static void Main(string[] args)
        {
            IK8sService minikube = new Minikube();
            IK8sService eksVariant1 = new ObjectAdapter(new ElasticK8sService());
            IK8sService eksVariant2 = new ClassAdapter();

            minikube.Start();
            minikube.Stop();

            eksVariant1.Start();
            eksVariant1.Stop();

            eksVariant2.Start();
            eksVariant2.Stop();
        }
    }

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

    class ObjectAdapter : IK8sService
    {
        private readonly ElasticK8sService _eks;

        public ObjectAdapter(ElasticK8sService eks)
        {
            _eks = eks;
        }

        public void Start()
        {
            _eks.Run();
        }

        public void Stop()
        {
            _eks.Halt();
        }
    }

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
