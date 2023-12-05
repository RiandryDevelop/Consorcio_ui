 using NotesAPP_Backend;
 using NotesAPP_Backend.Models;
 using Microsoft.AspNetCore.Hosting.Server;
 using Microsoft.EntityFrameworkCore;

 using NotesAPP_Backend.Services.Contract;
 using NotesAPP_Backend.Services.Implementation;

 using AutoMapper;
 using NotesAPP_Backend.Services.Implementation;
 using NotesAPP_Backend.DTOs;
 using NotesAPP_Backend.Utility;

public class Program
{
   public static void Main(string[] args)
    {
         
          var builder = WebApplication.CreateBuilder(args);


          builder.Services.AddEndpointsApiExplorer();
          builder.Services.AddSwaggerGen();
               builder.Services.AddAutoMapper(typeof(AutoMapperProfile));


          builder.Services.AddCors(options =>
         {
           options.AddPolicy("New Policy", app =>
           {
           app.AllowAnyOrigin()
                .AllowAnyHeader()
                  .AllowAnyMethod();
             });
           });


              builder.Services.AddDbContext<DbnotesContext>(options =>
          {

                options.UseSqlServer(builder.Configuration.GetConnectionString("Development"));
                /*options.UseSqlServer(builder.Configuration.GetConnectionString("Production"));*/
          });
          builder.Services.AddScoped<ITagsName, TagsNameService>();
         builder.Services.AddScoped<INotesService, NotesService>();


             var app = builder.Build();

        // Configure the HTTP request pipeline.
         if (app.Environment.IsDevelopment())
          {
           app.UseSwagger();
           app.UseSwaggerUI();
        }
        else
        {
          builder.Services.AddDbContext<DbnotesContext>(options =>
          {
            options.UseSqlServer(builder.Configuration.GetConnectionString("Development"));
        });
        }

        #region Api rest requests
          app.MapGet("/tagsName/list", async (
            ITagsName _tagsNameService,
          IMapper _mapper
              ) =>
          {
          var tagsNameList = await _tagsNameService.GetList();
          var tagsNameListDTO = _mapper.Map<List<TagsNameDTO>>(tagsNameList);

          if (tagsNameListDTO.Count > 0)
              return Results.Ok(tagsNameListDTO);
          else
             return Results.NotFound();
         });

          app.MapGet("/notes/list", async (
          INotesService _notesService,
          IMapper _mapper
          ) =>
          {
            var notesList = await _notesService.GetList();
           var notesListDTO = _mapper.Map<List<NotesSchemeDTO>>(notesList);

           if (notesListDTO.Count > 0)
             return Results.Ok(notesListDTO);
          else
              return Results.NotFound();
         });

          app.MapPost("/notes/save", async (
            NotesSchemeDTO model,
          INotesService _notesService,
          IMapper _mapper
         ) =>
         {
           var _notes = _mapper.Map<NotesScheme>(model);
         var _noteCreate = await _notesService.Add(_notes);

          if (_noteCreate.IdNote != 0)
          {
             return Results.Ok(_mapper.Map<NotesSchemeDTO>(model));
           }
          else
          {
            return Results.StatusCode(StatusCodes.Status500InternalServerError);
          }

         });

          app.MapPut("/notes/update/{IdNote}", async (
            int IdNote,
              NotesSchemeDTO model,
           INotesService _noteService,
            IMapper _mapper
          ) =>
          {
            var _foundOne = await _noteService.Get(IdNote);
           if (_foundOne is null) return Results.NotFound();
           var _note = _mapper.Map<NotesScheme>(model);
           _foundOne.Owner = _note.Owner;
          _foundOne.CreationDate = _note.CreationDate;
         _foundOne.IsArchive = _note.IsArchive;
          _foundOne.TagNameId = _note.TagNameId;

           var respond = await _noteService.Update(_foundOne);

         if (respond)
           return Results.Ok(_mapper.Map<NotesSchemeDTO>(_foundOne));
          else
             return Results.StatusCode(StatusCodes.Status500InternalServerError);
         });
         app.MapDelete("/notes/delete/{IdNote}", async (
           int IdNote,
         INotesService _noteService
            ) =>
          {
            var _foundOne = await _noteService.Get(IdNote);

          if (_foundOne is null) return Results.NotFound();

          var respond = await _noteService.Delete(_foundOne);

          if (respond)
            return Results.Ok();
          else
            return Results.NotFound(StatusCodes.Status500InternalServerError);
          });
        #endregion

        app.UseCors("New Policy");

         app.Run();
    }
}
