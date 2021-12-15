using System;

namespace Bridge {
    class Program {
        static void Main(string[] args) {
            IServer awsServer = new AwsEc2();
            VirtualInfrastructureBase infrastructure = new CloudVirtualInfrastructure(awsServer);

            infrastructure.Instantiate();
            infrastructure.Stop();

            IServer azureServer = new AzureVm();
            infrastructure.SetServer(azureServer);

            infrastructure.Instantiate();
            infrastructure.Stop();
        }
    }

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

    abstract class VirtualInfrastructureBase {
        protected IServer Server { get; set; }

        protected VirtualInfrastructureBase(IServer server) {
            this.Server = server;
        }

        public abstract void Instantiate();

        public abstract void Stop();

        public abstract void SetServer(IServer server);
    }

    class CloudVirtualInfrastructure : VirtualInfrastructureBase {
        public CloudVirtualInfrastructure(IServer server) : base(server) {
        }

        public override void SetServer(IServer server) {
            Server = server;
        }

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
