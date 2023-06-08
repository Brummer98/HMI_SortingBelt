using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.ComponentModel;
using System.Data.SqlClient;
using Business___Layer;
using HMI_SortingBelt.Models;

namespace HMI_MF.Controllers
{
    public class TagController : Controller
    {
        // Configurator and logger test
        private readonly IConfiguration configuration;
        private readonly ILogger<TagController> _logger;

        public TagController(IConfiguration config, ILogger<TagController> logger)
        {
            this.configuration = config;
            _logger = logger;
        }

        // GET: TagController
        public ActionResult Index()
        {
            // Create a list of all database items and show them

            List<HMI_SortingBelt.Models.TagModel> tagModelList = new();

            Business___Layer.TagCollection tagCollection = new Business___Layer.TagCollection();

            List<Business___Layer.TagDTO> tagDTOList = tagCollection.GetAllTags();

            foreach(var model in tagDTOList)
            {
                TagModel tagModel = new TagModel();
                tagModel.ID = model.ID;
                tagModel.TagName = model.TagName;
                tagModel.TagValue = model.TagValue;
                tagModelList.Add(tagModel);
            }

            return View(tagModelList);
        }

        // GET: TagController/Details/5
        public ActionResult Details(int id)
        {
            TagCollection collection = new TagCollection();

            List<Business___Layer.TagDTO> tagList = collection.getSingleTag(id);

            List<TagModel> tagModelList = new List<TagModel>();

            foreach (var model in tagList)
            {
                TagModel tagModel = new TagModel();
                tagModel.ID = model.ID;
                tagModel.TagName = model.TagName;
                tagModel.TagValue = model.TagValue;

                tagModelList.Add(tagModel);
            }

            return View(tagModelList[0]);
        }

        // GET: TagController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TagController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HMI_SortingBelt.Models.TagModel collection)
        {
            return RedirectToAction(nameof(Index));
        }

        // GET: TagController/Edit/5
        public ActionResult Edit(int id)
        {
            TagCollection collection = new TagCollection();

            List<Business___Layer.TagDTO> tagList = collection.getSingleTag(id);

            List<TagModel> tagModelList = new List<TagModel>();

            foreach(var model in tagList)
            {
                TagModel tagModel = new TagModel();
                tagModel.ID = model.ID;
                tagModel.TagName = model.TagName;
                tagModel.TagValue = model.TagValue;

                tagModelList.Add(tagModel);
            }

            return View(tagModelList[0]);
        }

        // POST: TagController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TagModel collection)
        {
            string TagName = collection.TagName;
            int TagValue = collection.TagValue;

            var newTag = new TagCollection();
            newTag.EditTag(id, TagName, TagValue);

            return RedirectToAction(nameof(Index));
        }

        // GET: TagController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TagController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // Page for the EM's in the sorting belt unit
        public ActionResult EMPage()
        {
            return View();
        }

        // Page for the EM's in the sorting belt unit
        public ActionResult CMPage()
        {
            return View();
        }
    }
}
