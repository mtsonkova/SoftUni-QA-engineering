using LibroConsoleAPI.Business;
using LibroConsoleAPI.Business.Contracts;
using LibroConsoleAPI.Data.Models;
using LibroConsoleAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroConsoleAPI.IntegrationTests.NUnit
{
    public  class IntegrationTests
    {
        private TestLibroDbContext dbContext;
        private IBookManager bookManager;

        [SetUp]
        public void SetUp()
        {
            string dbName = $"TestDb_{Guid.NewGuid()}";
            this.dbContext = new TestLibroDbContext(dbName);
            this.bookManager = new BookManager(new BookRepository(this.dbContext));
        }

        [TearDown]
        public void TearDown()
        {
            this.dbContext.Dispose();
        }

        [Test]
        public async Task AddBookAsync_ShouldAddBook()
        {
            // Arrange
            var newBook = new Book
            {
                Title = "Test Book",
                Author = "John Doe",
                ISBN = "1234567890123",
                YearPublished = 2021,
                Genre = "Fiction",
                Pages = 100,
                Price = 19.99
            };

            // Act
            await bookManager.AddAsync(newBook);

            // Assert
            var bookInDb = await dbContext.Books.FirstOrDefaultAsync(book => book.ISBN == newBook.ISBN);
            Assert.NotNull(bookInDb);
            Assert.AreEqual("Test Book", bookInDb.Title);
            Assert.AreEqual("John Doe", bookInDb.Author);
        }

        [Test]
        public async Task AddBookAsync_TryToAddBookWithInvalidCredentials_ShouldThrowException()
        {
            // Arrange
            var newBook = new Book
            {
                Title = "",
                Author = "Jane Smith",
                ISBN = "03",
                YearPublished = 2024,
                Genre = "Fiction",
                Pages = 180,
                Price = 10.15
            };
            // Act & Assert
          
           Assert.ThrowsAsync<ArgumentException>(async () => await bookManager.TryToAddAsync(newBook));
            var bookInDb  = await dbContext.Books.FirstOrDefaultAsync(book => book.Author == newBook.Author);
            Assert.Null(bookInDb);

        }

        [Test]
        public async Task DeleteBookAsync_WithValidISBN_ShouldRemoveBookFromDb()
        {
            // Arrange
            var newBook = new Book
            {
                Title = "Test Book",
                Author = "John Doe",
                ISBN = "1234567890123",
                YearPublished = 2021,
                Genre = "Fiction",
                Pages = 100,
                Price = 19.99
            };

            var result = await bookManager.AddAsync(newBook);
            // Act
            
            var deletedBook = await bookManager.DeleteAsync("1234567890123");

            //Assert
            Assert.Null(await deletedBook);           
        }

        [Test]
        public async Task DeleteBookAsync_TryToDeleteWithNullOrWhiteSpaceISBN_ShouldThrowException()
        {

            // Arrange
            var newBook = new Book
            {
                Title = "Test Book",
                Author = "John Doe",
                ISBN = "1234567890123",
                YearPublished = 2021,
                Genre = "Fiction",
                Pages = 100,
                Price = 19.99
            };

            var result = await bookManager.AddAsync(newBook);

            // Act & Assert

            Assert.ThrowsAsync<ArgumentException>(async () => await bookManager.DeleteAsync(null));

        }

        [Test]
        public async Task GetAllAsync_WhenBooksExist_ShouldReturnAllBooks()
        {
            // Arrange
            // Arrange
            var newBook = new Book
            {
                Title = "Test Book",
                Author = "John Doe",
                ISBN = "1234567890123",
                YearPublished = 2021,
                Genre = "Fiction",
                Pages = 100,
                Price = 19.99
            };

            var newBook2 = new Book
            {
                Title = "Test automation with C#",
                Author = "Soft Uni",
                ISBN = "3216540987124",
                YearPublished = 2024,
                Genre = "Software",
                Pages = 500,
                Price = 35.00
            };

            await bookManager.AddAsync(newBook);
            await bookManager.AddAsync(newBook2);

            // Act
            var result = bookManager.GetAllAsync();
            var expected = "";
            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public async Task GetAllAsync_WhenNoBooksExist_ShouldThrowKeyNotFoundException()
        {
            // Assert
            Assert.ThrowsAsync<KeyNotFoundException>(async () => await bookManager.GetAllAsync());
        }

        [Test]
        public async Task SearchByTitleAsync_WithValidTitleFragment_ShouldReturnMatchingBooks()
        {
            // Arrange
            var newBook = new Book
            {
                Title = "Test automation with C#",
                Author = "Soft Uni",
                ISBN = "3216540987124",
                YearPublished = 2024,
                Genre = "Software",
                Pages = 500,
                Price = 35.00
            };
            bookManager.AddAsync(newBook);

            // Act
            var result = await bookManager.SearchByTitleAsync("Test automation with C#");
            var expected = "book info here";
            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public async Task SearchByTitleAsync_WithInvalidTitleFragment_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            var newBook = new Book
            {
                Title = "Test automation with C#",
                Author = "Soft Uni",
                ISBN = "3216540987124",
                YearPublished = 2024,
                Genre = "Software",
                Pages = 500,
                Price = 35.00
            };
            bookManager.AddAsync(newBook);
            // Act & Assert
            Assert.ThrowsAsync<KeyNotFoundException>(async () => await bookManager.SearchByTitleAsync("Test automation with Java"));
        }

        [Test]
        public async Task GetSpecificAsync_WithValidIsbn_ShouldReturnBook()
        {
            // Arrange
            
            var newBook = new Book
            {
                Title = "Test automation with C#",
                Author = "Soft Uni",
                ISBN = "3216540987124",
                YearPublished = 2024,
                Genre = "Software",
                Pages = 500,
                Price = 35.00
            };
            bookManager.AddAsync(newBook);
            // Act
            var result = await bookManager.GetSpecificAsync("3216540987124");
            var expected = "book info here";

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public async Task GetSpecificAsync_WithInvalidIsbn_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            var newBook = new Book
            {
                Title = "Test automation with C#",
                Author = "Soft Uni",
                ISBN = "3216540987124",
                YearPublished = 2024,
                Genre = "Software",
                Pages = 500,
                Price = 35.00
            };
            bookManager.AddAsync(newBook);

           //Act & Assert
            Assert.ThrowsAsync<KeyNotFoundException>(async () => await bookManager.GetSpecicAsync("123"));
        }

        [Test]
        public async Task UpdateAsync_WithValidBook_ShouldUpdateBook()
        {
            // Arrange
           var newBook = new Book
            {
                Title = "Test automation with C#",
                Author = "Soft Uni",
                ISBN = "3216540987124",
                YearPublished = 2023,
                Genre = "Software",
                Pages = 500,
                Price = 30.00
            };
            bookManager.AddAsync(newBook);
            // Act
            newBook.Title = "Test Automation with C# 2nd Edition";
            newBook.Author = "SoftUni And Collective";
            newBook.YearPublished = 2024;
            newBook.Pages = 550;
            newBook.Price = 35.00;

            bookManager.UpdateAsync(newBook);
            var bookInDb = await dbContext.Books.FirstOrDefaultAsync(book => book.ISBN == newBook.ISBN);
            // Assert
            Assert.That(bookInDb.Title, Is.EqualTo("Test Automation with C# 2nd Edition"));
            Assert.That(bookInDb.Author, Is.EqualTo("SoftUni And Collective"));
            Assert.That(bookInDb.YearPublished, Is.EqualTo(2024));
            Assert.That(bookInDb.Pages, Is.EqualTo(550));
            Assert.That(bookInDb.Price, Is.EqualTo(35.00));
        }

        [Test]
        public async Task UpdateAsync_WithInvalidBook_ShouldThrowValidationException()
        {
            // Arrange
            var newBook = new Book
            {
                Title = "Test automation with C#",
                Author = "Soft Uni",
                ISBN = "3216540987124",
                YearPublished = 2023,
                Genre = "Software",
                Pages = 500,
                Price = 30.00
            };
            bookManager.AddAsync(newBook);

            // Act $ Assert
            Assert.ThrowsAsync<ValidationExpection>(async () => bookManager.UpdateAsync(new Book()));
          
        }
    }
}
