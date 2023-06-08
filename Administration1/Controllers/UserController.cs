using Application.Features.Country.Queries.GetAll;
using Application.Features.User.Commands.Create;
using Application.Features.User.Commands.Delete;
using Application.Features.User.Commands.Update;
using Application.Features.User.Models;
using Application.Features.User.Queries.GetAll;
using Application.Features.User.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Administration1.Controllers;

public class UserController : Controller
{
    #region CTOR

    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IMediator _mediator;


    public UserController(IWebHostEnvironment webHostEnvironment, IMediator mediator)
    {
        _webHostEnvironment = webHostEnvironment;
        _mediator = mediator;
    }


    #endregion

  


	#region Index
	public async Task<IActionResult> Index()
    {
        IEnumerable<UserDTO> Users = await _mediator.Send(new GetAllUsersQuery());
        return View(Users);
    }


    #endregion

    #region Create
    public async Task<ActionResult> Create()
    {

        ViewBag.Countries = new SelectList(await _mediator.Send(new GetAllCountryQuery() { parentId = 0 }), "Id", "Name");

        ViewBag.Cities = new SelectList(await _mediator.Send(new GetAllCountryQuery() { parentId = 1 }), "Id", "Name");


        return PartialView("Form", new UserDTO { Active = true, CreateDate = DateTime.Now });
    }
    #endregion

    #region Edit
    public async Task<IActionResult> Edit(long id)
    {
        #region Dynamic List
        //var Countries = await _mediator.Send(new GetAllCountryQuery() { parentId = 0 });

        //List<SelectListItem> items = Countries.ConvertAll(a =>
        //{
        //    return new SelectListItem()
        //    {
        //        Text = a.ToString(),
        //        Value = a.ToString(),
        //        Selected = false
        //    };
        //});
        //ViewBag.Countries = items;

        //var Cities = await _mediator.Send(new GetAllCountryQuery() { parentId = 1 });

        //List<SelectListItem> items2 = Cities.ConvertAll(a =>
        //{
        //    return new SelectListItem()
        //    {
        //        Text = a.ToString(),
        //        Value = a.ToString(),
        //        Selected = false
        //    };
        //});
        //ViewBag.Cities = items2;

        #endregion
        var CountryId = await _mediator.Send(new GetAllCountryQuery() { parentId = 0 });

        ViewBag.Countries = new SelectList(await _mediator.Send(new GetAllCountryQuery() { parentId = 0 }), "Id", "Name");

        ViewBag.Cities = new SelectList(await _mediator.Send(new GetAllCountryQuery() { parentId =1 }), "Id", "Name");


        UserDTO userDTO = await _mediator.Send(new GetUserByIdQuery() { Id = id });




        return PartialView("Form", userDTO);
    }
    #endregion

    #region Form
    [HttpPost]
    public async Task<IActionResult> Form(UserDTO model)
    {
        #region dynamic select System
        //var Countries = await _mediator.Send(new GetAllCountryQuery() { parentId = 0 });

        //List<SelectListItem> items = Countries.ConvertAll(a =>
        //{
        //    return new SelectListItem()
        //    {
        //        Text = a.ToString(),
        //        Value = a.ToString(),
        //        Selected = false
        //    };
        //});
        //ViewBag.Countries = items;

        //var Cities = await _mediator.Send(new GetAllCountryQuery() { parentId = 1 });

        //List<SelectListItem> items2 = Cities.ConvertAll(a =>
        //{
        //    return new SelectListItem()
        //    {
        //        Text = a.ToString(),
        //        Value = a.ToString(),
        //        Selected = false
        //    };
        //});
        //ViewBag.Cities = items2;

        #endregion

        ViewBag.Countries = new SelectList(await _mediator.Send(new GetAllCountryQuery() { parentId = 0 }), "Id", "Name");

        ViewBag.Cities = new SelectList(await _mediator.Send(new GetAllCountryQuery() { parentId = 1 }), "Id", "Name");

        if (model.Id > 0)
        {
            
            var command = new UpdateUserCommand(model);
            await _mediator.Send(command);

            return View("form", command);



        }

        else
        {

            var command = new CreateUserCommand(model);
            await _mediator.Send(command);
            return RedirectToAction("Index");


        }

    }

    #endregion

    #region Details
    public async Task<IActionResult> Details(int id)
    {

		var eventDTO = await _mediator.Send(new GetUserByIdQuery() { Id = id });
        return View(eventDTO);
    }
    #endregion


    #region Delete



    public async Task<int> Delete(int id)
    {
        int res = 0;
        try
        {
            res = await _mediator.Send(new DeleteUserCommand() { Id = id });
        }
        catch
        { throw; }
        return 1;
    }
    #endregion



    #region Activate

    public async Task<int> Activate(long[] Ids)
    {
        try
        {
            foreach (var item in Ids)
            {
                var entity = await _mediator.Send(new GetUserByIdQuery() { Id = (int)item });
                if (entity.Active == true) entity.Active = false;
                else if (entity.Active == false) entity.Active = true;

                await _mediator.Send(new UpdateUserCommand(entity));
            }
        }
        catch
        {
            throw;
        }
        return 1;
    }
    #endregion
}