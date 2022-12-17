
// This file is derived from: https://github.com/ArjanCodes/betterpython/blob/main/9%20-%20solid/open-closed-before.py

namespace OpenClosedBefore {
    public class Order {
        public List<string> Items { get; set; }
        public List<int> Quantities { get; set; }
        public List<double> Prices { get; set; }
        public string Status { get; set; }