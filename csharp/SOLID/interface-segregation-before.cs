
//  This file is derived from: https://github.com/ArjanCodes/betterpython/blob/main/9%20-%20solid/liskov-substitution-after.py

namespace InterfaceSegregationBefore {
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

    public interface IPaymentProcessor {
        public void AuthSMS(string code);
        public void Pay(Order order);
    }

    public class DebitPaymentProcessor : IPaymentProcessor {

        private string SecurityCode { get; }
        private bool Verified { set; get; }

        public DebitPaymentProcessor(string securityCode) {
            this.SecurityCode = securityCode;
            this.Verified = false;
        }

        public void AuthSMS(string code) {
            Console.WriteLine($"Verifying SMS code {code}");
            this.Verified = true;
        }

        public void Pay(Order order) {
            if (!this.Verified) {
                throw new Exception("Not authorized");
            }