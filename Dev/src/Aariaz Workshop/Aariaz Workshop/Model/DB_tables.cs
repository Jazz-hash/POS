using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.EntityFrameworkCore.Extensions;
using MySql.Data.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aariaz_Workshop.Model
{
    public class DB_tables : DbContext
    {
        public DB_tables() : base("DB_conn")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<TradingCompany> TradingCompanies { get; set; }
        public DbSet<OperatingSite> OperatingSites { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<Supplier_customer> Supplier_customers { get; set; }
        public DbSet<SalesPercentage> SalesPercentages { get; set; }
        //public DbSet<BarcodeHistory> BarcodeHistories { get; set; }
        public DbSet<Buying> Buyings { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<ShopUser> ShopUsers { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<TransferStock> TransferStocks { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<PaymentOrReceived> PaymentOrReceiveds { get; set; }
        public DbSet<StockDiscrepancy> StockDiscrepancies { get; set; }
        public DbSet<StockData> StockDatas { get; set; }
    }
    public class User
    {
        [Key]
        public int User_id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int OperatingSiteId { get; set; }
        //[ForeignKey("OperatingSite")]
        //public OperatingSite OperatingSite { get; set; }
        public int TradingCompany_id { get; set; }
        //[ForeignKey("TradingCompany")]
        //public TradingCompany TradingCompany { get; set; }
        public bool Status { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Leave> Leaves { get; set; }
        public ICollection<OperatingSite> OperatingSites { get; set; }
        public ICollection<TradingCompany> TradingCompanies { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Supplier_customer> Supplier_customers { get; set; }
        //public ICollection<BarcodeHistory> BarcodeHistories { get; set; }
        public ICollection<Buying> Buyings { get; set; }
        public ICollection<Shop> Shops { get; set; }
        public ICollection<ShopUser> ShopUsers { get; set; }
        public ICollection<Warehouse> Warehouses { get; set; }
        public ICollection<TransferStock> TransferStocks { get; set; }
        public ICollection<Receipt> Receipts { get; set; }
        public ICollection<PaymentOrReceived> PaymentOrReceiveds { get; set; }
        public ICollection<StockDiscrepancy> StockDiscrepancies { get; set; }
        public ICollection<StockData> StockDatas { get; set; }

    }
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string EmployeeCode { get; set; }
        public string Name { get; set; }
        public DateTime DateOfJoining { get; set; }
        public string NIC { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string JobDesignation { get; set; }
        public string Salary { get; set; }
        public int User_id { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        //[ForeignKey("User")]
        //public virtual User User { get; set; }

    }
    public class Leave
    {
        [Key]
        public int Id { get; set; }
        //public int User_id { get; set; }
        //[ForeignKey("User")]
        //public User User { get; set; }
    }
    public class TradingCompany
    {
        [Key]
        public int Id { get; set; }
        public string Company { get; set; }
        public int User_id { get; set; }
        [ForeignKey("User")]
        public User User { get; set; }
        public bool Status { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<StockData> StockDatas { get; set; }


    }
    public class OperatingSite
    {
        [Key]
        public int Id { get; set; }
        public string Site { get; set; }
        public int User_id { get; set; }
        //[ForeignKey("User")]
        //public User User { get; set; }
        public bool Status { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Receipt> Receipts { get; set; }
        public ICollection<StockData> StockDatas { get; set; }

    }
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public string Quantity { get; set; }
        public string CostPrice { get; set; }
        public string RetailPrice { get; set; }
        public string SizeSmail { get; set; }
        public string SizeMedium { get; set; }
        public string SizeLarge { get; set; }
        public string SizeXl { get; set; }
        public string Size22 { get; set; }
        public string Size24 { get; set; }
        public string Size26 { get; set; }
        public string Size28 { get; set; }
        public string Size30 { get; set; }
        public string Size32 { get; set; }
        public string Size34 { get; set; }
        public string Size36 { get; set; }
        //[ForeignKey("SalesPercentage")]
        //public SalesPercentage SalesPercentage { get; set; }
        public int SalesPercentage_id { get; set; }
        public int User_id { get; set; }
        //[ForeignKey("User")]
        //public User User { get; set; }
        public bool Status { get; set; }
        //public ICollection<BarcodeHistory> BarcodeHistories { get; set; }
        public ICollection<TransferStock> TransferStocks { get; set; }
        public ICollection<StockDiscrepancy> StockDiscrepancies { get; set; }


    }
    public class Sales
    {
        [Key]
        public int Id { get; set; }
        public bool Status { get; set; }

        // ????????????????????????????????????????

    }
    public class Supplier_customer
    {
        [Key]
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string CompanyNTN { get; set; }
        public string CustomerCode { get; set; }
        public string CreditLimit { get; set; }
        public string Type { get; set; }
        public int User_id { get; set; }
        //[ForeignKey("User")]
        //public User User { get; set; }
        public bool Status { get; set; }
        public ICollection<Buying> Buyings { get; set; }

    }
    public class SalesPercentage
    {
        [Key]
        public int Id { get; set; }
        public string Percentage { get; set; }
        public bool Status { get; set; }
        public ICollection<Product> Products { get; set; }
    }
    //public class BarcodeHistory
    //{
    //    [Key]
    //    public int Id { get; set; }
    //    public string ProductCode { get; set; }
    //    //[ForeignKey("Product")]
    //    //public Product Product { get; set; }
    //    public string Quantity { get; set; }
    //    public int User_id { get; set; }
    //    [ForeignKey("User")]
    //    public User User { get; set; }
    //    public bool Status { get; set; }

    //}
    public class Shop
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public int ShopUser_id { get; set; }
        //[ForeignKey("ShopUser")]
        //public ICollection<ShopUser> ShopUsers { get; set; }
        public int User_id { get; set; }
        //[ForeignKey("User")]
        //public User User { get; set; }
        public bool Status { get; set; }
        public ICollection<TransferStock> TransferStocks { get; set; }
        public ICollection<StockDiscrepancy> StockDiscrepancies { get; set; }

    }
    public class ShopUser
    {
        [Key]
        public int Id { get; set; }
        public int Shop_id { get; set; }
        //[ForeignKey("Shop")]
        //public ICollection<Shop> Shops { get; set; }
        public int UserShop_id { get; set; }
        //[ForeignKey("User")]
        //public User UserShop { get; set; }
        public int User_id { get; set; }
        //[ForeignKey("User")]
        //public User User { get; set; }
        public bool Status { get; set; }

    }
    public class Warehouse
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int User_id { get; set; }
        //[ForeignKey("User")]
        //public User User { get; set; }
        public bool Status { get; set; }
        public ICollection<TransferStock> TransferStocks { get; set; }
    }
    public class TransferStock
    {
        [Key]
        public int Id { get; set; }
        public string EventNumber { get; set; }
        public DateTime Date { get; set; }
        public int Warehouse_id { get; set; }
        //[ForeignKey("Warehouse")]
        //public Warehouse Warehouse { get; set; }
        public int Shop_id { get; set; }
        //[ForeignKey("Shop")]
        //public Shop Shop { get; set; }
        public int Product_id { get; set; }
        //[ForeignKey("Product")]
        //public Product Product { get; set; }
        public string ProductQuantity { get; set; }
        public int User_id { get; set; }
        //[ForeignKey("User")]
        //public User User { get; set; }
        public bool Status { get; set; }
    }
    public class Receipt
    {
        [Key]
        public int Id { get; set; }
        public int OperatingSite_id { get; set; }
        //[ForeignKey("OperatingSite")]
        //public OperatingSite OperatingSite { get; set; }
        public int User_id { get; set; }
        //[ForeignKey("User")]
        //public User User { get; set; }
        public bool Status { get; set; }

    }
    public class PaymentOrReceived
    {
        [Key]
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Debit { get; set; }
        public string Credit { get; set; }
        public string Balance { get; set; }
        public int User_id { get; set; }
        //[ForeignKey("User")]
        //public User User { get; set; }
        public string Type { get; set; }
        public bool Status { get; set; }

    }
    public class StockDiscrepancy
    {
        [Key]
        public int Id { get; set; }
        public int Shop_id { get; set; }
        [ForeignKey("Shop")]
        public Shop Shop { get; set; }
        public int Product_id { get; set; }
        [ForeignKey("Product")]
        public Product Product { get; set; }
        public int User_id { get; set; }
        [ForeignKey("User")]
        public User User { get; set; }
        public bool Status { get; set; }

    }
    public class StockData
    {
        [Key]
        public int Id { get; set; }
        public int User_id { get; set; }
        //[ForeignKey("User")]
        //public User User { get; set; }
        public int TradingCompany_id { get; set; }
        //[ForeignKey("TradingCompany")]
        //public TradingCompany TradingCompany { get; set; }
        public int OperatingSite_id { get; set; }
        //[ForeignKey("OperatingSite")]
        //public OperatingSite OperatingSite { get; set; }
        public bool Status { get; set; }

    }
}
