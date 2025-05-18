using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SLHDotNetTrainingBatch1.Project3.Databases.AppDbContextModels;
using CollinFile = System.IO.File;

namespace SLHDotNetTrainingBatch1.Project3.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DreamDictionaryController : ControllerBase
    {
        [HttpGet("Generate")]
        public IActionResult Generate([FromServices] AppDbContext db)
        {
            string json = CollinFile.ReadAllText("data.json");
            var data = JsonConvert.DeserializeObject<DataResponseModel>(json);

            //foreach (var item in data.BlogHeader)
            //{
            //    db.Add(new TblBlogHeader
            //    {
            //        BlogTitle = item.BlogTitle,
            //    });
            //}

            //foreach (var item in data.BlogDetail)
            //{

            //}

            var lstHeader = data.BlogHeader.Select(x => new TblBlogHeader
            {
                BlogTitle = x.BlogTitle,
            }).ToList();
            db.AddRange(lstHeader);
            db.SaveChanges();

            var lstDetail = data.BlogDetail.Select(x => new TblBlogDetail
            {
                BlogId = x.BlogId,
                BlogContent = x.BlogContent
            }).ToList();
            db.AddRange(lstDetail);
            db.SaveChanges();

            return Ok();
        }

        [HttpGet("List")]
        public IActionResult Get([FromServices] AppDbContext db)
        {
            return Ok(db.TblBlogHeaders.ToList());
        }

        [HttpGet]
        public IActionResult Get([FromServices] AppDbContext db, [FromQuery]string search)
        {
            bool isBlogId = int.TryParse(search, out var blogId);
            if (isBlogId)
            {
                return Ok(db.TblBlogDetails.Where(x => x.BlogId == blogId).ToList());
            }
            else
            {
                var item = db.TblBlogHeaders.FirstOrDefault(x => x.BlogTitle.Contains(search));
                return Ok(db.TblBlogDetails.Where(x => x.BlogId == item.BlogId).ToList());
            }
        }
    }


    public class DataResponseModel
    {
        public Blogheader[] BlogHeader { get; set; }
        public Blogdetail[] BlogDetail { get; set; }
    }

    public class Blogheader
    {
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
    }

    public class Blogdetail
    {
        public int BlogDetailId { get; set; }
        public int BlogId { get; set; }
        public string BlogContent { get; set; }
    }

}
