using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;
using AspTravlerz.Models;

namespace AspTravlerz.TagHelpers
{

	[HtmlTargetElement("faq")]
	public class FaqTagHelper : TagHelper
	{

		public Faq Item { get; set; }

		public string Question { get; set; }

		public string Answer { get; set; }


		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			output.Content.AppendHtml($"<dt><i class=\"fa fa-question-circle\" style=\"color: blue;\" aria-hidden=\"true\"></i> Question:</dt><dd>{Item.Question}</dd>");
			output.Content.AppendHtml($"<dt><i class=\"fa fa-check-circle-o\" style=\"color: green;\" aria-hidden=\"true\"></i> Answer:</dt><dd>{Item.Answer}</dd>");
		}
	}
}
