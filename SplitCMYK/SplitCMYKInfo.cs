using System;
using System.Drawing;
using Grasshopper;
using Grasshopper.Kernel;

namespace SplitCMYK
{
  public class SplitCMYKInfo : GH_AssemblyInfo
  {
    public override string Name => "SplitCMYK";

    //Return a 24x24 pixel bitmap to represent this GHA library.
    public override Bitmap Icon => Properties.Resources.CMYK;

    //Return a short string describing the purpose of this GHA library.
    public override string Description => "Gets CMYK values from a Grasshopper Colour datatype.";

    public override Guid Id => new Guid("4809ab0b-5ff2-44be-b408-1bbca992108e");

    //Return a string identifying you or your company.
    public override string AuthorName => "dkeners";

    //Return a string representing your preferred contact details.
    public override string AuthorContact => "contact@dankenerson.com";
  }
}
