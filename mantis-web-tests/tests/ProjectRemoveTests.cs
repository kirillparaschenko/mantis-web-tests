﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_web_tests
{
    [TestFixture]
    public class ProjectRemoveTests : AuthTestBase
    {
        [Test]
        public void ProjectRemoveTest()
        {
            AccountData account = new AccountData("administrator", "root");

            //if (app.Projects.GetProjectsList().Count == 0)
            //{
            //    app.Projects.Create(new ProjectData("New test project"));
            //}

            //List<ProjectData> oldProjects = app.Projects.GetProjectsList(); ;

            if (app.API.GetProjectList(account).Count == 0)
            {
                app.API.CreateProject(account, new ProjectData("New test project"));
            }

            List<ProjectData> oldProjects = app.API.GetProjectList(account);

            app.Projects.Remove(0);

            //List<ProjectData> newProjects = app.Projects.GetProjectsList();

            List<ProjectData> newProjects = app.API.GetProjectList(account);

            oldProjects.RemoveAt(0);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
