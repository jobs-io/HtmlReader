using System.Linq;
using HtmlAgilityPack;
using Jurassic;
using Jurassic.Library;

namespace HtmlReader
{
    public class Reader {
        private readonly HtmlNode documentNode;
        private readonly ScriptEngine scriptEngine;

        public Reader(string html) {
            var document = new HtmlDocument();
            document.LoadHtml(html);
            this.documentNode = document.DocumentNode;
            this.scriptEngine = new ScriptEngine();
        }
        public string Html(string path) {
            return documentNode.SelectSingleNode(path).InnerHtml;
        }

        public string[] HtmlItems(string path) {
            return documentNode.SelectNodes(path).Select(x => x.InnerHtml).ToArray();
        }

        public string Text(string path) {
            return documentNode.SelectSingleNode(path).InnerText;
        }

        public string ParseScript(string path, string template) {
            var script = documentNode.SelectSingleNode(path).InnerText;
    
            var parsedScript = scriptEngine.Evaluate(string.Format(template, script));
    
            return JSONObject.Stringify(scriptEngine, parsedScript) as string;
        }
    }
}
