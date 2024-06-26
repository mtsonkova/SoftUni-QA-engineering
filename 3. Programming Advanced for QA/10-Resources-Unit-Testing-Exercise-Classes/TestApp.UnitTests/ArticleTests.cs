using NUnit.Framework;

using System;
using System.Collections.Generic;

namespace TestApp.UnitTests;

public class ArticleTests
{
    private Article _article;

    [SetUp]
    public void SetUp()
    {
       _article = new Article();
    }

    // TODO: write the setup method

    // TODO: finish test
    [Test]
    public void Test_AddArticles_ReturnsArticleWithCorrectData()
    {
        // Arrange
        string[] articles = { "Article Content1 Author1", "Article2 Content2 Author2", "Article3 Content3 Author3" };
       
        // Act
        Article result = _article.AddArticles(articles);
        
        //Assert
        Assert.That(result.ArticleList, Has.Count.EqualTo(3));
        Assert.That(result.ArticleList[0].Title, Is.EqualTo("Article"));
        Assert.That(result.ArticleList[1].Content, Is.EqualTo("Content2"));
        Assert.That(result.ArticleList[2].Author, Is.EqualTo("Author3"));
    }

    [Test]
    public void Test_GetArticleList_SortsArticlesByTitle()
    {
        // Arrange
        string[] articles = { "Article Content1 Author1", "Article2 Content2 Author2", "Article3 Content3 Author3" };
        string expected = $"Article - Content1: Author1{Environment.NewLine}" +
            $"Article2 - Content2: Author2{Environment.NewLine}" +
            $"Article3 - Content3: Author3";
            

        // Act
        Article result = _article.AddArticles(articles);
        string sortedArticles = _article.GetArticleList(result, "title");

        //Assert
        Assert.That(sortedArticles, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetArticleList_ReturnsEmptyString_WhenInvalidPrintCriteria()
    {
        // Arrange
        string[] articles = { "Article Content1 Author1", "Article2 Content2 Author2", "Article3 Content3 Author3" };
        string expected = string.Empty;


        // Act
        Article result = _article.AddArticles(articles);
        string sortedArticles = _article.GetArticleList(result, "id");

        //Assert
        Assert.That(sortedArticles, Is.EqualTo(expected));
    }
}
