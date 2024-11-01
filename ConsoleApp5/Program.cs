using System.Collections.Generic;
using System;

public class TaxCalculator
{
    private readonly Dictionary<string, Func<decimal, decimal>> _taxRules;

    public TaxCalculator()
    {
        _taxRules = new Dictionary<string, Func<decimal, decimal>>
        {
            { "India", taxableIncome => taxableIncome * 0.15m },
            { "USA", taxableIncome => taxableIncome * 0.20m },
            { "UK", taxableIncome => taxableIncome * 0.18m }
         
        };
    }

    public decimal Calculate(decimal income, decimal deduction, string country)
    {
        decimal taxableIncome = income - deduction;

        if (_taxRules.TryGetValue(country, out var calculateTax))
        {
            return calculateTax(taxableIncome);
        }
        else
        {
            throw new ArgumentException("No existe una regla de impuestos para el país especificado.");
        }
    }
}
