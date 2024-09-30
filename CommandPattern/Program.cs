/**Generally speaking, you can extend such an app in two independent directions:
 Use for directly serialize a secuence of actions (calls)
 Undo a field or property assignment.
 Using for GUI commands, multilevels undo, macros

**/


using CommandPattern.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CommandPattern
{
	class Program
	{
		static void Main(string[] args)
		{
            var ba = new BankAccount();
            var commands = new List<BankAccountCommand>
      {
        new BankAccountCommand(ba, 100.20M ,BankAccountCommand.Action.Deposit),
        new BankAccountCommand(ba, 500.00M ,BankAccountCommand.Action.Deposit),
        new BankAccountCommand(ba,  30.22M , BankAccountCommand.Action.Withdraw)
      };
            Console.WriteLine(ba);
           foreach (var c in commands)
                c.Call();
            Console.WriteLine(ba);
            
            //Undo operations
            //foreach (var c in Enumerable.Reverse(commands))
            //    c.Undo();
           // Console.WriteLine(ba);

        }
	}
}
