using GitMessageDocumentGenerator.Model;
using System.Globalization;
using System.Text.RegularExpressions;

namespace GitMessageDocumentGenerator
{
    public class GitCommitMessagesProcessor
    {
        private const string _gitCommitMessageRegexPattern =
            @"commit\s(?<commit>[a-f0-9]+)\n" +
            @"(?:Merge:\s(?<merge>[^\n]+)\n)?" +
            @"Author:\s(?<author>.+)\n" +
            @"Date:\s+(?<date>.+)\n\n\s+" +
            @"(?<message>[\s\S]+?)(?=\ncommit|\z)";

        private readonly string _gitCommitMessageTagParttern =
            $@"^({TagType.fix.ToString()}|" +
            $@"{TagType.feat.ToString()}|" +
            $@"{TagType.chore.ToString()}|" +
            $@"{TagType.docs.ToString()}|" +
            $@"{TagType.refactor.ToString()}|" +
            $@"{TagType.perf.ToString()}|" +
            $@"{TagType.test.ToString()}|" +
            $@"{TagType.revert.ToString()}):";

        private const string _gitCommitMessageIssueParttern =
            @"issue:\s*(?<issue>\w+)";

        public List<GitMessageModel> GitMessageSplitter(string gitCommitMessage)
        {
            var GitMessageModelList = new List<GitMessageModel>();
            var regex = new Regex(_gitCommitMessageRegexPattern, RegexOptions.Multiline);

            gitCommitMessage = NormalizeLineEndings(gitCommitMessage);
            MatchCollection matches = regex.Matches(gitCommitMessage);

            foreach (Match match in matches)
            {
                string author = match.Groups["author"].Value;
                string commit = match.Groups["commit"].Value;
                string date = match.Groups["date"].Value;
                string merge = match.Groups["merge"].Value;
                string message = match.Groups["message"].Value;

                Match tagMatch = Regex.Match(message, _gitCommitMessageTagParttern, RegexOptions.Multiline);
                string tag = string.Empty;

                if (tagMatch.Success)
                {
                    tag = tagMatch.Value.TrimEnd(':');
                    message = message.Replace(tagMatch.Value, string.Empty);
                }

                Match issueMatch = Regex.Match(message, _gitCommitMessageIssueParttern, RegexOptions.IgnoreCase);
                string issue = string.Empty;

                if (issueMatch.Success)
                {
                    issue = issueMatch.Groups["issue"].Value;
                    message = message.Replace(issueMatch.Value, string.Empty);
                }

                GitMessageModelList.Add(new GitMessageModel
                {
                    Author = author,
                    Commit = commit,
                    Date = ConvertToDateTime(date),
                    Merge = merge,
                    Message = message,
                    Tag = tag,
                    Issue = issue,
                });
            }

            return GitMessageModelList;
        }

        private string NormalizeLineEndings(string source)
        {
            return source.Replace("\r\n", "\n");
        }

        private DateTime ConvertToDateTime(string dateString)
        {
            string format = "ddd MMM d HH:mm:ss yyyy K";
            CultureInfo provider = CultureInfo.InvariantCulture;

            return DateTime.ParseExact(dateString, format, provider);
        }

    }
}
