
using BethanysPieShop.Controllers;
using BethanysPieShop.Tests.Mocks;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Tests.Controllers
{
    public class PieControllerTests
    {
        // This attribute marks the method as a unit test for xUnit.
        [Fact]
        public void List_EmptyCategory_ReturnsAllPies()
        {
            // Arrange: Setting up the necessary mock objects
            var mockPieRepository = RepositoryMocks.GetPieRepository(); // Mock repository for pies
            var mockCategoryRepository = RepositoryMocks.GetCategoryRepository(); // Mock repository for categories

            // Creating an instance of PieController with the mocked dependencies
            var pieController = new PieController(mockPieRepository.Object, mockCategoryRepository.Object);

            // Act: Calling the List method with an empty category string
            var result = pieController.List("");

            // Assert: Validating the outcome
            var viewResult = Assert.IsType<ViewResult>(result); // Ensuring the result is of type ViewResult
            var pieListViewModel = Assert.IsAssignableFrom<PieListViewModel>(viewResult.ViewData.Model); // Checking the model type

            // Verifying that the expected number of pies (10) is returned in the view model
            Assert.Equal(10, pieListViewModel.Pies.Count());
        }
    }
}