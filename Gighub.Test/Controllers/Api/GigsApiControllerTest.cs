using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FullStackCourse1.Controllers.Api;
using FullStackCourse1.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Gighub.Test.Controllers.Api
{
   public class GigsApiControllerTest
    {
        public GigsApiControllerTest()
        {
            var _unitOfWork =new Mock<IUnitOfWork>();

            var _gigsController=new GigsApiController(_unitOfWork.Object);


        }

        [TestMethod]
        public void Cancel_NoGigWithGivenIdExists_ReturnNotFound()
        {

        }
    }
}
