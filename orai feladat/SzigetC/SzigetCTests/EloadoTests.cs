using Microsoft.VisualStudio.TestTools.UnitTesting;
using SzigetC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzigetC.Tests
{
    [TestClass()]
    public class EloadoTests
    {
        /*- kis- és nagybetűfüggetlenül működik,
- visszaadja a találatokat, ha a keresett szót tartalmazza egy vagy több slágercím,
- üres listát ad vissza, ha nincs találat.
*/
        [TestMethod()]
        [DataRow("Post Malone\tUSA\thip hop\t2025-08-10\t83000000\tCircles,Rockstar,Congratulations,Sunflower","les",new string[] {"Circles"})]
        [DataRow("Post Malone\tUSA\thip hop\t2025-08-10\t83000000\tCircles,Rockstar,Congratulations,Sunflower", "LES", new string[] { "Circles" })]
        [DataRow("Post Malone\tUSA\thip hop\t2025-08-10\t83000000\tCircles,Rockstar,Congratulations,Sunflower", "abc", new string[] { } )]
        public void KeresSlagerTest(string input,string keresett, string[] elvart)
        {
            Eloado eloado = new Eloado(input);
            List<string> aktualis = eloado.KeresSlager(keresett);
            CollectionAssert.AreEqual(elvart.ToList(),aktualis);
        }
    }
}