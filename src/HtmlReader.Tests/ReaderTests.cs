using NUnit.Framework;

namespace HtmlReader.Tests
{
    public class ReaderTests {

        private Reader reader;
    
        [SetUp]
        public void Setup () {
            reader = new Reader ("<html><head><script>\nwindow.givenNumber = 12;\n</script></head><body><h1>Some body text goes here.</h1></html>");
        }

        [Test]
        public void Html () {
            Assert.AreEqual ("<h1>Some body text goes here.</h1>", reader.Html ("//body"));
        }

        [Test]
        public void HtmlItems () {
            reader = new Reader ("<html><head><script>\nwindow.givenNumber = 12;\n</script></head><body><h1>Some body text goes here.</h1><data><item>my first data item</item><item>my second data item</item></data></html>");

            var htmlItems = reader.HtmlItems("//body/data/item");

            Assert.AreEqual ("my first data item", htmlItems[0]);
            Assert.AreEqual ("my second data item", htmlItems[1]);
        }

        [Test]
        public void Text() {
            Assert.AreEqual ("Some body text goes here.", reader.Text("//body"));
        }

        [Test]
        public void ParseScript() {
            var template = "(function() {{ var window = {{}}; {0}; return window; }})()";
            Assert.AreEqual("{\"givenNumber\":12}", reader.ParseScript("//script", template));
        }
    }
}
