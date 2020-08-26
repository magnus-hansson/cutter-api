using Xunit;
using Shouldly;
using System.Collections.Generic;
using TodoApi.Models;
namespace cutapi.Tests
{
    public class CutterTests
    {
        [Fact]
        public void SplitLengthsShouldSplit()
        {
            var lengths = new List<Length>();
            lengths.Add(new Length() { NumberOfItems = 4, CutLength = 85 });
            lengths.Add(new Length() { NumberOfItems = 2, CutLength = 45 });

            var cutter = new Cutter();
            var splitres = cutter.SplitLengths(lengths);
            splitres.Count.ShouldBe(6);
        }

        [Fact]
        public void ComputeShouldCompute()
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
            res.CutLengths.Count.Equals(3);
        }

        [Fact]
        public void RunDoStuff()
        {
            var item = new TodoItem { BaseLength = 420, CutLength = new List<Length> { new Length { NumberOfItems = 4, CutLength = 85 }, new Length { NumberOfItems = 2, CutLength = 45 } } };
            var cutter = new Cutter();
            var res = cutter.DoStuff(item);
        }
    }
}
