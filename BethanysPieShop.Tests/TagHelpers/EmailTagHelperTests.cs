using BethanysPieShop.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Moq;


namespace BethanysPieShop.Tests.TagHelpers;
public class EmailTagHelperTests
{
    // Marks this method as a unit test using xUnit.
    [Fact]
    public void Generates_Email_Link()
    {
        // Arrange: Setting up the EmailTagHelper with an email address and display content
        EmailTagHelper emailTagHelper = new EmailTagHelper()
        {
            Address = "test@bethanyspieshop.com",
            Content = "Email"
        };

        // Creating a context for the TagHelper
        var tagHelperContext = new TagHelperContext(
            new TagHelperAttributeList(), // No attributes initially
            new Dictionary<object, object>(), // Empty dictionary for additional items
            string.Empty // Unique ID (not used in this test)
        );

        // Mocking the content of the tag helper
        var content = new Mock<TagHelperContent>();

        // Creating the TagHelperOutput object, simulating an HTML `<a>` element
        var tagHelperOutput = new TagHelperOutput("a", // Tag name
            new TagHelperAttributeList(), // Empty attribute list
            (cache, encoder) => Task.FromResult(content.Object) // Setting up the content retrieval
        );

        // Act: Execute the Process method to generate the HTML output
        emailTagHelper.Process(tagHelperContext, tagHelperOutput);

        // Assert: Verify that the generated output matches expectations
        Assert.Equal("Email", tagHelperOutput.Content.GetContent()); // Ensure the content is "Email"
        Assert.Equal("a", tagHelperOutput.TagName); // The tag should be an anchor (`<a>`)
        Assert.Equal("mailto:test@bethanyspieshop.com", tagHelperOutput.Attributes[0].Value); // Ensure the href is a mailto link
    }
}
