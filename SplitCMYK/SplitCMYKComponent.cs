using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using Eto.Drawing;
using Eto.Forms;

using Grasshopper;
using Grasshopper.Kernel;
using Rhino.Geometry;
using System.Runtime.Versioning;

namespace SplitCMYK
{
    public class SplitCMYKComponent : GH_Component
    {
        private bool RichBlackCLicked = false;

        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public SplitCMYKComponent()
          : base("Split CMYK", "SCMYK",
            "Split a colour into floating point {CMYK} channels",
            "Display", "Colour")
        {
        }

        public override GH_Exposure Exposure
        {
            get { return GH_Exposure.secondary; }
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddColourParameter("Colour", "C", "Colour to split", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddNumberParameter("Cyan", "C", "Cyan channel", GH_ParamAccess.item);
            pManager.AddNumberParameter("Magenta", "M", "Magenta channel", GH_ParamAccess.item);
            pManager.AddNumberParameter("Yellow", "Y", "Yellow channel", GH_ParamAccess.item);
            pManager.AddNumberParameter("Key", "K", "Key (Black) channel", GH_ParamAccess.item);
        }

        private void RichBlackClicked(object sender, EventArgs e)
        {
            RichBlackCLicked = !RichBlackCLicked;
            ExpireSolution(true);
        }

        protected override void AppendAdditionalComponentMenuItems(ToolStripDropDown menu)
        {
            base.AppendAdditionalComponentMenuItems(menu);
            Menu_AppendItem(menu, "Toggle Rich Black", RichBlackClicked, true, false);
        }

        protected override void BeforeSolveInstance()
        {
            if (RichBlackCLicked)
            {
                this.Message = "Rich Black";
            }
            else
            {
                this.Message = "Normal";
            }
            base.BeforeSolveInstance();
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            System.Drawing.Color colour = System.Drawing.Color.Empty;
            if (!DA.GetData(0, ref colour))
                return;

            float c, m, y, k;

            if (RichBlackCLicked)
            {
                ColourToCMYKRichBlack(colour, out c, out m, out y, out k);
            }
            else
            {
                ColourToCMYK(colour, out c, out m, out y, out k);
            }

            DA.SetData(0, c);
            DA.SetData(1, m);
            DA.SetData(2, y);
            DA.SetData(3, k);
        }

        /// <summary>
        /// Convert a colour to CMYK
        /// </summary>
        /// <param name="colour">Colour in RGB</param>
        /// <param name="c">Cyan</param>
        /// <param name="m">Magenta</param>
        /// <param name="y">Yellow</param>
        /// <param name="k">Key</param>
        private static void ColourToCMYK(System.Drawing.Color colour, out float c, out float m, out float y, out float k)
        {
            if (colour == System.Drawing.Color.Empty)
            {
                c = m = y = k = 0;
            }
            else
            {
                float r = colour.R / 255.0f;
                float g = colour.G / 255.0f;
                float b = colour.B / 255.0f;

                k = 1.0f - Math.Max(Math.Max(r, g), b);

                if (k == 1.0f)
                {
                    c = m = y = 0f;
                }
                else
                {
                    c = (1.0f - r - k) / (1.0f - k);
                    m = (1.0f - g - k) / (1.0f - k);
                    y = (1.0f - b - k) / (1.0f - k);
                }
            }
        }

        /// <summary>
        /// Convert a colour to CMYK using a rich black
        /// </summary>
        /// <param name="colour"></param>
        /// <param name="c"></param>
        /// <param name="m"></param>
        /// <param name="y"></param>
        /// <param name="k"></param>
        private static void ColourToCMYKRichBlack(System.Drawing.Color colour, out float c, out float m, out float y, out float k)
        {
            if (colour == System.Drawing.Color.Empty)
            {
                c = m = y = k = 0;
            }
            else
            {
                float r = colour.R / 255.0f;
                float g = colour.G / 255.0f;
                float b = colour.B / 255.0f;

                k = 1.0f - Math.Max(Math.Max(r, g), b);

                if (k == 1.0f)
                {
                    c = 0.6f;
                    m = y = 0.4f;
                }
                else
                {
                    c = (1.0f - r - k) / (1.0f - k);
                    m = (1.0f - g - k) / (1.0f - k);
                    y = (1.0f - b - k) / (1.0f - k);
                }
            }
        }

        /// <summary>
        /// Provides an Icon for every component that will be visible in the User Interface.
        /// Icons need to be 24x24 pixels.
        /// You can add image files to your project resources and access them like this:
        /// return Resources.IconForThisComponent;
        /// </summary>
        protected override System.Drawing.Bitmap Icon => Properties.Resources.CMYK;

        /// <summary>
        /// Each component must have a unique Guid to identify it. 
        /// It is vital this Guid doesn't change otherwise old ghx files 
        /// that use the old ID will partially fail during loading.
        /// </summary>
        public override Guid ComponentGuid => new Guid("0be4c541-8888-45b8-b989-de4dd8b82b26");
    }
}
