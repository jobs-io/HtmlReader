using NUnit.Framework;
using HtmlAgilityPack;

namespace HtmlReader.Tests {
    public class ReaderTests {
        [SetUp]
        public void Setup () {

        }

        [Test]
        public void Html () {
            Assert.AreEqual ("<h1>Some body text goes here.</h1>", new Reader ("<html><body><h1>Some body text goes here.</h1></html>").Html ("//body"));
        }

        [Test]
        public void Text() {
            Assert.AreEqual ("Some body text goes here.", new Reader ("<html><body><h1>Some body text goes here.</h1></html>").Text("//body"));
        }
    }

    public class Reader {
        private readonly HtmlNode documentNode;

        public Reader(string html) {
            var document = new HtmlDocument();
            document.LoadHtml(html);
            this.documentNode = document.DocumentNode;
        }
        public string Html(string path) {
            return documentNode.SelectSingleNode(path).InnerHtml;
        }

        public string Text(string path) {
            return documentNode.SelectSingleNode(path).InnerText;
        }
    }
}
