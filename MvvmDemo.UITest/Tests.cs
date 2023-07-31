using System;
using NUnit.Framework;
using Xamarin.UITest;

namespace MvvmDemo.UITest
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void AppLaunches()
        {
            try
            {
                app.WaitForElement(x => x.Id("mvx_list"));
                app.Screenshot("List screen.");
            }
            catch (TimeoutException e)
            {
                Assert.Fail("Application is not filling the comic list");
            }

            Assert.Pass("Application launched successfully");
        }

        [Test]
        public void ShowComic()
        {
            app.Tap(x => x.Id("mvx_list"));

            try
            {
                app.WaitForElement(x => x.Id("comic_image"));
                app.WaitForElement(x => x.Id("comic_name"));
                app.WaitForElement(x => x.Id("comic_description"));
                app.Screenshot("Comic information screen.");
            }
            catch (TimeoutException e)
            {
                Assert.Fail("Application is not showing the comic information");
            }

            Assert.Pass("Application showed the comic's information successfully");
        }
    }
}
