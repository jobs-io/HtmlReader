using NUnit.Framework;
using HtmlAgilityPack;
using Jurassic;
using Jurassic.Library;

namespace HtmlReader.Tests {
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
        public void Text() {
            Assert.AreEqual ("Some body text goes here.", reader.Text("//body"));
        }

        [Test]
        public void ParseScript() {
            Assert.AreEqual("{\"givenNumber\":12}", reader.ParseScript("//script"));
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

        public string ParseScript(string path) {
            var engine = new ScriptEngine();
            var script = documentNode.SelectSingleNode(path).InnerText;
            var parsedScript = engine.Evaluate("(function() { var window = {}; " + script + "; return window; })()");
            return JSONObject.Stringify(engine, parsedScript) as string;
        }
    }
}
