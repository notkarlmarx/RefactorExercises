﻿using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using RefactorExercises.VAT.Model;
using System.Collections.Generic;
using ObjectOrientedVatCalculatorV1 = RefactorExercises.VAT.ObjectOriented.V1.VatCalculator;
using ObjectOrientedVatCalculatorV2 = RefactorExercises.VAT.ObjectOriented.V2.Order;
using FunctionalVatCalculator = RefactorExercises.VAT.Functional.VatCalculator;

namespace RefactorExercises.Benchmarks.VAT
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class VatCalculatorBenchmarks
    {
        private readonly List<(Address address, Order order)> _values;

        public VatCalculatorBenchmarks()
        {
            var nonFoodProduct = new Product("Couch", 1m, false);
            var foodProduct = new Product("Carrot", 1m, true);
            _values = new List<(Address address, Order order)>
            {
                (new Address("it"), new Order(nonFoodProduct, 1)),
                (new Address("jp"), new Order(nonFoodProduct, 1)),
                (new Address("de"), new Order(nonFoodProduct, 1)),
                (new Address("de"), new Order(foodProduct, 1)),
                (new UsAddress("ca"), new Order(nonFoodProduct, 1)),
                (new UsAddress("ma"), new Order(nonFoodProduct, 1)),
                (new UsAddress("ny"), new Order(nonFoodProduct, 1)),
            };
        }

        [Benchmark(Baseline = true)]
        public void CalculateVatFunctional()
        {
            foreach (var (address, order) in _values)
            {
                _ = FunctionalVatCalculator.Vat(address, order);
            }
        }

        [Benchmark]
        public void CalculateVatObjectOrientedV1()
        {
            foreach (var (address, order) in _values)
            {
                var calculator = new ObjectOrientedVatCalculatorV1(address, order);
                _ = calculator.Vat();
            }
        }

        [Benchmark]
        public void CalculateVatObjectOrientedV2()
        {
            foreach (var (address, order) in _values)
            {
                var orderV2 = new ObjectOrientedVatCalculatorV2(order);
                _ = orderV2.Vat(address);
            }
        }
    }
}
