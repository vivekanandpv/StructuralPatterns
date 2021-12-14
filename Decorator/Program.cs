using System;

namespace Decorator {
    class Program {
        static void Main(string[] args)
        {
            //  Section 5
            //  component gets successively decorated
            ISoftwareComponent decoratedSoftware =
                new PostgreSql(
                    new Nginx(
                        new Linux()
                    )
                );

            //  Execution happens inside out
            decoratedSoftware.Install();
            Console.WriteLine(decoratedSoftware.Description);
        }
    }

    //  Section 1
    //  Component interface
    interface ISoftwareComponent {
        void Install();
        string Description { get; }
    }

    //  Section 2
    //  Decorator abstract class
    abstract class SoftwareDecorator : ISoftwareComponent
    {
        private readonly ISoftwareComponent _component;

        protected SoftwareDecorator(ISoftwareComponent component)
        {
            _component = component;
        }

        //  subclasses should be able to override
        public virtual void Install()
        {
            //  Delegation
            _component.Install();
        }

        public virtual string Description => _component.Description;
    }

    //  Section 3
    //  Main component
    class Linux : ISoftwareComponent
    {
        public void Install()
        {
            Console.WriteLine("Installing main: Linux");
        }

        public string Description => "Linux OS";
    }

    //  Section 4
    //  Decorators
    class Nginx : SoftwareDecorator
    {
        public Nginx(ISoftwareComponent component) : base(component)
        {
        }

        //  delegate to base and then invoke their specific implementation
        public override void Install()
        {
            base.Install();
            InstallNginx();
        }

        private void InstallNginx()
        {
            Console.WriteLine("Install decorator: Nginx");
        }

        public override string Description => base.Description + " >> Nginx";
    }

    class PostgreSql : SoftwareDecorator {
        public PostgreSql(ISoftwareComponent component) : base(component) {
        }

        public override void Install() {
            base.Install();
            InstallPostgreSQL();
        }

        private void InstallPostgreSQL() {
            Console.WriteLine("Install decorator: PostgreSQL");
        }

        public override string Description => base.Description + " >> PostgreSQL";
    }

}
