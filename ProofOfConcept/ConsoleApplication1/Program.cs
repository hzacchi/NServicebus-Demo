using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.VersionControl.Client;

namespace ConsoleApplication1
{
    internal class Program
    {
        private static void Main()
        {
            TfsTeamProjectCollection teamProjectCollection =
                TfsTeamProjectCollectionFactory.GetTeamProjectCollection(
                new Uri("http://cortfs03:8080/tfs/GOS%%20Software%%20Development"));

            var versionControl = teamProjectCollection.GetService<VersionControlServer>();
            var mergeCandidates =
                versionControl.GetMergeCandidates(@"$/JEMS/dev",
                                                  @"$/JEMS/main", RecursionType.Full);
            foreach (var mergeCandidate in mergeCandidates)
            {
                Console.WriteLine(string.Format("{0} {1} {2} {3}",
                                                mergeCandidate.Changeset.ChangesetId,
                                                mergeCandidate.Changeset.Owner,
                                                mergeCandidate.Changeset.CreationDate,
                                                mergeCandidate.Changeset.Comment));
            }

            Console.ReadKey();
        }
    }
}
