using QuickFix;
using QuickFix.Transport;

class Program
{
    static void Main(string[] args)
    {
        // Load your FIX settings from a configuration file
        SessionSettings settings = new("quickfix.cfg");
        IMessageStoreFactory storeFactory = new FileStoreFactory(settings);
        ILogFactory logFactory = new FileLogFactory(settings);
        IMessageFactory messageFactory = new DefaultMessageFactory();

        IApplication application = new MyFixApplication();

        var initiator = new SocketInitiator(application, storeFactory, settings, logFactory, messageFactory);
        initiator.Start();

        Console.WriteLine("Press ENTER to quit.");
        Console.ReadLine();

        initiator.Stop();
    }
}

