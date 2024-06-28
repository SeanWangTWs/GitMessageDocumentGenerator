using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitMessageDocumentGenerator.Model
{
    public enum TagType
    {
        feat,
        fix,
        docs,
        style,
        refactor,
        perf,
        test,
        chore,
        revert,
        init
    }
}
