using HtmlAgilityPack;
using Jurassic;
using Jurassic.Library;

namespace HtmlReader
{
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

        public string ParseScript(string path, string template) {
            var engine = new ScriptEngine();
            var script = documentNode.SelectSingleNode(path).InnerText;
    
            var parsedScript = engine.Evaluate(string.Format(template, script));
    
            return JSONObject.Stringify(engine, parsedScript) as string;
        }
    }
}
