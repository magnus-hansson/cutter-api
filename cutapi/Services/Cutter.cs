using TodoApi.Models;
using System.Collections.Generic;
using System.Linq;
public class Cutter
{
    public List<CutResult> DoStuff(TodoItem item)
    {
        var splits = SplitLengths(item.CutLength);
        var cutresult = new List<CutResult>();

        while (splits.Where(x => !x.IsCalculated).Any())
        {
            var computeres = Compute(item.BaseLength, splits.Where(x => !x.IsCalculated).ToList());
            cutresult.Add(computeres);
        };

        return cutresult;
    }

    public CutResult Compute(int baseLength, List<SplitLength> splits)
    {
        var usedLength = 0;
        var lengthResult = new CutResult() { BaseLength = baseLength, WasteLength = 0 };
        foreach (var split in splits)
        {
            if (split.Length + usedLength <= baseLength)
            {
                usedLength += split.Length;
                split.IsCalculated = true;
                lengthResult.CutLengths.Add(split.Length);
            }
        }
        lengthResult.WasteLength = baseLength - usedLength;
        return lengthResult;
    }

    public List<SplitLength> SplitLengths(List<Length> lengths)
    {
        var splitResult = new List<SplitLength>();
        foreach (var length in lengths)
        {
            for (int l = 0; l < length.NumberOfItems; l++)
            {
                splitResult.Add(new SplitLength() { IsCalculated = false, Length = length.CutLength });
            }
        }
        return splitResult;
    }
}