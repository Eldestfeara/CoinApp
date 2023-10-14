using System;
using QuickFix;
public class MyFixApplication : MessageCracker, IApplication
{
    public void FromAdmin(QuickFix.Message message, SessionID sessionId) { }

    public void FromApp(QuickFix.Message message, SessionID sessionId)
    {
        // Handle incoming application-level messages (i.e., your FIX messages)
        Crack(message, sessionId);
    }

    public void OnCreate(SessionID sessionId) { }

    public void OnLogon(SessionID sessionId) { }

    public void OnLogout(SessionID sessionId) { }

    public void ToAdmin(QuickFix.Message message, SessionID sessionId) { }

    public void ToApp(QuickFix.Message message, SessionID sessionId) { }

    public void OnMessage(QuickFix.FIX44.MarketDataSnapshotFullRefresh msg, SessionID s)
    {
        for (int idx = 0; idx < msg.NoMDEntries.getValue(); idx++)
        {
            var level = new QuickFix.FIX44.MarketDataSnapshotFullRefresh.NoMDEntriesGroup();
            msg.GetGroup(idx + 1, level);

            Console.WriteLine($"Orderbook {level.MDEntryType} @ {msg.Symbol}:");
            Console.WriteLine($" Time: {level.MDEntryTime}");
            Console.WriteLine($" Px: {level.MDEntryPx}");
        }
    }
}
