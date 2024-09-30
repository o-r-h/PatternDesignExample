using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Classes
{
	public class BankAccount
	{
		private decimal balance;
		private decimal overDraftLimit = -500;

		public void Deposit(decimal amount){
			balance += amount;
			Console.WriteLine($"Deposit  ${amount}, balance result: ${balance} ");
		}

		public bool Withdraw(decimal amount)
		{
			if (balance - amount >= overDraftLimit)
			{
				balance -= amount;
				Console.WriteLine($"Deposit  ${amount}, balance result: ${balance} ");
				return true;
			}
			Console.WriteLine($"Founds are no enought, actual balance: ${balance} ");
			return false;

		}

		public override string ToString()
		{
			return $"{nameof(balance)}: {balance}";
		}
	}

	public interface ICommand
	{
		void Call();
		void Undo();
	}

	public class BankAccountCommand : ICommand
	{
		private BankAccount account;
		private decimal amount;
		private bool succeeded;
		public enum Action { Deposit, Withdraw }

		private Action action;

		public BankAccountCommand(BankAccount account, decimal amount, Action action)
		{
			this.account = account ?? throw new ArgumentNullException(paramName: nameof(account));
			this.amount = amount;
			this.action = action;
		}

		public void Call()
		{
			switch (action)
			{
				case Action.Deposit:
					account.Deposit(amount);
					succeeded = true;
					break;
				case Action.Withdraw:
					succeeded = account.Withdraw(amount);
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		public void Undo()
		{
			if (!succeeded) return;
			switch (action)
			{
				case Action.Deposit:
					account.Withdraw(amount);
					break;
				case Action.Withdraw:
					account.Deposit(amount);
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}


		}


	}

}
