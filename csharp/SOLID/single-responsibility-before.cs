// This file is derived from:
// https://github.com/ArjanCodes/betterpython/blob/main/9%20-%20solid/single-responsibility-before.py
// This is meant to be a bad example that breaks the single-responsibility principle.

namespace SingleResponsibilityBefore {
    public class Order {
        public List<string> Items { get; set; }
        public List<int> Quantities { get; set; }
        publi