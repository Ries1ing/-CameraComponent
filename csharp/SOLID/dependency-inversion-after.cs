
//  This file is derived from: https://github.com/ArjanCodes/betterpython/blob/main/9%20-%20solid/dependency-inversion-after.py

namespace DependencyInversionAfter {
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

    public interface IAuthorizer {
        public bool Authorized { set; get; }
        public bool IsAuthorized();
    }

    public class AuthorizerSMS : IAuthorizer {

        public bool Authorized { get; set; }

        public AuthorizerSMS() {
            this.Authorized = false;
        }

        public void VerifyCode(string code) {
            Console.WriteLine($"Verifying SMS code: {code}");
            this.Authorized = true;
        }

        public bool IsAuthorized() {
            return this.Authorized;
        }
    }

    public class AuthorizerGoogle : IAuthorizer {
        public bool Authorized { get; set; }

        public AuthorizerGoogle() {
            this.Authorized = false;
        }

        public void VerifyCode(string code) {
            Console.WriteLine($"Verifying Google auth code: {code}");
            this.Authorized = true;
        }

        public bool IsAuthorized() {
            return this.Authorized;
        }
    }

    public class AuthorizerRobot : IAuthorizer {
        public bool Authorized { get; set; }

        public AuthorizerRobot() {
            this.Authorized = false;
        }

        public void NotARobot() {
            this.Authorized = true;
        }

        public bool IsAuthorized() {
            return this.Authorized;
        }
    }

    public interface IPaymentProcessor {
        public void Pay(Order order);
    }

    public class DebitPaymentProcessor : IPaymentProcessor {

        private string SecurityCode { get; }
        private IAuthorizer Authorizer { get; set; }

        public DebitPaymentProcessor(string securityCode, IAuthorizer authorizer) {
            this.SecurityCode = securityCode;
            this.Authorizer = authorizer;
        }