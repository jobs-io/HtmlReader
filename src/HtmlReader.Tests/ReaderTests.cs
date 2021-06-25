using NUnit.Framework;

namespace HtmlReader.Tests {
    public class ReaderTests {
        [SetUp]
        public void Setup () {

        }

        [Test]
        public void Read () {
            Assert.AreEqual ("Some body text goes here.", new Reader ("<html><body>Some body text goes here.</html>").Read ("//body"));
        }
    }

    public class Reader {
        private readonly string html;

        public Reader(string html) {
            this.html = html;
        }
        public string Read(string path) {
            var document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(this.html);
            return document.DocumentNode.SelectSingleNode(path).InnerHtml;
        }
    }
}
