using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// Import the necessary namespace for creating custom tag helpers
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BethanysPieShop.TagHelpers
{
    // Define a custom TagHelper class named EmailTagHelper
    public class EmailTagHelper : TagHelper
    {
        // Define a property to hold the email address (e.g., "contact@example.com")
        public string? Address { get; set; }

        // Define a property to hold the content that will be displayed as the link text
        public string? Content { get; set; }

        // Override the Process method to modify the output HTML when the tag helper is used
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // Set the generated HTML element to be an anchor (<a>) tag
            output.TagName = "a";

            // Add the "href" attribute to create a "mailto:" link using the provided email address
            output.Attributes.SetAttribute("href", "mailto:" + Address);

            // Set the inner content of the anchor tag to display the provided text (Content)
            output.Content.SetContent(Content);
        }
    }
}
