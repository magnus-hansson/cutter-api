using Xunit;
using Shouldly;
using System.Collections.Generic;
using CutApi.Models;

namespace CutApi.Tests
{
    public class CutterTests
    {
        [Fact]
        public void SplitLengthsShouldReturnCorrectNumberOfLengths()
        {
            var lengths = new List<Length>();
            lengths.Add(new Length() { NumberOfItems = 4, CutLength = 85 });
            lengths.Add(new Length() { NumberOfItems = 2, CutLength = 45 });

            var cutter = new Cutter();
            var splitres = cutter.SplitLengths(lengths);
            splitres.Count.ShouldBe(6);
        }

        [Fact]
        public void ComputeShouldReturnCorrectWaste()
        {
            var baseLength = 420;
            var splitLengths = new List<SplitLength>{
                new SplitLength{Length=85,IsCalculated=false},
                new SplitLength{Length=85,IsCalculated=false},
                new SplitLength{Length=185,IsCalculated=false},
                new SplitLength{Length=185,IsCalculated=false},
            };

            var cutter = new Cutter();
            var res = cutter.Compute(baseLength, splitLengths);

            res.WasteLength.Equals(65);
            res.CutLengths.Count.ShouldBe(3);
        }

        [Fact]
        public void RunCut()
        {
            var item = new CutItem { BaseLength = 420, CutLength = new List<Length> { new Length { NumberOfItems = 4, CutLength = 85 }, new Length { NumberOfItems = 2, CutLength = 45 } } };
            var cutter = new Cutter();
            var cutResult = cutter.Cut(item);
            cutResult.Count.ShouldBe(2);

        }
    }
}
