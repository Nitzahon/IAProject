using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;

namespace Paragraph
{

    public class P : Label
    {
        

        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            
            writer.AddAttribute(HtmlTextWriterAttribute.Id, this.ID);
            writer.AddStyleAttribute(HtmlTextWriterStyle.Color, this.ForeColor.Name);
            writer.AddStyleAttribute(HtmlTextWriterStyle.FontSize, this.Font.Size.ToString());

            writer.RenderBeginTag("p");
        }
    }
}
