using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VsSDK.UnitTestLibrary;
using Microsoft.VSSDK.Tools.VsIdeTesting;
using Microsoft.VisualStudio.Shell.Interop;

namespace VSIXSkeleton.IntegrationTest
{
    [TestClass]
    // Enable "Copy to output directory" property for the EmptySolution.sln item beforehand.
    [DeploymentItem(@"Data\EmptySolution.sln", "Data")]
    public class Command1Test
    {
        [TestInitialize]
        public void Initialize()
        {
            // Obtain the SVsSolution service object.
            var solutionService = VsIdeTestHostContext.ServiceProvider.GetService(typeof(SVsSolution)) as IVsSolution;

            // Close the entire solution. (pHier == null, docCookie == 0)
            solutionService.CloseSolutionElement(
                (uint)__VSSLNSAVEOPTIONS.SLNSAVEOPT_NoSave,
                null,
                0);

            // Open the test solution.
            solutionService.OpenSolutionFile(0, @"Data\EmptySolution.sln");
        }

        [TestCleanup]
        public void Cleanup()
        {

        }

        [TestMethod]
        [HostType("VS IDE")]
        // This VSIX must be installed in the VS instance.
        //
        // Could not make this work in 15.0...
        // - MSTest 14.0 cannot find 15.0 maybe because now multiple instances of 15.0 can be installed and thus instance locations are stored differently.
        // - MSTest 15.0 cannot find VsHive.
        [TestProperty("VsHiveName", "14.0Exp")]
        public void InvokeCommand1Test()
        {
            // Invoke Command1
            UIThreadInvoker.Invoke(new Action(() =>
            {
                string guid = "{7089dc23-da22-4247-a401-13d348420447}";
                int cmdid = 0x0100;
                object customin = null;
                object customout = null;
                VsIdeTestHostContext.Dte.Commands.Raise(
                    guid, cmdid, ref customin, ref customout);
                // The reference reads customin and customout are out parameters (?_?)
            }));

            // Check if the test solution has been closed.
            var solutionService = VsIdeTestHostContext.ServiceProvider.GetService(typeof(SVsSolution)) as IVsSolution;

            object isSolutionOpen;
            solutionService.GetProperty(
                (int)__VSPROPID.VSPROPID_IsSolutionOpen,
                out isSolutionOpen);

            Assert.IsFalse((bool)isSolutionOpen);
        }
    }
}
