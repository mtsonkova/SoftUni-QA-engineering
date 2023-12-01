using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articles
{
    internal class Article
    {
        private string title { get; set; }
        private string content { get; set; }
        private string author { get; set; }

        public Article(string title, string content, string author) {
            this.title = title;
            this.content = content;
            this.author = author;
        }

        public string Title { get { return title; } set { title = value; } }
        public string Content { get { return content; } set { content = value; } }
        public string Author { get { return author; } set { author = value; } }

        public void Edit(string content)
        {
            this.content = content;
        }

        public void ChangeAuthor(string author)
        {
            this.author = author;
        }

        public void Rename(string title)
        {
            this.title = title;
        }

        public override string ToString()
        {
            return $"{this.title} - {this.content}: {this.author}".Trim();
        }

        public Article changeArticle(Article article, int num)
        {
            for (int i = 0; i < num; i++)
            {
                string[] userInput = Console.ReadLine().Split(":").ToArray();
                string command = userInput[0];
                string text = userInput[1];

                switch (command)
                {
                    case "Edit":
                        {
                            article.Edit(text);
                        }
                        break;
                    case "ChangeAuthor":
                        {
                            article.ChangeAuthor(text);
                        }
                        break;
                    case "Rename":
                        {
                            article.Rename(text);
                        }
                        break;
                    default: break;
                }
            }

            return article;
        }
    }
}
