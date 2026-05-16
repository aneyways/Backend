using AudioShop.Domains.Entities.SiteReview;
using AudioShop.Domains.Models.SiteReview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioShop.BusinessLogic.Interface
{
    public interface ISiteReviewActions
    {
        public SiteReviewInfoDto CreateSiteReviewAction(SiteReviewCreateDto review);

        public List<SiteReviewInfoDto> GetAllSiteReviewsAction();

        public bool DeleteSiteReviewAction(int id);
    }
}