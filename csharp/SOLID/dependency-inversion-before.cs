//  This file is derived from: https://github.com/ArjanCodes/betterpython/blob/main/9%20-%20solid/dependency-inversion-before.py

namespace DependencyInversionBefore {
    public class Order {
        public List<string> Items { get; set; }
        public List<int> Quantities