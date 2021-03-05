using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO_Samples_2
{

    //Interface och testning.

    public class TransactionInfo 
    {
        public DateTime TransactionDate { get; set; }
        public string TransactionOwner { get; set; }
        public string Comment { get; set; }
    }

    public interface IBankAccount
    {
        TransactionInfo Withdraw(float amount);
        TransactionInfo Deposit(float amount);

        float GetBalance();
        string GetBalanceInformation();
        List<TransactionInfo> GetTransactionList();
    }

    public abstract class BankAccount : IBankAccount
    {
        public BankAccount(int amount)
        {
            this.balance = amount;
        }
        private int balance { get; set; }
        public virtual void Debit(int amount) {
            balance -= amount;
        }

        public TransactionInfo Deposit(float amount)
        {
            throw new NotImplementedException();
        }

        public string GetBalance()
        {
            return GetType().Name + " Saldo: " + this.balance;
        }

        public string GetBalanceInformation()
        {
            throw new NotImplementedException();
        }

        public List<TransactionInfo> GetTransactionList()
        {
            throw new NotImplementedException();
        }

        public TransactionInfo Withdraw(float amount)
        {
            throw new NotImplementedException();
        }

        float IBankAccount.GetBalance()
        {
            throw new NotImplementedException();
        }
    }

    public class PremiumBankAccount : BankAccount 
    {
        public PremiumBankAccount(int amount) : base(amount)
        {
        }

        public override void Debit(int amount)
        {
            base.Debit(amount);
        }
    }

    public class NormalBankAccount : BankAccount
    {
        public NormalBankAccount(int amount) : base(amount)
        {
        }

        public override void Debit(int amount)
        {
            int extraDebitFee = 100;
            base.Debit(amount + extraDebitFee);
        }
    }

    //Sluten klass
    //public class CarService
    //{
    //    private string _make { get; set; }
    //    private DateTime _createdDate { get; set; }
    //    private string _registrationNumber { get; set; }

    //    private int _baseFee { get; set; }
    //    private int _yearlyFee { get; set; }

    //    private void CalculateYearlyVehicleFees()
    //    {
    //        this._yearlyFee = 12 * _baseFee + 50;
    //    }

    //    private void SaveVehicleInfo()
    //    {

    //        string infoToSave = _registrationNumber + _createdDate.ToString();
    //    }
    //}


    public class CarService
    {
        public string Make { get; set; }
        private DateTime _createdDate { get; set; }
        private string _registrationNumber { get; set; }

        public int BaseFee { get; set; }
        public int YearlyFee { get; set; }

        public int GetYearlyVehicleFees()
        {
            return this.YearlyFee = 12 * BaseFee + 50;
        }

        private void SaveVehicleInfo()
        {

            string infoToSave = _registrationNumber + _createdDate.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args) {


            CarService service = new CarService();

            int YearlyFee = 0;
            int BaseFee = 20;
            YearlyFee = 12 * BaseFee + 50;

            
            var result = service.GetYearlyVehicleFees();







            
            //BankAccount petersbankaccount = new PremiumBankAccount(10000);
            //BankAccount andersbankaccount = new NormalBankAccount(10000);

            //petersbankaccount.Debit(1000);
            //andersbankaccount.Debit(1000);

            //Console.WriteLine(petersbankaccount.GetBalance());
            //Console.WriteLine(andersbankaccount.GetBalance());

            //Console.ReadKey();



            ////istället för 
            ////BankAccount.Debit(amount, Type)


        }
    }
}
