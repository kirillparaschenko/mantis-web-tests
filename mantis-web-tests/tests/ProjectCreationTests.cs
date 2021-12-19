using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Linq;

namespace mantis_web_tests
{
    [TestFixture]
    public class ProjectCreationTests : AuthTestBase
    {

        [Test]
        public void ProjectCreationTest()
        {
            AccountData account = new AccountData("administrator", "root");
            ProjectData project = new ProjectData("Test project");

            //List<ProjectData> oldProjects = app.Projects.GetProjectsList();

            List<ProjectData> oldProjects = app.API.GetProjectList(account);

            app.Projects.Create(project);

            //List<ProjectData> newProjects = app.Projects.GetProjectsList();

            List<ProjectData> newProjects = app.API.GetProjectList(account);
            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
