using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Web;
using System.Data.Entity;

namespace BankManagement_Assignment
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class Application : System.Windows.Application
    {
        public static BankEntities Bank = new BankEntities();

        //===========================================================================

        public const int TERMS_1_YEAR = 1;
        public const int TERMS_3_YEAR = 3;
        public const int TERMS_5_YEAR = 5;
        public const string TYPE_FIXED_DEPOSITE                = "定期";
        public const string TYPE_DEMAND_DEPOSITE               = "活期";
        public const string TYPE_INSTALLMENT_FIXED_DEPOSITE    = "零存整取";

        //===========================================================================


        //定期存款 FIXED_DEPOSITE
        public static double RATE_FIXED_DEPOSITE_1_YEAR { get; private set; }
        public static double RATE_FIXED_DEPOSITE_3_YEAR { get; private set; }
        public static double RATE_FIXED_DEPOSITE_5_YEAR { get; private set; }
        public static double RATE_FIXED_DEPOSITE_OVERPASSED { get; private set; }//超出存款期限后的利率
        public static double RATE_FIXED_DEPOSITE_ADVANCED { get; private set; }//定期存款，提前取款时的利率

        //===========================================================================


        //零存整取定期存款 INSTALLMENT_FIXED_DEPOSITE
        public static double RATE_INSTALLMENT_FIXED_DEPOSITE_1_YEAR { get; private set; }
        public static double RATE_INSTALLMENT_FIXED_DEPOSITE_OVERPASSED { get; private set; }//超出存款期限后的利率
        public static double RATE_INSTALLMENT_FIXED_DEPOSITE_ADVANCED { get; private set; }//定期存款，提前取款时的利率

        //===========================================================================


        //活期存款 DEMAND_DEPOSITE
        public static double RATE_DEMAND_DEPOSITE { get; private set; }
        //===========================================================================

        Application()
        {
            init_Rate();
        }
        private void init_Rate()
        {
            var query = Query_Rate();

            //活期存款
            var 活期存款 = query.Where(s => s.Types == TYPE_DEMAND_DEPOSITE).First();

            RATE_DEMAND_DEPOSITE = (double)活期存款.Rate1;

            //零存整取
            var 零存整取 = query.Where(s => s.Types == TYPE_INSTALLMENT_FIXED_DEPOSITE).First();

            RATE_INSTALLMENT_FIXED_DEPOSITE_1_YEAR      = (double)零存整取.Rate1;
            RATE_INSTALLMENT_FIXED_DEPOSITE_ADVANCED    = (double)零存整取.Rate2;
            RATE_INSTALLMENT_FIXED_DEPOSITE_OVERPASSED  = (double)零存整取.Rate3;

            //定期存款 1年 3年 5年的 Rate2，Rate3 都一样
            var 定期存款1年 = query.Where(s => s.Types == TYPE_FIXED_DEPOSITE).Where(s => s.Terms == TERMS_1_YEAR).First();
            var 定期存款3年 = query.Where(s => s.Types == TYPE_FIXED_DEPOSITE).Where(s => s.Terms == TERMS_3_YEAR).First();
            var 定期存款5年 = query.Where(s => s.Types == TYPE_FIXED_DEPOSITE).Where(s => s.Terms == TERMS_5_YEAR).First();

            RATE_FIXED_DEPOSITE_1_YEAR = (double)定期存款1年.Rate1;
            RATE_FIXED_DEPOSITE_3_YEAR = (double)定期存款3年.Rate1;
            RATE_FIXED_DEPOSITE_5_YEAR = (double)定期存款5年.Rate1;

            RATE_FIXED_DEPOSITE_ADVANCED   = (double)定期存款1年.Rate2;
            RATE_FIXED_DEPOSITE_OVERPASSED = (double)定期存款1年.Rate3;
        }
        internal static void Save()
        {
            Bank.SaveChanges();
        }
        internal static void Close()
        {
            Bank.Dispose();
        }
        internal static void Add_Account(Account account)
        {
            Bank.Account.Add(account);
        }
        internal static void Add_Employer(Employer employer)
        {
            Bank.Employer.Add(employer);
        }
        internal static void Update_Employer(Employer employer)
        {
            Bank.Entry(employer).State = EntityState.Modified;
        }
        internal static void Add_Record(Record record)
        {
            Bank.Record.Add(record);
        }
        internal static double Get_Rate(string Type, int? Terms)
        {
            switch (Type)
            {
                case TYPE_DEMAND_DEPOSITE:
                    return RATE_DEMAND_DEPOSITE;
                case TYPE_INSTALLMENT_FIXED_DEPOSITE:
                    return RATE_INSTALLMENT_FIXED_DEPOSITE_1_YEAR;
                case TYPE_FIXED_DEPOSITE:
                    switch (Terms)
                    {
                        case TERMS_1_YEAR:
                            return RATE_FIXED_DEPOSITE_1_YEAR;
                        case TERMS_3_YEAR:
                            return RATE_FIXED_DEPOSITE_1_YEAR;
                        case TERMS_5_YEAR:
                            return RATE_FIXED_DEPOSITE_1_YEAR;
                    }
                    break;
                default:
                    break;
            }
            return RATE_DEMAND_DEPOSITE;
        }
        internal static IQueryable<Account> Query_Account()
        {
            var account = from t in Bank.Account select t;
            return account;
            throw new NotImplementedException();
        }
        internal static IQueryable<Employer> Query_Employer()
        {
            var employer = from t in Bank.Employer select t;
            return employer;
            throw new NotImplementedException();
        }
        internal static IQueryable<Record> Query_Record()
        {
            var record = from t in Bank.Record select t;
            return record;
            throw new NotImplementedException();
        }
        internal static IQueryable<Rate> Query_Rate()
        {
            var rate = from t in Bank.Rate select t;
            return rate;
            throw new NotImplementedException();
        }
        internal static IQueryable Query_Table(string Table = "Account")
        {
            var rate = from t in Bank.Rate select t;
            return rate;
            throw new NotImplementedException();
        }
    }
}
