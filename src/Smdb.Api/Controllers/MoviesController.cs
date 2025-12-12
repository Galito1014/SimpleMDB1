using Smdb.Core.Movies;
using Shared.Http;
using Shared.Http.Results;
using System.Collections;

namespace Smdb.Api.Controllers;

public class MoviesController
{
    private readonly MovieService _service;

    public MoviesController(MovieService service)
    {
        _service = service;
    }

    public async Task GetAll(IHttpRequest req, IHttpResponse res, Hashtable props)
    {
        var page = int.TryParse(req.QueryString?["page"], out var p) ? p : 1;
        
        // Check pageSize first, then size, then default to 10
        int size = 10;
        if (req.QueryString != null)
        {
            if (req.QueryString.ContainsKey("pageSize") && int.TryParse(req.QueryString["pageSize"], out var ps))
                size = ps;
            else if (req.QueryString.ContainsKey("size") && int.TryParse(req.QueryString["size"], out var s))
                size = s;
        }

        var result = await _service.GetAllAsync(page, size);
        await JsonUtils.SendPagedResultResponse(res, result);
    }

    public async Task GetById(IHttpRequest req, IHttpResponse res, Hashtable props)
    {
        if (!int.TryParse(req.PathParams?["id"]?.ToString(), out var id))
        {
            await JsonUtils.SendError(res, "Invalid id", 400);
            return;
        }

        var result = await _service.GetByIdAsync(id);
        await JsonUtils.SendResultResponse(res, result);
    }

    public async Task Create(IHttpRequest req, IHttpResponse res, Hashtable props)
    {
        try
        {
            Console.WriteLine("[Controller.Create] Starting");
            Console.Out.Flush();
            
            if (!props.ContainsKey("jsonBody"))
            {
                Console.WriteLine("[Controller.Create] No jsonBody in props");
                Console.Out.Flush();
                await JsonUtils.SendError(res, "Invalid request body", 400);
                return;
            }

            var body = props["jsonBody"] as System.Text.Json.JsonElement?;
            if (body == null)
            {
                Console.WriteLine("[Controller.Create] jsonBody is null");
                Console.Out.Flush();
                await JsonUtils.SendError(res, "Invalid request body", 400);
                return;
            }

            Console.WriteLine("[Controller.Create] Building movie object");
            Console.Out.Flush();
            
            var movie = new Movie
            {
                Title = (body.Value.TryGetProperty("Title", out var t) ? t.GetString() : 
                        body.Value.TryGetProperty("title", out var tl) ? tl.GetString() : null) ?? "",
                Year = (body.Value.TryGetProperty("Year", out var y) ? y.GetInt32() : 
                       body.Value.TryGetProperty("year", out var yl) ? yl.GetInt32() : 0),
                Description = (body.Value.TryGetProperty("Description", out var d) ? d.GetString() : 
                              body.Value.TryGetProperty("description", out var dl) ? dl.GetString() : null) ?? "",
                Genre = (body.Value.TryGetProperty("Genre", out var g) ? g.GetString() : 
                        body.Value.TryGetProperty("genre", out var gl) ? gl.GetString() : null) ?? "",
                Rating = (body.Value.TryGetProperty("Rating", out var r) ? r.GetDouble() : 
                         body.Value.TryGetProperty("rating", out var rl) ? rl.GetDouble() : 0)
            };

            Console.WriteLine($"[Controller.Create] Calling service.CreateAsync for '{movie.Title}'");
            Console.Out.Flush();
            
            var result = await _service.CreateAsync(movie);
            
            Console.WriteLine($"[Controller.Create] Service returned, sending response");
            Console.Out.Flush();
            
            await JsonUtils.SendResultResponse(res, result, result.Success ? 201 : 400);
            
            Console.WriteLine($"[Controller.Create] Response sent successfully");
            Console.Out.Flush();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Controller.Create] Exception: {ex.GetType().Name}: {ex.Message}");
            Console.WriteLine($"[Controller.Create] Stack: {ex.StackTrace}");
            Console.Out.Flush();
            await JsonUtils.SendError(res, $"Error creating movie: {ex.Message}", 500);
        }
    }


    public async Task Update(IHttpRequest req, IHttpResponse res, Hashtable props)
    {
        // ─────────────────────────────────────────────────────────────────────────────────────
    
        if (!int.TryParse(req.PathParams?["id"]?.ToString(), out var id))
        {
            await JsonUtils.SendError(res, "Invalid id", 400);
            return;
        }

      
        if (props.ContainsKey("jsonBody") && props["jsonBody"] is System.Text.Json.JsonElement je)
        {
            try
            {
                var incoming = System.Text.Json.JsonSerializer.Deserialize<Movie>(je.GetRawText(),
                    new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (incoming == null)
                {
                    await JsonUtils.SendError(res, "Malformed JSON", 400);
                    return;
                }

                incoming.Id = id;
                
                var result = await _service.UpdateAsync(incoming);
                await JsonUtils.SendResultResponse(res, result);
                return;
            }
            catch (Exception ex)
            {
                await JsonUtils.SendError(res, "Malformed JSON: " + ex.Message, 400);
                return;
            }
        }


        var bodyText = props.ContainsKey("req.text") ? props["req.text"] as string : null;

        if (string.IsNullOrWhiteSpace(bodyText))
        {
            await JsonUtils.SendError(res, "Invalid request body", 400);
            return;
        }

        Movie? incoming2;

        try
        {
            incoming2 = System.Text.Json.JsonSerializer.Deserialize<Movie>(bodyText,
                new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
        catch (Exception ex)
        {
            await JsonUtils.SendError(res, "Malformed JSON: " + ex.Message, 400);
            return;
        }

        if (incoming2 == null)
        {
            await JsonUtils.SendError(res, "Empty request body", 400);
            return;
        }

        incoming2.Id = id; 
        var result2 = await _service.UpdateAsync(incoming2);
        await JsonUtils.SendResultResponse(res, result2);
    }


    public async Task Delete(IHttpRequest req, IHttpResponse res, Hashtable props)
    {
        if (!int.TryParse(req.PathParams?["id"]?.ToString(), out var id))
        {
            await JsonUtils.SendError(res, "Invalid id", 400);
            return;
        }

        var result = await _service.DeleteAsync(id);
        await JsonUtils.SendResultResponse(res, result);
    }
}
