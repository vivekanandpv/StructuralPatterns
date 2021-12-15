using System;

namespace Bridge {
    class Program {
        static void Main(string[] args) {
            //  Section 4
            //  Client decides to provide the runtime algorithm
            IServer awsServer = new AwsEc2();
            VirtualInfrastructureBase infrastructure = new CloudVirtualInfrastructure(awsServer);

            infrastructure.Instantiate();
            infrastructure.Stop();

            IServer azureServer = new AzureVm();
            //  Changing the algorithm delegate at runtime
            infrastructure.SetServer(azureServer);

            //  Demonstrating the effect that the core and low-level interfaces
            //  traverse independently
            infrastructure.Instantiate();
            infrastructure.Stop();
        }
    }

    //  Section 3
    //  Low-level interface

    interface IServer {
        public bool HasStarted { get; set; }
        void PowerOn();
        void InstallMachineImage();
        void SetupUserAccount();
        void InstallAdditionalSoftware();
        void StartOperation();
        void StopOperation();
        void PowerOff();
    }

    class AwsEc2 : IServer {
        public bool HasStarted { get; set; }
        public void PowerOn() {
            HasStarted = true;
            Console.WriteLine("AWS EC2: power on");
        }

        public void InstallMachineImage() {
            Console.WriteLine("AWS EC2: installing machine image");
        }

        public void SetupUserAccount() {
            Console.WriteLine("AWS EC2: setting up user account");
        }

        public void InstallAdditionalSoftware() {
            Console.WriteLine("AWS EC2: installing additional software");
        }

        public void StartOperation() {
            Console.WriteLine("AWS EC2: starting server operation");
        }

        public void StopOperation() {
            Console.WriteLine("AWS EC2: stopping server operation");
        }

        public void PowerOff() {
            HasStarted = false;
            Console.WriteLine("AWS EC2: power off");
        }
    }

    class AzureVm : IServer {
        public bool HasStarted { get; set; }
        public void PowerOn() {
            HasStarted = true;
            Console.WriteLine("Azure Virtual Machine: power on");
        }

        public void InstallMachineImage() {
            Console.WriteLine("Azure Virtual Machine: installing machine image");
        }

        public void SetupUserAccount() {
            Console.WriteLine("Azure Virtual Machine: setting up user account");
        }

        public void InstallAdditionalSoftware() {
            Console.WriteLine("Azure Virtual Machine: installing additional software");
        }

        public void StartOperation() {
            Console.WriteLine("Azure Virtual Machine: starting server operation");
        }

        public void StopOperation() {
            Console.WriteLine("Azure Virtual Machine: stopping server operation");
        }

        public void PowerOff() {
            HasStarted = false;
            Console.WriteLine("Azure Virtual Machine: power off");
        }
    }

    //  Section 1
    //  Abstraction of the core functionality (client uses)
    abstract class VirtualInfrastructureBase {
        //  Abstraction of the low-level functionality
        //  This is extracted for cleaner and flexible design
        //  Setter is provided so that the low-level functionality can be
        //  dynamically set
        //  The crux here is that the both the abstractions can change independently
        //  When we add another method to this abstraction for example,
        //  it doesn't cause any impact on IServer
        protected IServer Server { get; set; }

        //
        protected VirtualInfrastructureBase(IServer server) {
            this.Server = server;
        }

        public abstract void Instantiate();

        public abstract void Stop();

        public abstract void SetServer(IServer server);
    }

    //  Section 2
    //  Concrete implementation of the core interface
    class CloudVirtualInfrastructure : VirtualInfrastructureBase {
        public CloudVirtualInfrastructure(IServer server) : base(server) {
        }

        //  For plugging the low-level interface at runtime
        public override void SetServer(IServer server) {
            Server = server;
        }

        //  Implementer is free to utilize the low-level interface
        //  Juxtapose with Template Method Pattern
        public override void Instantiate() {
            Server.PowerOn();
            Server.InstallMachineImage();
            Server.InstallAdditionalSoftware();
            Server.SetupUserAccount();
            Server.StartOperation();
        }

        public override void Stop() {
            if (Server.HasStarted) {
                Server.StopOperation();
                Server.PowerOff();
            }
        }
    }
}
