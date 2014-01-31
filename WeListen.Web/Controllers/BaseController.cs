using System.Web.Mvc;
using WeListen.Web.Infrastructure.Session;

namespace WeListen.Web.Controllers
{
    /// <summary>
    ///     The custom base controller that all controllers inherit from in the WeListen web site.
    /// </summary>
    public class BaseController : Controller
    {
        private readonly SessionContext _context;

        /// <summary>
        ///     Initializes a new instance of the <see cref="BaseController" /> class.
        /// </summary>
        public BaseController()
        {
            _context = new SessionContext();
        }

        /// <summary>
        ///     Gets or sets the storage context.
        /// </summary>
        /// <value>
        ///     A context that can be used for persisting information across HTTP requests.
        /// </value>
        protected SessionContext Context
        {
            get { return _context; }
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            ViewBag.User = this.Context.WebUser;
        }
    }
}