//  This file is derived from: https://github.com/ArjanCodes/betterpython/blob/main/9%20-%20solid/liskov-substitution-before.py

namespace LiskovSubstitutionBefore {
    public class Order {
        public List<string> Items { get; set; }
        public List<int> Quantities { get; set; }
        public List<double> Prices { get; set; }
        public string Status { get; set; }

        public Order() {
            this.Items = new List<string>();
            this.Quantities = new List<int>();
            this.Prices = new List<double>();
            this.Stat