//  This file is derived from: https://github.com/ArjanCodes/betterpython/blob/main/9%20-%20solid/dependency-inversion-before.py

namespace DependencyInversionBefore {
    public class Order {
        public List<string> Items { get; set; }
        public List<int> Quantities { get; set; }
        public List<double> Prices { get; set; }
        public string Status { get; set; }

        public Order() {
            this.Items = new List<string>();
            this.Quantities = new List<int>();
            this.Prices = new List<double>();
            this.Status = "open";
        }

        public void AddItem(string name, int quantity, double price) {
            this.Items.Add(name);
            this.Quantities.Add(quantity);
            this.Prices.Add(price);
        }

        public double TotalPrice() {
            double total = 0;

            for (int i = 0; i < this.Prices.Count; i++) {
                total += this.Quantities[i] * this.Prices[i];
            }

            return total;
        }
    }

    public class SMSAuthorizer {

        public bool Authorized { get; set; }

        public SMSAuthorizer() {
            this.Authorized = false;
        }

        public void VerifyCode(string code) {
            Console.WriteLine($"Verifying SMS code: {code}");
            this.Authorized = true;
        }
    }

    public interface IPaymentProcessor {
        public void Pay(Order order);
    }

    public class DebitPaymentProcessor : IPaymentProcessor {

        private string SecurityCode { get; }
        private SMSAuthorizer Authorizer { get; set; }

        public DebitPaymentProcessor(string securityCode, SMSAuthorizer authorizer) {
            this.SecurityCode = securityCode;
            this.Authorizer = authorizer;
        }

        public void Pay(Order order) {
            if (!this.Authorizer.Authorized) {
                throw new Exception("Not authorized");
            }
            Console.WriteLine("Processing debit payment type");
            Console.WriteLine($"Verifying security code: {this.SecurityCode}");
            order.Status = "paid";
        }
    }

    public class CreditPaymentProcessor : IPaymentProcessor {
        private string SecurityCode { get; }

        public CreditPaymentProcessor(string securityCode) {
            this.SecurityCode = securityCode;
        }

        public void Pay(Order order) {
            Console.WriteLine("Processing credit