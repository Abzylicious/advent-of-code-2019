using AdventOfCode.Day14;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode.Test.Day14
{
    [TestFixture]
    public class PartTwoTests
    {
        private Refinery _refinery;

        [Test]
        public void ExampleOne()
        {
            var nzvs = new ChemicalReaction(new Chemical("NZVS", 5), ("ORE", 157));
            var dcfz = new ChemicalReaction(new Chemical("DCFZ", 6), ("ORE", 165));
            var fuel = new ChemicalReaction(new Chemical("FUEL", 1), ("XJWVT", 44), ("KHKGT", 5), ("QDVJ", 1), ("NZVS", 29), ("GPVTF", 9), ("HKGWZ", 48));
            var qdvj = new ChemicalReaction(new Chemical("QDVJ", 9), ("HKGWZ", 12), ("GPVTF", 1), ("PSHF", 8));
            var pshf = new ChemicalReaction(new Chemical("PSHF", 7), ("ORE", 179));
            var hkgwz = new ChemicalReaction(new Chemical("HKGWZ", 5), ("ORE", 177));
            var xjwvt = new ChemicalReaction(new Chemical("XJWVT", 2), ("DCFZ", 7), ("PSHF", 7));
            var gpvtf = new ChemicalReaction(new Chemical("GPVTF", 2), ("ORE", 165));
            var khkgt = new ChemicalReaction(new Chemical("KHKGT", 8), ("DCFZ", 3), ("NZVS", 7), ("HKGWZ", 5), ("PSHF", 10));
            _refinery = new Refinery(nzvs, dcfz, fuel, qdvj, pshf, hkgwz, xjwvt, gpvtf, khkgt);
            var actual = _refinery.GetMaxFuel(1000000000000L);
            actual.Should().Be(82892753);
        }

        [Test]
        public void ExampleTwo()
        {
            var stkfg = new ChemicalReaction(new Chemical("STKFG", 1), ("VPVL", 2), ("FWMGM", 7), ("CXFTF", 2), ("MNCFX", 11));
            var vpvl = new ChemicalReaction(new Chemical("VPVL", 8), ("NVRVD", 17), ("JNWZP", 3));
            var fuel = new ChemicalReaction(new Chemical("FUEL", 1), ("STKFG", 53), ("MNCFX", 6), ("VJHF", 46), ("HVMC", 81), ("CXFTF", 68), ("GNMV", 25));
            var fwmgm = new ChemicalReaction(new Chemical("FWMGM", 5), ("VJHF", 22), ("MNCFX", 37));
            var nvrvd = new ChemicalReaction(new Chemical("NVRVD", 4), ("ORE", 139));
            var jnwzp = new ChemicalReaction(new Chemical("JNWZP", 7), ("ORE", 144));
            var hvmc = new ChemicalReaction(new Chemical("HVMC", 3), ("MNCFX", 5), ("RFSQX", 7), ("FWMGM", 2), ("VPVL", 2), ("CXFTF", 19));
            var gnmv = new ChemicalReaction(new Chemical("GNMV", 6), ("VJHF", 5), ("MNCFX", 7), ("VPVL", 9), ("CXFTF", 37));
            var mncfx = new ChemicalReaction(new Chemical("MNCFX", 6), ("ORE", 145));
            var cxftf = new ChemicalReaction(new Chemical("CXFTF", 8), ("NVRVD", 1));
            var rfsqx = new ChemicalReaction(new Chemical("RFSQX", 4), ("VJHF", 1), ("MNCFX", 6));
            var vjhf = new ChemicalReaction(new Chemical("VJHF", 6), ("ORE", 176));
            _refinery = new Refinery(stkfg, vpvl, fuel, fwmgm, nvrvd, jnwzp, hvmc, gnmv, mncfx, cxftf, rfsqx, vjhf);
            var actual = _refinery.GetMaxFuel(1000000000000L);
            actual.Should().Be(5586022);
        }

        [Test]
        public void ExampleThree()
        {
            var cnztr = new ChemicalReaction(new Chemical("CNZTR", 8), ("ORE", 171));
            var plwsl = new ChemicalReaction(new Chemical("PLWSL", 4), ("ZLQW", 7), ("BMBT", 3), ("XCVML", 9), ("XMNCP", 26), ("WPTQ", 1), ("MZWV", 2), ("RJRHP", 1));
            var bhxh = new ChemicalReaction(new Chemical("BHXH", 4), ("ORE", 114));
            var bmbt = new ChemicalReaction(new Chemical("BMBT", 6), ("VRPVC", 14));
            var fuel = new ChemicalReaction(new Chemical("FUEL", 1), ("BHXH", 6), ("KTJDG", 18), ("WPTQ", 12), ("PLWSL", 7), ("FHTLT", 31), ("ZDVW", 37));
            var fhtlt = new ChemicalReaction(new Chemical("FHTLT", 6), ("WPTQ", 6), ("BMBT", 2), ("ZLQW", 8), ("KTJDG", 18), ("XMNCP", 1), ("MZWV", 6), ("RJRHP", 1));
            var zlqw = new ChemicalReaction(new Chemical("ZLQW", 6), ("XDBXC", 15), ("LTCX", 2), ("VRPVC", 1));
            var zdvw = new ChemicalReaction(new Chemical("ZDVW", 1), ("WPTQ", 13), ("LTCX", 10), ("RJRHP", 3), ("XMNCP", 14), ("MZWV", 2), ("ZLQW", 1));
            var wptq = new ChemicalReaction(new Chemical("WPTQ", 4), ("BMBT", 5));
            var ktjdg = new ChemicalReaction(new Chemical("KTJDG", 9), ("ORE", 189));
            var xmncp = new ChemicalReaction(new Chemical("XMNCP", 2), ("MZWV", 1), ("XDBXC", 17), ("XCVML", 3));
            var xdbxc = new ChemicalReaction(new Chemical("XDBXC", 2), ("VRPVC", 12), ("CNZTR", 27));
            var xcvml = new ChemicalReaction(new Chemical("XCVML", 5), ("KTJDG", 15), ("BHXH", 12));
            var mzwv = new ChemicalReaction(new Chemical("MZWV", 7), ("BHXH", 3), ("VRPVC", 2));
            var vrpvc = new ChemicalReaction(new Chemical("VRPVC", 7), ("ORE", 121));
            var rjrhp = new ChemicalReaction(new Chemical("RJRHP", 6), ("XCVML", 7));
            var ltcx = new ChemicalReaction(new Chemical("LTCX", 5), ("BHXH", 5), ("VRPVC", 4));
            _refinery = new Refinery(cnztr, plwsl, bhxh, bmbt, fuel, fhtlt, zlqw, zdvw, wptq, ktjdg, xmncp, xdbxc, xcvml, mzwv, vrpvc, rjrhp, ltcx);
            var actual = _refinery.GetMaxFuel(1000000000000L);
            actual.Should().Be(460664);
        }
    }
}
